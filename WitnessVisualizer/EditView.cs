using MathHelper;
using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WitnessVisualizer
{
    class EditView
    {
        public Graph Graph { get; private set; }
        public double Scale { get; set; } = 100.0;
        public Vector Origin { get; set; } = Vector.Zero;
        public bool IsDragging { get; private set; }
        Vector mouseDownPosition;
        Vector editorSize;
        Vector tetrisTemplateEditorSize;
        public Decorator SampleDecorator { get; private set; }
        public bool PasteMode { get; set; }
        public List<GraphElement> SelectedObjects { get; private set; } = new List<GraphElement>();
        public List<GraphElement> HoveredObjects { get; private set; } = new List<GraphElement>();
        public bool[] SelectedTetrisShapes { get; private set; }
        public EditView(Graph inputGraph, int inputEditorWidth, int inputEditorHeight, int inputTetrisTemplateWidth, int inputTetrisTemplateHeight)
        {
            editorSize = new Vector(inputEditorWidth, inputEditorHeight);
            tetrisTemplateEditorSize = new Vector(inputTetrisTemplateWidth, inputTetrisTemplateHeight);
            Graph = inputGraph;
            CalculateTetrisTemplateScaleAndOrigin(Graph.MetaData.TetrisTemplate);
            SelectedTetrisShapes = new bool[Graph.MetaData.TetrisTemplate.Shapes.Count];
            SwitchToBestView();
        }
        public void Resize(int inputEditorWidth, int inputEditorHeight, int inputTetrisTemplateWidth, int inputTetrisTemplateHeight)
        {
            editorSize = new Vector(inputEditorWidth, inputEditorHeight);
            tetrisTemplateEditorSize = new Vector(inputTetrisTemplateWidth, inputTetrisTemplateHeight);
        }
        #region graph
        public GraphElement QueryPosition(Vector query)
        {
            foreach(Node node in Graph.Nodes)
            {
                Vector pos = new Vector(node.X, node.Y);
                if(Vector.PointDistance(query, pos) <= 0.15)
                {
                    return node;
                }
            }
            foreach(Edge edge in Graph.Edges)
            {
                Vector pos1 = new Vector(edge.Start.X, edge.Start.Y);
                Vector pos2 = new Vector(edge.End.X, edge.End.Y);
                if (Vector.SegmentDistance(query, pos1, pos2) <= 0.125)
                {
                    return edge;
                }
            }
            foreach(Face face in Graph.Faces)
            {
                Vector sum = Vector.Zero;
                foreach (Node node in face.Nodes)
                {
                    sum += new Vector(node.X, node.Y);
                }
                Vector pos = (sum / face.Nodes.Count);
                if (Vector.PointDistance(query, pos) <= 0.25)
                {
                    return face;
                }

            }
            return null;
        }

        internal void Scroll(int x, int y, int delta)
        {
            Vector screenPosition = new Vector(x, y);
            double deltaScale= Math.Exp(delta / 1000.0);
            Origin = (Origin - editorSize / 2) * deltaScale + editorSize / 2;
            Scale *= deltaScale;
        }

        internal bool MouseDown(int x, int y, MouseButtons button) // Return true if copy operation is performed
        {
            bool copyPerformed = false;
            if (HoveredObjects.Count > 0 &&  button != MouseButtons.Middle)
            {
                List<GraphElement> objectToKeep = new List<GraphElement>();
                foreach (GraphElement havoredObject in HoveredObjects)
                {
                    if(!SelectedObjects.Contains(havoredObject))
                    {
                        objectToKeep.Add(havoredObject);
                    }
                }
                SelectedObjects.Clear();
                if(button==MouseButtons.Right)
                {
                    if(objectToKeep.Count>0)
                    {
                        ChooseSampleDecorator(objectToKeep[0].Decorator, true);
                        copyPerformed = true;
                    }
                }
                else
                {
                    if (!PasteMode) // Selection mode
                    {
                        SelectedObjects.AddRange(objectToKeep);
                    }
                    else // Paste mode
                    {
                        foreach (GraphElement element in objectToKeep)
                        {
                            ApplyDecoratorToObject(SampleDecorator, element);
                        }
                    }
                }
                HoveredObjects.Clear();
                if(SelectedObjects.Count>0)
                {
                    TetrisIndexToTemplateView(SelectedObjects[0].Decorator);
                }
            }
            else
            {
                mouseDownPosition = new Vector(x, y);
                IsDragging = true;
            }
            return copyPerformed;
        }

        private void ApplyDecoratorToObject(Decorator decorator, GraphElement element)
        {
            if(decorator is null)
            {
                element.Decorator = null;
                return;
            }
            bool okay = (element is Node && decorator is INodeDecorable) ||
                (element is Edge && decorator is IEdgeDecorable) ||
                (element is Face && decorator is IFaceDecorable);
            if(okay)
            {
                element.Decorator = decorator.Clone() as Decorator;
            }
        }

        internal void MouseMove(int x, int y)
        {
            HoveredObjects.Clear();
            Vector mousePosition = new Vector(x, y);
            if (IsDragging)
            {
                Vector deltaPosition = mousePosition - mouseDownPosition;
                Origin += deltaPosition;
                mouseDownPosition = mousePosition;
            }
            else
            {
                GraphElement havoredObject = QueryPosition(mousePosition.MapFromScreen(Scale, Origin));
                if(havoredObject != null)
                {
                    HoveredObjects.Add(havoredObject);
                }
            }
        }

        internal void MouseUp(int x, int y, MouseButtons button)
        {
            Vector mousePosition = new Vector(x, y);
            if (IsDragging)
            {
                Vector deltaPosition = mousePosition - mouseDownPosition;
                Origin += deltaPosition;
                mouseDownPosition = mousePosition;
                IsDragging = false;
            }
            else
            {

            }
        }
        #endregion

        #region Tetris Template

        public double TetrisTemplateScale { get; private set; }
        public Vector TetrisTemplateOrigin { get; private set; }

        public void CalculateTetrisTemplateScaleAndOrigin(TetrisTemplate template)
        {
            double marginSize = 10;
            if (template.Shapes.Count == 0)
            {
                TetrisTemplateOrigin = Vector.Zero;
                TetrisTemplateScale = 10.0;
            }
            double minX = double.PositiveInfinity, minY = double.PositiveInfinity;
            double maxX = double.NegativeInfinity, maxY = double.NegativeInfinity;
            foreach (List<Node> shape in template.Shapes)
            {
                foreach (Node node in shape)
                {
                    minX = Math.Min(minX, node.X);
                    minY = Math.Min(minY, node.Y);
                    maxX = Math.Max(maxX, node.X);
                    maxY = Math.Max(maxY, node.Y);
                }
            }
            TetrisTemplateScale = Math.Min((tetrisTemplateEditorSize.Y - marginSize * 2) / (maxY - minY), (tetrisTemplateEditorSize.X - marginSize * 2) / (maxX - minX));
            TetrisTemplateOrigin = new Vector(-(minX + maxX) / 2 * TetrisTemplateScale + tetrisTemplateEditorSize.X / 2, -(minY + maxY) / 2 * TetrisTemplateScale + tetrisTemplateEditorSize.Y / 2);


        }

        public int QueryTetrisTemplatePosition(Vector query)
        {
            TetrisTemplate template = Graph.MetaData.TetrisTemplate;
            for (int k = 0; k < template.Shapes.Count; ++k)
            {
                List<Node> shape = template.Shapes[k];
                double totalAngle = 0.0;
                for(int i=0;i<shape.Count;++i)
                {
                    Node p0 = shape[i == 0 ? shape.Count - 1 : i - 1];
                    Node p1 = shape[i];
                    Vector v0 = new Vector(p0.X, p0.Y);
                    Vector v1 = new Vector(p1.X, p1.Y);
                    totalAngle += Vector.GetAngle(v0 - query, v1 - query);
                }
                if (totalAngle + 1e-6 >= 2 * Math.PI)
                    return k;
            }
            return -1;
        }

        internal void TetrisTemplateClick(int x, int y, MouseButtons button)
        {
            int tetrisTemplatePosition = QueryTetrisTemplatePosition(new Vector(x, y).MapFromScreen(TetrisTemplateScale, TetrisTemplateOrigin));
            if(tetrisTemplatePosition>=0)
            {
                SelectedTetrisShapes[tetrisTemplatePosition] = !SelectedTetrisShapes[tetrisTemplatePosition];
                if (SelectedObjects.Count>0)
                {
                    TemplateViewToTetrisIndex(SelectedObjects[0].Decorator);
                }
                else if(PasteMode)
                {
                    TemplateViewToTetrisIndex(SampleDecorator);
                }
            }
        }

        internal void TetrisIndexToTemplateView(Decorator decorator)
        {
            List<int> indexes;
            if (decorator is PuzzleGraph.Decorators.HollowTetrisDecorator hollowTetrisDecorator)
                indexes = hollowTetrisDecorator.Indexes;
            else if (decorator is PuzzleGraph.Decorators.TetrisDecorator tetrisDecorator)
                indexes = tetrisDecorator.Indexes;
            else
                return;
            SelectedTetrisShapes = new bool[SelectedTetrisShapes.Length];
            foreach (int index in indexes)
            {
                if (index < SelectedTetrisShapes.Length)
                    SelectedTetrisShapes[index] = true;

            }
        }
        internal void TemplateViewToTetrisIndex(Decorator decorator)
        {
            List<int> indexes;
            if (decorator is PuzzleGraph.Decorators.HollowTetrisDecorator hollowTetrisDecorator)
                indexes = hollowTetrisDecorator.Indexes;
            else if (decorator is PuzzleGraph.Decorators.TetrisDecorator tetrisDecorator)
                indexes = tetrisDecorator.Indexes;
            else
                return;
            indexes.Clear();
            for(int i=0;i<SelectedTetrisShapes.Length;++i)
            {
                if (SelectedTetrisShapes[i])
                    indexes.Add(i);
            }

        }
        #endregion
        internal void ChooseSampleDecorator(Decorator decorator, bool importTetris)
        {
            SelectedObjects.Clear();
            if(decorator is null)
            {
                SampleDecorator = null;
            }
            else
            {
                SampleDecorator = decorator.Clone() as Decorator;
                if (importTetris)
                    TetrisIndexToTemplateView(SampleDecorator);
                else
                    TemplateViewToTetrisIndex(SampleDecorator);
            }
            PasteMode = true;
        }

        internal void ClearSelectedDecorations()
        {
            foreach(GraphElement element in SelectedObjects)
            {
                element.Decorator = null;
            }
        }
        internal void SwitchToBestView()
        {
            if (Graph.Nodes.Count == 0)
                return;
            double minX = double.PositiveInfinity, minY = double.PositiveInfinity;
            double maxX = double.NegativeInfinity, maxY = double.NegativeInfinity;
            foreach (Node node in Graph.Nodes)
            {
                minX = Math.Min(minX, node.X);
                minY = Math.Min(minY, node.Y);
                maxX = Math.Max(maxX, node.X);
                maxY = Math.Max(maxY, node.Y);
            }
            double marginSize = editorSize.X > 150 && editorSize.Y > 150 ? 70 : 0;
            double bestScale = Math.Min((editorSize.X - marginSize * 2) / (maxX - minX), (editorSize.Y - marginSize * 2) / (maxY - minY));
            Vector bestOrigin = new Vector(-(minX + maxX) / 2 * bestScale + editorSize.X / 2, -(minY + maxY) / 2 * bestScale + editorSize.Y / 2);
            Scale = bestScale;
            Origin = bestOrigin;
        }

        internal void ExportToFile(string savePath)
        {
            EditView exportView = new EditView(Graph, Graph.MetaData.ExportWidth, Graph.MetaData.ExportHeight, (int)tetrisTemplateEditorSize.X, (int)tetrisTemplateEditorSize.Y);
            Bitmap bitmap = new Bitmap(Convert.ToInt32(Graph.MetaData.ExportWidth), Convert.ToInt32(Graph.MetaData.ExportHeight), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            PuzzleGraphRenderer renderer = new PuzzleGraphRenderer(g);
            renderer.Draw(exportView);
            bitmap.Save(savePath, ImageFormat.Png);

        }
    }
}
