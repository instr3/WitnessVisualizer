using MathHelper;
using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        bool isDragging;
        Vector mouseDownPosition;
        Vector editorSize;
        Vector tetrisTemplateEditorSize;
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

        internal void MouseDown(int x, int y, MouseButtons button)
        {
            if (HoveredObjects.Count > 0)
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
                SelectedObjects.AddRange(objectToKeep);
                HoveredObjects.Clear();
            }
            else
            {
                mouseDownPosition = new Vector(x, y);
                isDragging = true;
            }

        }

        internal void MouseMove(int x, int y)
        {
            HoveredObjects.Clear();
            Vector mousePosition = new Vector(x, y);
            if (isDragging)
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
            if (isDragging)
            {
                Vector deltaPosition = mousePosition - mouseDownPosition;
                Origin += deltaPosition;
                mouseDownPosition = mousePosition;
                isDragging = false;
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
            TetrisTemplateOrigin = new Vector(-minX * TetrisTemplateScale + marginSize, -minY * TetrisTemplateScale + marginSize);

        }

        public int QueryTetrisTemplatePosition(Vector query)
        {
            TetrisTemplate template = Graph.MetaData.TetrisTemplate;
            for (int k = 0; k < template.Shapes.Count; ++k)
            {
                List<Node> shape = template.Shapes[k];
                double totalAngel = 0.0;
                for(int i=0;i<shape.Count;++i)
                {
                    Node p0 = shape[i == 0 ? shape.Count - 1 : i - 1];
                    Node p1 = shape[i];
                    Vector v0 = new Vector(p0.X, p0.Y);
                    Vector v1 = new Vector(p1.X, p1.Y);
                    totalAngel += Vector.GetAngel(v0 - query, v1 - query);
                }
                if (totalAngel + 1e-6 >= 2 * Math.PI)
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
            }
        }
        #endregion
    }
}
