using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WitnessVisualizer
{
    public partial class MainForm : Form
    {
        PuzzleGraphRenderer graphRenderer;
        TetrisTemplateRenderer tetrisTemplateRenderer;
        BufferedGraphics graphBuffer, tetrisTemplateBuffer;
        PuzzleToolkit toolkit;
        List<ListViewItem> toolkitListViewItems;
        EditView editView;
        string savePath;
        int toolkitIconSize = 32;
        public MainForm()
        {
            InitializeComponent();
            // Init graph drawing
            Graphics graphTargetGraphics = editorPictureBox.CreateGraphics();
            graphBuffer = BufferedGraphicsManager.Current.Allocate(graphTargetGraphics, new Rectangle(0, 0, Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height));
            graphBuffer.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphRenderer = new PuzzleGraphRenderer(graphBuffer.Graphics);
            // Init tetris template drawing
            Graphics tetrisTemplateTargetGraphics = tetrisTemplatePictureBox.CreateGraphics();
            tetrisTemplateBuffer = BufferedGraphicsManager.Current.Allocate(tetrisTemplateTargetGraphics, new Rectangle(0, 0, tetrisTemplatePictureBox.Width, tetrisTemplatePictureBox.Height));
            tetrisTemplateBuffer.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            tetrisTemplateRenderer = new TetrisTemplateRenderer(tetrisTemplateBuffer.Graphics);
            // Init other stuff
            editorPictureBox.MouseWheel += EditorPictureBox_MouseWheel;
            InitToolkit();
            UpdateToolkitListView();
        }


        ~MainForm()
        {
            graphBuffer.Dispose();
        }
        void UpdateGraphDrawing()
        {
            graphRenderer.Draw(editView);
            graphBuffer.Render();
        }
        void UpdateTetrisTemplateDrawing()
        {
            tetrisTemplateRenderer.Draw(editView);
            tetrisTemplateBuffer.Render();
        }
        void UpdatePropertyGridBinding()
        {
            if (editView.SelectedObjects.Count == 1)
            {
                GraphElement element = editView.SelectedObjects[0];
                puzzlePropertyGrid.SelectedObject = element;
                puzzlePropertyGrid.ExpandAllGridItems();
            }
            else
            {
                if(editView.ColorPaintingMode)
                {
                    puzzlePropertyGrid.SelectedObject = editView.PaintingModeControl;
                }
                else if (editView.SampleDecorator != null)
                {
                    puzzlePropertyGrid.SelectedObject = editView.SampleDecorator;
                }
                else
                {
                    puzzlePropertyGrid.SelectedObject = editView.Graph.MetaData;
                }
            }
            if (puzzlePropertyGrid.SelectedObject is null)
                puzzlePropertyLabel.Text = "No Property Shown";
            else
                puzzlePropertyLabel.Text = puzzlePropertyGrid.SelectedObject.GetType().Name;
        }

        #region toolkit

        void InitToolkit(PuzzleToolkit inputToolkit = null)
        {
            if (inputToolkit == null)
            {
                try
                {
                    inputToolkit = PuzzleToolkit.LoadFromFile("toolkit/current.toolkit");
                }
                catch
                {
                    inputToolkit = PuzzleToolkit.CreateDefaultPuzzleToolkit();
                    if (MessageBox.Show("Corrupted Toolkit. Click YES to create a new one.", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        inputToolkit.SaveToFile("toolkit/current.toolkit");
                    }
                }
            }
            toolkit = inputToolkit;
            ImageList imageList = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = new Size(toolkitIconSize, toolkitIconSize)
            };
            ToolkitListView.LargeImageList = imageList;
            toolkitListViewItems = new List<ListViewItem>();
            foreach (PuzzleToolkitItem item in toolkit.Items)
            {
                imageList.Images.Add(item.GetImage(toolkitIconSize, toolkitIconSize));
                ListViewItem listViewItem = new ListViewItem(item.Name, imageList.Images.Count - 1);
                listViewItem.Tag = item;
                listViewItem.Name = item.Name;
                toolkitListViewItems.Add(listViewItem);
            }
        }
        void UpdateToolkitListView()
        {
            ToolkitListView.Items.Clear();
            foreach (ListViewItem item in toolkitListViewItems)
            {
                if(item.Name.ToLower().Contains(toolkitTextBox.Text.ToLower().Trim()) || item.Tag is PuzzleToolkitMiscItem)
                {
                    ToolkitListView.Items.Add(item);
                }
            }
        }
        private void ToolkitListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ToolkitListView.SelectedIndices.Count == 0)
                return;
            if (editView != null)
            {
                int index = ToolkitListView.SelectedIndices[0];
                if (ToolkitListView.Items[index].Tag is PuzzleToolkitDecoratorItem item) // Decorator
                {
                    editView.ChooseSampleDecorator(item.Decorator, false);
                    UpdatePropertyGridBinding();
                    UpdateGraphDrawing();
                    UpdateTetrisTemplateDrawing();
                }
                else if (ToolkitListView.Items[index].Text == "Pointer")
                {
                    if(editView.PasteMode || editView.ColorPaintingMode || editView.IsCreatingMode)
                    {
                        editView.ChooseSampleDecorator(null, false);
                        editView.PasteMode = false;
                        editView.ColorPaintingMode = false;
                        UpdatePropertyGridBinding();
                    }
                }
                else if (ToolkitListView.Items[index].Text == "Painter")
                {
                    editView.PasteMode = false;
                    editView.ColorPaintingMode = true;
                    UpdatePropertyGridBinding();
                }
                else throw new NotImplementedException();
            }
        }
        private void ToolkitAdd_Click(object sender, EventArgs e)
        {
            if (editView != null)
            {
                if (editView.SelectedObjects.Count == 0)
                {
                    MessageBox.Show("Please first select some objects on your puzzle.");
                    return;
                }
                Decorator decorator = editView.SelectedObjects[0].Decorator;
                if (string.IsNullOrWhiteSpace(toolkitTextBox.Text))
                {
                    MessageBox.Show("Please name the object using the text box.");
                    return;
                }
                string name = toolkitTextBox.Text;
                double size = PuzzleToolkit.GetSuggestedDecorationScale(decorator);
                toolkit.Items.Add(new PuzzleToolkitDecoratorItem(name, decorator, size));
                InitToolkit(toolkit);
                UpdateToolkitListView();
            }
        }

        private void ToolkitTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateToolkitListView();
        }
        private void ToolkitTextBox_Click(object sender, EventArgs e)
        {
            toolkitTextBox.SelectAll();
        }

        private void ToolkitListView_Click(object sender, EventArgs e)
        {
            if (editView != null)
            {
                if (editView.IsCreatingMode)
                    editView.ExitCreatingMode();
            }
        }

        private void ToolkitRemove_Click(object sender, EventArgs e)
        {
            if (ToolkitListView.SelectedIndices.Count == 0)
                return;
            if (MessageBox.Show("Are you sure you want to delete " + ToolkitListView.SelectedItems[0].Name +
                (ToolkitListView.SelectedIndices.Count > 1 ? "...?" : "?") +
                Environment.NewLine + "You cannot undo this.", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (ListViewItem item in ToolkitListView.SelectedItems)
                {
                    toolkit.Items.Remove(item.Tag as PuzzleToolkitItem);
                }
                InitToolkit(toolkit);
                UpdateToolkitListView();
            }
        }

        private void ToolkitLeft_Click(object sender, EventArgs e)
        {
            if (ToolkitListView.SelectedIndices.Count == 0)
                return;
            int selectedIndex = ToolkitListView.SelectedIndices[0];
            ToolkitListView.SelectedIndices.Clear();
            if (selectedIndex > 0)
            {
                PuzzleToolkitItem swapItem = toolkit.Items[selectedIndex - 1];
                toolkit.Items.RemoveAt(selectedIndex - 1);
                toolkit.Items.Insert(selectedIndex, swapItem);
                InitToolkit(toolkit);
                UpdateToolkitListView();
                ToolkitListView.SelectedIndices.Add(selectedIndex - 1);
            }
        }

        private void ToolkitRight_Click(object sender, EventArgs e)
        {
            if (ToolkitListView.SelectedIndices.Count == 0)
                return;
            int selectedIndex = ToolkitListView.SelectedIndices[0];
            ToolkitListView.SelectedIndices.Clear();
            if (selectedIndex < ToolkitListView.Items.Count - 1)
            {
                PuzzleToolkitItem swapItem = toolkit.Items[selectedIndex + 1];
                toolkit.Items.RemoveAt(selectedIndex + 1);
                toolkit.Items.Insert(selectedIndex, swapItem);
                InitToolkit(toolkit);
                UpdateToolkitListView();
                ToolkitListView.SelectedIndices.Add(selectedIndex + 1);
            }

        }

        private void SaveSchemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolkitFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Toolkit");
            if (saveToolkitFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            toolkit.SaveToFile(saveToolkitFileDialog.FileName);
        }
        private void LoadSchemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openToolkitFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Toolkit");
            if (openToolkitFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            toolkit = PuzzleToolkit.LoadFromFile(openToolkitFileDialog.FileName);
            InitToolkit(toolkit);
            UpdateToolkitListView();
        }
        private void MergeSchemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openToolkitFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Toolkit");
            if (openToolkitFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            PuzzleToolkit mergeToolkit = PuzzleToolkit.LoadFromFile(openToolkitFileDialog.FileName);
            Dictionary<string, PuzzleToolkitItem> dict = new Dictionary<string, PuzzleToolkitItem>();
            foreach(PuzzleToolkitItem item in toolkit.Items)
            {
                if (!dict.ContainsKey(item.Name))
                    dict.Add(item.Name, item);
            }
            int count = 0;
            foreach(PuzzleToolkitItem item in mergeToolkit.Items)
            {
                if(!dict.ContainsKey(item.Name))
                {
                    dict.Add(item.Name, item);
                    toolkit.Items.Add(item);
                    count += 1;
                }
            }
            MessageBox.Show("Added " + count + " items.");
            InitToolkit(toolkit);
            UpdateToolkitListView();

        }

        private void ResetToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PuzzleToolkit inputToolkit = PuzzleToolkit.CreateDefaultPuzzleToolkit();
            InitToolkit(inputToolkit);
            UpdateToolkitListView();
        }
        #endregion

        #region picturebox
        private void EditorPictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if(editView != null)
            {
                editView.Scroll(e.X, e.Y, e.Delta);
                UpdateGraphDrawing();
            }
        }

        private void EditorPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (editView != null)
            {
                bool controlPressed = (ModifierKeys & Keys.Control) == Keys.Control;
                if (editView.MouseDown(e.X, e.Y, e.Button, controlPressed))
                    ToolkitListView.SelectedItems.Clear(); // Copy is performed
                UpdateGraphDrawing();
                UpdatePropertyGridBinding();
                UpdateTetrisTemplateDrawing();
            }
        }

        private void EditorPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (editView != null)
            {
                editView.MouseMove(e.X, e.Y);
                UpdateGraphDrawing();
            }
        }

        private void EditorPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (editView != null)
            {
                editView.MouseUp(e.X, e.Y, e.Button);
                UpdateGraphDrawing();
            }
        }
        private void TetrisTemplatePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (editView != null)
            {
                editView.TetrisTemplateClick(e.X, e.Y, e.Button);
                UpdateGraphDrawing();
                UpdateTetrisTemplateDrawing();
            }

        }
        #endregion

        #region propertygrid

        private void PuzzlePropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            UpdateGraphDrawing();
            UpdateTetrisTemplateDrawing();
        }
        private void ResetPropertyButton_Click(object sender, EventArgs e)
        {
            PropertyDescriptor pd = puzzlePropertyGrid.SelectedGridItem.PropertyDescriptor;
            pd.ResetValue(puzzlePropertyGrid.SelectedObject);
            puzzlePropertyGrid.Refresh();
        }

        #endregion

        #region menu
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Templates");
            if (createFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            savePath = null;
            Graph graph = Graph.LoadFromFile(createFileDialog.FileName);
            if (ObsolateFormatFixer.FixObsoletedTetrisFormat(graph))
            {
                Console.WriteLine("[Info] We have automatically upgraded the obsoleted file format. Please remember to save.");
            }
            editView = new EditView(graph, editorPictureBox.Width, editorPictureBox.Height, tetrisTemplatePictureBox.Width, tetrisTemplatePictureBox.Height);
            UpdateGraphDrawing();
            UpdateTetrisTemplateDrawing();
            ToolkitListView.SelectedItems.Clear();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveInfoFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Puzzles");
            if (editView != null)
            {
                if (saveInfoFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                savePath = saveInfoFileDialog.FileName;
                editView.Graph.SaveToFile(savePath);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(editView != null)
            {
                if(!string.IsNullOrEmpty(savePath))
                    editView.Graph.SaveToFile(savePath);
                else
                    SaveAsToolStripMenuItem_Click(sender, e);
            }
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openInfoFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Puzzles");
            if (openInfoFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            savePath = openInfoFileDialog.FileName;
            Graph graph = Graph.LoadFromFile(savePath);
            if(ObsolateFormatFixer.FixObsoletedTetrisFormat(graph))
            {
                Console.WriteLine("[Info] We have automatically upgraded the obsoleted file format. Please remember to save.");
            }
            editView = new EditView(graph, editorPictureBox.Width, editorPictureBox.Height, tetrisTemplatePictureBox.Width, tetrisTemplatePictureBox.Height);
            UpdateGraphDrawing();
            UpdateTetrisTemplateDrawing();
            ToolkitListView.SelectedItems.Clear();
        }

        private void DeleteElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editView != null)
            {
                editView.GraphEditManager.BeforePreformEdit(editView.Graph, "Delete Graph Elements");
                foreach (GraphElement element in editView.SelectedObjects)
                    editView.Graph.RemoveElement(element);
                editView.SelectedObjects.Clear();
                UpdateGraphDrawing();
            }
        }
        private void FlipXYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editView != null)
            {
                editView.GraphEditManager.BeforePreformEdit(editView.Graph, "Flip X/Y");
                Graph graph = Graph.FlipGraph(editView.Graph,Graph.FlipType.XY);
                editView = new EditView(graph, editorPictureBox.Width, editorPictureBox.Height, tetrisTemplatePictureBox.Width, tetrisTemplatePictureBox.Height);
                UpdateGraphDrawing();
                UpdateTetrisTemplateDrawing();
                ToolkitListView.SelectedItems.Clear();
            }
        }
        private void FlipHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editView != null)
            {
                editView.GraphEditManager.BeforePreformEdit(editView.Graph, "Flip Horizontally");
                Graph graph = Graph.FlipGraph(editView.Graph, Graph.FlipType.Horizontal);
                editView = new EditView(graph, editorPictureBox.Width, editorPictureBox.Height, tetrisTemplatePictureBox.Width, tetrisTemplatePictureBox.Height);
                UpdateGraphDrawing();
                UpdateTetrisTemplateDrawing();
                ToolkitListView.SelectedItems.Clear();
            }
        }
        private void FlipVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editView != null)
            {
                editView.GraphEditManager.BeforePreformEdit(editView.Graph, "Flip Vertically");
                Graph graph = Graph.FlipGraph(editView.Graph, Graph.FlipType.Vertical);
                editView = new EditView(graph, editorPictureBox.Width, editorPictureBox.Height, tetrisTemplatePictureBox.Width, tetrisTemplatePictureBox.Height);
                UpdateGraphDrawing();
                UpdateTetrisTemplateDrawing();
                ToolkitListView.SelectedItems.Clear();
            }
        }

        private void RotateBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editView != null)
            {
                while(true)
                {
                    string result = Prompt.ShowDialog("Enter the angle (clockwise) in degrees:", "Hint");
                    if (string.IsNullOrWhiteSpace(result)) break;
                    double angle;
                    if(double.TryParse(result,out angle))
                    {
                        if (angle == 0.0) break;
                        if(!double.IsNaN(angle) && !double.IsInfinity(angle))
                        {
                            editView.GraphEditManager.BeforePreformEdit(editView.Graph, "Rotate Graph");
                            Graph graph = Graph.RotateGraph(editView.Graph, angle * Math.PI / 180);
                            editView = new EditView(graph, editorPictureBox.Width, editorPictureBox.Height, tetrisTemplatePictureBox.Width, tetrisTemplatePictureBox.Height);
                            UpdateGraphDrawing();
                            UpdateTetrisTemplateDrawing();
                            ToolkitListView.SelectedItems.Clear();
                            break;
                        }
                    }
                }
            }
        }

        private void ClearDecorationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editView != null)
            {
                editView.ClearSelectedDecorations();
                UpdateGraphDrawing();
                UpdateTetrisTemplateDrawing();
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editView != null)
            {
                if (editView.SelectedObjects.Count > 0)
                {
                    editView.ChooseSampleDecorator(editView.SelectedObjects[0].Decorator, true);
                    ToolkitListView.SelectedIndices.Clear();
                }
                UpdateGraphDrawing();
                UpdateTetrisTemplateDrawing();
            }

        }

        private void EditorPictureBox_Resize(object sender, EventArgs e)
        {
            if(editView!=null)
            {
                editView.Resize(editorPictureBox.Width, editorPictureBox.Height, tetrisTemplatePictureBox.Width, tetrisTemplatePictureBox.Height);
                UpdateGraphDrawing();
                UpdateTetrisTemplateDrawing();
            }
        }

        private void BestViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(editView!=null)
            {
                editView.SwitchToBestView();
                UpdateGraphDrawing();
            }
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Images");
            if (editView != null)
            {
                editView.SwitchToBestView();
                if (exportFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                savePath = exportFileDialog.FileName;
                editView.ExportToFile(savePath);
            }

        }

        private void RegularPolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<object> menuItems = new List<object>() { null, null, null, regularTriangleToolStripMenuItem, regularSquareToolStripMenuItem, regularPentagonToolStripMenuItem, regularHexagonToolStripMenuItem };

            if (editView != null)
            {
                Graph graph = editView.Graph;
                int edges = menuItems.IndexOf(sender);
                if (editView.SelectedObjects.Count > 0 && editView.SelectedObjects[0] is Edge edge)
                {
                    editView.GraphEditManager.BeforePreformEdit(editView.Graph, "Draw Regular Polygon");
                    GraphManipulation.TryAddShapeWithBaseSegment(graph, edge, GraphManipulation.CreateRegularPolygon(edges));
                    UpdateGraphDrawing();
                }
                else
                {
                    MessageBox.Show("Error: Please select an edge first.");
                }
            }
        }
        private void RegenerateFromGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editView != null)
            {
                editView.GraphEditManager.BeforePreformEdit(editView.Graph, "Regenerate Tetris Templates");
                editView.RegenerateTetrisTemplates();
                UpdateTetrisTemplateDrawing();

            }
        }

        private void CreatingModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(editView != null)
            {
                editView.EnterCreatingMode();
                ToolkitListView.SelectedItems.Clear();
                ToolkitListView.Items[0].Selected = true;
            }
        }
        private void ExitCreatingModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editView != null)
            {
                editView.ExitCreatingMode();
                ToolkitListView.SelectedItems.Clear();
                ToolkitListView.Items[0].Selected = true;
            }

        }


        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Witness Puzzle Designer\ninstr3.github.com");
        }


        private void EditToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if(editView != null)
            {
                undoToolStripMenuItem.Enabled = editView.GraphEditManager.CanUndo;
                redoToolStripMenuItem.Enabled = editView.GraphEditManager.CanRedo;
                undoToolStripMenuItem.Text = "Undo " + editView.GraphEditManager.LastUndoInfo;
                redoToolStripMenuItem.Text = "Redo " + editView.GraphEditManager.LastRedoInfo;
            }
            else
            {
                undoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
                undoToolStripMenuItem.Text = "Undo";
                redoToolStripMenuItem.Text = "Redo";
            }
        }
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editView != null && editView.GraphEditManager.CanUndo)
            {
                Graph graph = editView.GraphEditManager.Undo(editView.Graph);
                editView.SetNewGraph(graph);
                UpdateGraphDrawing();
                UpdatePropertyGridBinding();
                editView.UpdateTetrisTemplateScaleAndOrigin(editView.Graph.MetaData.TetrisTemplate);
                UpdateTetrisTemplateDrawing();
            }
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editView != null && editView.GraphEditManager.CanRedo)
            {
                Graph graph = editView.GraphEditManager.Redo();
                editView.SetNewGraph(graph);
                UpdateGraphDrawing();
                UpdatePropertyGridBinding();
                editView.UpdateTetrisTemplateScaleAndOrigin(editView.Graph.MetaData.TetrisTemplate);
                UpdateTetrisTemplateDrawing();
            }
        }

        private void CombineDecorationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editView != null)
            {
                if (editView.SelectedObjects.Count == 2)
                {
                    bool result = editView.CombineDecorators(editView.SelectedObjects[0], editView.SelectedObjects[1]);
                    if (result)
                    {
                        UpdateGraphDrawing();
                        UpdatePropertyGridBinding();
                        return;
                    }
                }
                MessageBox.Show("Please (use Ctrl) to select two face decorations to combine them.");
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                if(editView!=null)
                {
                    if (editView.IsCreatingMode)
                    {
                        ExitCreatingModeToolStripMenuItem_Click(sender, e);
                    }
                    else
                    {
                        editView.SelectedObjects.Clear();
                        ToolkitListView.SelectedItems.Clear();
                        ToolkitListView.Items[0].Selected = true;
                    }
                    UpdateGraphDrawing();
                    UpdatePropertyGridBinding();
                    UpdateTetrisTemplateDrawing();
                }
            }

        }
        private void RescaleCurrentTetrisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(editView!=null)
            {
                bool ok = false;
                if(editView.SelectedObjects.Any(element=>element.Decorator is PuzzleGraph.Decorators.AbstractTetrisDecorator))
                {
                    string output = "1.0";
                    DialogResult result = InputDialog.ShowInputDialog("Scale Factor", ref output);
                    if (result == DialogResult.OK)
                    {
                        double value;
                        if (double.TryParse(output, out value))
                        {
                            editView.GraphEditManager.BeforePreformEdit(editView.Graph, "Rescale Tetris Object (*" + output + ")");
                            foreach(GraphElement element in editView.SelectedObjects)
                            {
                                if(element.Decorator is PuzzleGraph.Decorators.AbstractTetrisDecorator tetris)
                                {
                                    tetris.Shapes = tetris.Shapes.Select(shape => shape.Select(node => new Node(node.X * value, node.Y * value)).ToList()).ToList();
                                }
                            }
                            UpdateGraphDrawing();
                            UpdatePropertyGridBinding();
                            UpdateTetrisTemplateDrawing();
                        }
                        else
                        {
                            MessageBox.Show("Please enter a float scale factor (e.g., 2.0 or 0.5).");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select at least one tetris object.");
                    return;
                }
            }
        }

        #endregion



        private void MainForm_Load(object sender, EventArgs e)
        {

        }

    }
}
