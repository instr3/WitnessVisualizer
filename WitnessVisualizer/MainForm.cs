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
            PrepareToolkitListView();
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
                puzzlePropertyGrid.SelectedObject = element.Decorator;
            }
            else
            {
                if (editView.SampleDecorator != null)
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
        void PrepareToolkitListView()
        {
            toolkit = PuzzleToolkit.CreateDefaultPuzzleToolkit();
            ImageList imageList = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = new Size(toolkitIconSize, toolkitIconSize)
            };
            ToolkitListView.LargeImageList = imageList;
            ToolkitListView.Items.Clear();
            foreach (PuzzleToolkitItem item in toolkit.Items)
            {
                imageList.Images.Add(item.GetImage(toolkitIconSize, toolkitIconSize));
                ListViewItem listViewItem = new ListViewItem(item.Name, imageList.Images.Count - 1);
                listViewItem.Tag = item;
                ToolkitListView.Items.Add(listViewItem);
            }
        }
        private void ToolkitListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ToolkitListView.SelectedIndices.Count == 0)
                return;
            if (editView != null)
            {
                int index = ToolkitListView.SelectedIndices[0];
                if (index == 0)
                {
                    editView.ChooseSampleDecorator(null, false);
                    UpdatePropertyGridBinding();
                    editView.PasteMode = false;
                }
                else // Decorator
                {
                    PuzzleToolkitDecoratorItem item = ToolkitListView.Items[index].Tag as PuzzleToolkitDecoratorItem;
                    editView.ChooseSampleDecorator(item.Decorator, false);
                    UpdatePropertyGridBinding();
                    UpdateGraphDrawing();
                    UpdateTetrisTemplateDrawing();
                }
            }
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
                if (editView.MouseDown(e.X, e.Y, e.Button))
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
            editView = new EditView(graph, editorPictureBox.Width, editorPictureBox.Height, tetrisTemplatePictureBox.Width, tetrisTemplatePictureBox.Height);
            UpdateGraphDrawing();
            UpdateTetrisTemplateDrawing();
            ToolkitListView.SelectedItems.Clear();
        }

        private void DeleteElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editView != null)
            {
                foreach (GraphElement element in editView.SelectedObjects)
                    editView.Graph.RemoveElement(element);
                editView.SelectedObjects.Clear();
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

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Witness Puzzle Designer\ninstr3.github.com");
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
