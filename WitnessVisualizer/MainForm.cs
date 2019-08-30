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
        PuzzleSettings settings;
        PuzzleToolkit toolkit;
        EditView editView;
        string savePath;
        int toolkitIconSize = 32;
        public MainForm()
        {
            InitializeComponent();
            // Init graph drawing
            Graphics graphTargetGraphics = editorPictureBox.CreateGraphics();
            graphBuffer = BufferedGraphicsManager.Current.Allocate(graphTargetGraphics, new Rectangle(0, 0, editorPictureBox.Width, editorPictureBox.Height));
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
            if(editView.SelectedObjects.Count==1)
            {
                GraphElement element = editView.SelectedObjects[0];
                puzzlePropertyGrid.SelectedObject = element.Decorator;
            }
            else
            {
                puzzlePropertyGrid.SelectedObject = editView.Graph.MetaData;
            }
        }
        #region test
        Graph TestCreateTestGraph()
        {
            Graph graph = new Graph();
            Node a = new Node(1.0, 1.0);
            Node b = new Node(1.0, 2.0);
            Node d = new Node(2.0, 1.0);
            Node c = new Node(2.0, 3.0);
            Edge e1 = new Edge(a, b);
            Edge e2 = new Edge(a, d);
            Edge e3 = new Edge(b, c);
            Edge e4 = new Edge(c, d);
            Face face = new Face(new List<Node>() { a, d, c, b });
            face.Decorator = new PuzzleGraph.Decorators.EliminatorDecorator();
            graph.Nodes.AddRange(new List<Node>() { a, b, c, d });
            graph.Edges.AddRange(new List<Edge>() { e1, e2, e3, e4 });
            graph.Faces.AddRange(new List<Face>() { face });
            return graph;
        }

        Graph TestCreateRectGraph()
        {
            Graph graph = new Graph();
            int size = 4;
            List<Node> nodes = new List<Node>();
            Node[,] dict = new Node[5, 5];
            for (int i = 0; i <= size; ++i)
            {
                for (int j = 0; j <= size; ++j)
                {
                    dict[i, j] = new Node(i + 1, j + 1);
                    nodes.Add(dict[i, j]);
                }
            }
            List<Edge> edges = new List<Edge>();
            for (int i = 1; i <= size; ++i)
                for (int j = 0; j <= size; ++j)
                    edges.Add(new Edge(dict[i - 1, j], dict[i, j]));
            for (int i = 0; i <= size; ++i)
                for (int j = 1; j <= size; ++j)
                    edges.Add(new Edge(dict[i, j - 1], dict[i, j]));
            List<Face> faces = new List<Face>();
            for (int i = 1; i <= size; ++i)
                for (int j = 1; j <= size; ++j)
                    faces.Add(new Face(new List<Node>() { dict[i - 1, j - 1], dict[i - 1, j], dict[i, j], dict[i, j - 1] }));
            graph.Nodes.AddRange(nodes);
            graph.Edges.AddRange(edges);
            graph.Faces.AddRange(faces);
            faces[0].Decorator = new PuzzleGraph.Decorators.EliminatorDecorator();
            faces[1].Decorator = new PuzzleGraph.Decorators.SquareDecorator();
            faces[2].Decorator = new PuzzleGraph.Decorators.StarDecorator() { Color = Color.Orange };
            faces[3].Decorator = new PuzzleGraph.Decorators.StarDecorator() { Color = Color.Black };
            faces[4].Decorator = new PuzzleGraph.Decorators.TriangleDecorator() { Count = 1 };
            faces[5].Decorator = new PuzzleGraph.Decorators.TriangleDecorator() { Count = 2 };
            faces[6].Decorator = new PuzzleGraph.Decorators.TriangleDecorator() { Count = 3 };
            nodes[0].Decorator = new PuzzleGraph.Decorators.PointDecorator();
            nodes[1].Decorator = new PuzzleGraph.Decorators.StartDecorator();
            nodes[2].Decorator = new PuzzleGraph.Decorators.StartDecorator();
            edges[0].Decorator = new PuzzleGraph.Decorators.PointDecorator();
            edges[1].Decorator = new PuzzleGraph.Decorators.BrokenDecorator();
            edges[10].Decorator = new PuzzleGraph.Decorators.BrokenDecorator();
            edges[12].Decorator = new PuzzleGraph.Decorators.StartDecorator();
            nodes[24].Decorator = new PuzzleGraph.Decorators.EndDecorator();
            faces[7].Decorator = new PuzzleGraph.Decorators.TetrisDecorator() { Indexes = new List<int>() { 0, 1, 2, 3, 6 }, Angel = 30 };
            faces[8].Decorator = new PuzzleGraph.Decorators.HollowTetrisDecorator() { Indexes = new List<int>() { 0, 1, 3, 5 } };
            return graph;
        }
        void createTetrisTemplate(Graph graph)
        {
            int size = 5;
            List<List<Node>> result = new List<List<Node>>();
            for (int i = 1; i <= size; ++i)
            {
                for (int j = 1; j <= size; ++j)
                {
                    result.Add(new List<Node>() { new Node(i, j), new Node(i + 1, j), new Node(i + 1, j + 1), new Node(i, j + 1) });
                }
            }
            graph.MetaData.TetrisTemplate.Shapes.AddRange(result);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Graph graph = TestCreateRectGraph();
            createTetrisTemplate(graph);
            graph = new Graph(graph.ToString());
            editView = new EditView(graph, editorPictureBox.Width, editorPictureBox.Height, tetrisTemplatePictureBox.Width, tetrisTemplatePictureBox.Height);
            graph.MetaData.PuzzleTitle = "abc";
            UpdateGraphDrawing();
            UpdateTetrisTemplateDrawing();
            ImagePrepare();
        }
        void ImagePrepare()
        {
            Image image = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.FillRectangle(Brushes.Black, 0, 0, 16, 16);
            }

            ImageList imageList = new ImageList();
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageSize = new Size(16, 16);
            imageList.Images.Add("key", image);;
            ToolkitListView.LargeImageList = imageList;
            ToolkitListView.Items.Add("abc", 0);
        }
        #endregion
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
                ToolkitListView.Items.Add(item.Name, imageList.Images.Count - 1);
            }
        }
        #endregion
        private void EditorPictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if(editView != null)
            {
                editView.Scroll(e.X, e.Y, e.Delta);
                UpdateGraphDrawing();
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void ResetPropertyButton_Click(object sender, EventArgs e)
        {
            PropertyDescriptor pd = puzzlePropertyGrid.SelectedGridItem.PropertyDescriptor;
            pd.ResetValue(puzzlePropertyGrid.SelectedObject);
            puzzlePropertyGrid.Refresh();
        }

        private void EditorPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (editView != null)
            {
                editView.MouseDown(e.X, e.Y, e.Button);
                UpdateGraphDrawing();
                UpdatePropertyGridBinding();
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
                UpdateTetrisTemplateDrawing();
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            editView.SelectedObjects.Clear();
            foreach(var node in editView.Graph.Faces)
            {
                editView.SelectedObjects.Add(node);
            }
            UpdateGraphDrawing();
        }

        private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, e.Bounds);
        }

        private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, e.Bounds);
        }

        private void PuzzlePropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            UpdateGraphDrawing();
            UpdateTetrisTemplateDrawing();
        }

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

        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            if (openInfoFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            savePath = openInfoFileDialog.FileName;
            Graph graph = Graph.LoadFromFile(savePath);
            editView = new EditView(graph, editorPictureBox.Width, editorPictureBox.Height, tetrisTemplatePictureBox.Width, tetrisTemplatePictureBox.Height);
            UpdateGraphDrawing();
            UpdateTetrisTemplateDrawing();
        }



        #endregion
        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Witness Puzzle Designer\ninstr3.github.com");
        }

        private void ListView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, e.Bounds);
        }
    }
}
