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
        public bool IsCreatingMode { get; private set; }
        public List<Node> CreatingNodes { get; private set; } = new List<Node>();
        public Node HoveredCreatingNode { get; private set; }
        Vector mouseDownPosition;
        Vector editorSize;
        Vector tetrisTemplateEditorSize;
        public Decorator SampleDecorator { get; private set; }
        public bool PasteMode { get; set; }
        public bool ColorPaintingMode { get; set; }
        public PaintingModeControl PaintingModeControl { get; private set; }
        public List<GraphElement> SelectedObjects { get; private set; } = new List<GraphElement>();
        List<Node> nodesToMove;
        public List<GraphElement> HoveredObjects { get; private set; } = new List<GraphElement>();
        public bool[] SelectedTetrisShapes { get; private set; }
        public EditManager<Graph> GraphEditManager { get; private set; }
        public EditView(Graph inputGraph, int inputEditorWidth, int inputEditorHeight, int inputTetrisTemplateWidth, int inputTetrisTemplateHeight)
        {
            editorSize = new Vector(inputEditorWidth, inputEditorHeight);
            tetrisTemplateEditorSize = new Vector(inputTetrisTemplateWidth, inputTetrisTemplateHeight);
            Graph = inputGraph;
            UpdateTetrisTemplateScaleAndOrigin(Graph.MetaData.TetrisTemplate);
            SwitchToBestView();
            GraphEditManager = new EditManager<Graph>();
            PaintingModeControl = new PaintingModeControl();
        }
        public void Resize(int inputEditorWidth, int inputEditorHeight, int inputTetrisTemplateWidth, int inputTetrisTemplateHeight)
        {
            editorSize = new Vector(inputEditorWidth, inputEditorHeight);
            tetrisTemplateEditorSize = new Vector(inputTetrisTemplateWidth, inputTetrisTemplateHeight);
            UpdateTetrisTemplateScaleAndOrigin(Graph.MetaData.TetrisTemplate);
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

        internal bool MouseDown(int x, int y, MouseButtons button, bool ctrlKey, bool altKey, bool shiftKey) // Return true if copy operation is performed
        {
            bool copyPerformed = false;
            if(IsCreatingMode)
            {
                if(button == MouseButtons.Left) // Add
                {
                    Node addNode;
                    if (HoveredObjects.Count > 0 && HoveredObjects[0] is Node node)
                    {
                        if (CreatingNodes.Contains(node))
                        {
                            if (CreatingNodes.Last() == node)
                            {
                                CreatingNodes.RemoveAt(CreatingNodes.Count - 1);
                            }
                            else if(CreatingNodes.First() == node)
                            {
                                SubmitCreatingNodes();
                            }
                            return false;
                        }
                        addNode = node;
                    }
                    else
                    {
                        Vector pos = new Vector(x, y).MapFromScreen(Scale,Origin);
                        addNode = new Node(pos.X, pos.Y);
                    }
                    CreatingNodes.Add(addNode);
                    return false;
                }
                else if (button == MouseButtons.Right) // Exit
                {
                    SubmitCreatingNodes();
                    return false;
                }
            }
            if (altKey && PasteMode && SampleDecorator != null) // Create and paste
            {
                GraphEditManager.BeforePreformEdit(Graph, "Create Graph Elements");
                Vector pos = new Vector(x, y).MapFromScreen(Scale, Origin);
                Node addNode = new Node(pos.X, pos.Y);
                addNode.Hidden = true;
                addNode.Decorator = SampleDecorator.Clone() as Decorator;
                if (!shiftKey && addNode.Decorator is TransformableDecorator transformableDecorator)
                {
                    transformableDecorator.ExtraScale = (1 - Graph.MetaData.EdgeWidth) / Graph.MetaData.EdgeWidth;
                }
                GraphManipulation.AddShape(Graph, new List<Node>() { addNode });
            }
            else if (HoveredObjects.Count > 0 && button != MouseButtons.Middle)
            {
                List<GraphElement> objectToKeep = new List<GraphElement>();
                if(ctrlKey || shiftKey)
                {
                    foreach (GraphElement selectedObject in SelectedObjects)
                    {
                        if (shiftKey || !HoveredObjects.Contains(selectedObject))
                        {
                            objectToKeep.Add(selectedObject);
                        }
                    }
                }
                foreach (GraphElement havoredObject in HoveredObjects)
                {
                    if(!SelectedObjects.Contains(havoredObject))
                    {
                        objectToKeep.Add(havoredObject);
                    }
                }
                SelectedObjects.Clear();
                if (ColorPaintingMode) // Paint mode
                {
                    foreach (GraphElement element in objectToKeep)
                    {
                        Color TryApplyColor(Color oldColor, Color newColor, string hint)
                        {
                            if(oldColor!=newColor)
                            {
                                GraphEditManager.BeforePreformEdit(Graph, string.Format(Resources.Lang.Undo_Paint,hint,newColor.ToString()));
                            }
                            return newColor;
                        }
                        if (element is Node)
                        {
                            if (element.Decorator is PuzzleGraph.Decorators.StartDecorator startDecorator)
                            {
                                if (button == MouseButtons.Right) // Color picking
                                    PaintingModeControl.Color = startDecorator.Color;
                                else // Apply color
                                    startDecorator.Color = TryApplyColor(startDecorator.Color, PaintingModeControl.Color, "start point");
                            }
                            else if (element.Decorator is PuzzleGraph.Decorators.EndDecorator endDecorator)
                            {
                                if (button == MouseButtons.Right) // Color picking
                                    PaintingModeControl.Color = endDecorator.Color;
                                else // Apply color
                                    endDecorator.Color = TryApplyColor(endDecorator.Color, PaintingModeControl.Color, "end point");
                            }
                        }
                        else if (element is Face face)
                        {
                            if (button == MouseButtons.Right) // Color picking
                                PaintingModeControl.Color = face.GraphElementColor;
                            else // Apply color
                                face.GraphElementColor = TryApplyColor(face.GraphElementColor, PaintingModeControl.Color, "face");
                        }
                        else if (element is Edge edge)
                        {
                            if (button == MouseButtons.Right) // Color picking
                                PaintingModeControl.Color = edge.GraphElementColor;
                            else // Apply color
                                edge.GraphElementColor = TryApplyColor(edge.GraphElementColor, PaintingModeControl.Color, "edge");
                        }
                    }
                }
                else if (button==MouseButtons.Right) // Copy
                {
                    if(objectToKeep.Count>0)
                    {
                        if (ctrlKey && objectToKeep[0].Decorator is PuzzleGraph.Decorators.CombinedDecorator combinedDecorator) // Combine mode
                        {
                            ChooseSampleDecorator(combinedDecorator.Second, true);
                            objectToKeep[0].Decorator = combinedDecorator.First;
                        }
                        else
                        {
                            ChooseSampleDecorator(objectToKeep[0].Decorator, true);
                        }
                            
                        copyPerformed = true;
                    }
                }
                else
                {
                    if (!PasteMode) // Selection mode
                    {
                        SelectedObjects.AddRange(objectToKeep);
                        if (shiftKey)
                        {
                            nodesToMove = new List<Node>();
                            foreach(GraphElement element in SelectedObjects)
                            {
                                if (element is Node selectedNode)
                                {
                                    nodesToMove.Add(selectedNode);
                                }
                                else if (element is Edge selectedEdge)
                                {
                                    nodesToMove.Add(selectedEdge.Start);
                                    nodesToMove.Add(selectedEdge.End);
                                }
                                else if(element is Face selectedFace)
                                {
                                    nodesToMove.AddRange(selectedFace.Nodes);
                                }
                            }
                            if(nodesToMove.Count>0)
                            {
                                GraphEditManager.BeforePreformEdit(Graph, "Move Nodes");
                                ElementMoveStartPosition = new Vector(x, y);
                            }

                        }
                        else
                            ElementMoveStartPosition = null;
                    }
                    else // Paste mode
                    {
                        foreach (GraphElement element in objectToKeep)
                        {
                            if(ctrlKey && element.Decorator!=null) // Combine mode
                                CombineDecorators(SampleDecorator, element);
                            else
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
                GraphEditManager.BeforePreformEdit(Graph, "Remove Decorator");
                element.Decorator = null;
                return;
            }
            if(decorator.IsDecorableFor(element))
            {
                GraphEditManager.BeforePreformEdit(Graph, "Apply Decorator");
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
                if (ElementMoveStartPosition != null)
                {
                    Vector deltaPosition = mousePosition.MapFromScreen(Scale, Origin) - ElementMoveStartPosition.MapFromScreen(Scale, Origin);
                    // We do not guarantee that points in nodesToMove are unique
                    List<Vector> targetPos = nodesToMove.Select(node => new Vector(node.X, node.Y) + deltaPosition).ToList();
                    for (int i=0;i<nodesToMove.Count;++i)
                    {
                        nodesToMove[i].X = targetPos[i].X;
                        nodesToMove[i].Y = targetPos[i].Y;
                    }
                    ElementMoveStartPosition = mousePosition;
                    return;
                }
                Vector query = mousePosition.MapFromScreen(Scale, Origin);
                GraphElement havoredObject = QueryPosition(query);
                if(havoredObject != null)
                {
                    HoveredObjects.Add(havoredObject);
                }
                if (IsCreatingMode)
                {
                    if(havoredObject is Node node)
                    {
                        HoveredCreatingNode = node;
                    }
                    else
                    {
                        HoveredCreatingNode = new Node(query.X, query.Y);
                    }
                }
            }
        }

        internal void MouseUp(int x, int y, MouseButtons button)
        {
            ElementMoveStartPosition = null;
            Vector mousePosition = new Vector(x, y);
            if (IsDragging)
            {
                Vector deltaPosition = mousePosition - mouseDownPosition;
                Origin += deltaPosition;
                mouseDownPosition = mousePosition;
                IsDragging = false;
            }
        }
        #endregion

        #region Tetris Template

        public double TetrisTemplateScale { get; private set; }
        public Vector TetrisTemplateOrigin { get; private set; }
        public Vector ElementMoveStartPosition { get; private set; }

        public void UpdateTetrisTemplateScaleAndOrigin(TetrisTemplate template)
        {
            SelectedTetrisShapes = new bool[template.Shapes.Count];
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
                    GraphEditManager.BeforePreformEdit(Graph, "Tetris Decorator");
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
            if (decorator is PuzzleGraph.Decorators.AbstractTetrisDecorator tetris)
                indexes = tetris.Indexes;
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
            List<List<Node>> shapes;
            if (decorator is PuzzleGraph.Decorators.AbstractTetrisDecorator tetris)
            {
                indexes = tetris.Indexes;
                shapes = tetris.Shapes;
            }
            else return;
            indexes.Clear();
            shapes.Clear();
            TetrisTemplate template = Graph.MetaData.TetrisTemplate;
            for(int i=0;i<SelectedTetrisShapes.Length;++i)
            {
                if (SelectedTetrisShapes[i] && i < template.Shapes.Count)
                {
                    indexes.Add(i);
                    shapes.Add(template.Shapes[i].Select(node => new Node(node.X, node.Y)).ToList());
                }
            }

        }
        #endregion
        internal void ChooseSampleDecorator(Decorator decorator, bool alwaysImportTetris)
        {
            SelectedObjects.Clear();
            if(decorator is null)
            {
                SampleDecorator = null;
            }
            else
            {
                SampleDecorator = decorator.Clone() as Decorator;
                bool importTetris = alwaysImportTetris || TetrisTransferHelper.TetrisCompatible(Graph, decorator);
                if (importTetris)
                {
                    TetrisIndexToTemplateView(SampleDecorator);
                }
                else
                {
                    SelectedTetrisShapes = new bool[SelectedTetrisShapes.Length];
                    TetrisTransferHelper.ClearTetrisIndex(SampleDecorator);
                }
            }
            PasteMode = true;
            ColorPaintingMode = false;
        }

        internal void RegenerateTetrisTemplates()
        {
            Graph.MetaData.TetrisTemplate.Shapes.Clear();
            Graph.MetaData.TetrisTemplate.Shapes.AddRange(
                Graph.Faces.Select(face => face.Nodes.Select(node => new Node(node.X, node.Y)).ToList()));
            UpdateTetrisTemplateScaleAndOrigin(Graph.MetaData.TetrisTemplate);
        }

        internal void ClearSelectedDecorations()
        {
            GraphEditManager.BeforePreformEdit(Graph, "Clear Decorations");
            foreach (GraphElement element in SelectedObjects)
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
        void SubmitCreatingNodes()
        {
            GraphEditManager.BeforePreformEdit(Graph, "Create Graph Elements");
            GraphManipulation.AddShape(Graph, CreatingNodes);
            ExitCreatingMode();
            EnterCreatingMode();
        }

        internal void EnterCreatingMode()
        {
            SelectedObjects.Clear();
            CreatingNodes.Clear();
            HoveredCreatingNode = null;
            PasteMode = false;
            IsCreatingMode = true;
            ColorPaintingMode = false;
        }
        internal void ExitCreatingMode()
        {
            SelectedObjects.Clear();
            CreatingNodes.Clear();
            HoveredCreatingNode = null;
            IsCreatingMode = false;
        }

        internal void SetNewGraph(Graph graph)
        {
            SelectedObjects.Clear();
            HoveredObjects.Clear();
            CreatingNodes.Clear();
            HoveredCreatingNode = null;
            Graph = graph;
        }

        internal bool CombineDecorators(Decorator decorator, GraphElement graphElement)
        {
            if (graphElement.Decorator == null || decorator == null)
                return false;
            PuzzleGraph.Decorators.CombinedDecorator combinedDecorator = new PuzzleGraph.Decorators.CombinedDecorator();
            combinedDecorator.Second = decorator.Clone() as Decorator;
            combinedDecorator.First = graphElement.Decorator.Clone() as Decorator;
            if (combinedDecorator.IsDecorableFor(graphElement))
            {
                GraphEditManager.BeforePreformEdit(Graph, "Combine Decorators");
                graphElement.Decorator = combinedDecorator;
                return true;
            }
            else return false;

        }
        internal bool CombineDecorators(GraphElement graphElement1, GraphElement graphElement2)
        {
            if (graphElement1.Decorator == null || graphElement2.Decorator == null)
                return false;
            return CombineDecorators(graphElement1.Decorator, graphElement2);
        }
    }
}
