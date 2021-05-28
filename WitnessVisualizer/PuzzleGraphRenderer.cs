using MathHelper;
using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitnessVisualizer
{
    class PuzzleGraphRenderer
    {
        Graphics graphics;
        public PuzzleGraphRenderer(Graphics inputGraphics)
        {
            graphics = inputGraphics;
        }
        void DrawNode(EditView view, Node node, Brush brush, float lineWidth)
        {
            Vector screenPosition = new Vector(node.X, node.Y).MapToScreen(view.Scale, view.Origin);
            graphics.FillEllipse(brush, new RectangleF((float)screenPosition.X - lineWidth / 2, (float)screenPosition.Y - lineWidth / 2, lineWidth, lineWidth));
        }
        void DrawEdge(EditView view, Edge edge, Pen pen)
        {
            Vector screenPosition1 = new Vector(edge.Start.X, edge.Start.Y).MapToScreen(view.Scale, view.Origin);
            Vector screenPosition2 = new Vector(edge.End.X, edge.End.Y).MapToScreen(view.Scale, view.Origin);
            if (edge.Decorator is PuzzleGraph.Decorators.BrokenDecorator)
            {
                Vector screenPosition3 = screenPosition1 * 0.6 + screenPosition2 * 0.4;
                Vector screenPosition4 = screenPosition1 * 0.4 + screenPosition2 * 0.6;
                graphics.DrawLine(pen, (float)screenPosition1.X, (float)screenPosition1.Y, (float)screenPosition3.X, (float)screenPosition3.Y);
                graphics.DrawLine(pen, (float)screenPosition2.X, (float)screenPosition2.Y, (float)screenPosition4.X, (float)screenPosition4.Y);
            }
            else
            {
                graphics.DrawLine(pen, (float)screenPosition1.X, (float)screenPosition1.Y, (float)screenPosition2.X, (float)screenPosition2.Y);
            }
        }
        public void Draw(EditView view)
        {
            Graph graph = view.Graph;
            float lineWidth = (float)(view.Scale * graph.MetaData.EdgeWidth);
            float faceCircleSize = (float)(view.Scale * (1 - graph.MetaData.EdgeWidth * 2) * 0.3);
            graphics.Clear(graph.MetaData.BackgroundColor);
            using (Pen edgePen = new Pen(graph.MetaData.ForegroundColor, lineWidth))
            using (Brush pointBrush = new SolidBrush(graph.MetaData.ForegroundColor))
            {
                foreach (Face face in graph.Faces)
                {
                    Vector sum = Vector.Zero;
                    foreach (Node node in face.Nodes)
                    {
                        sum += new Vector(node.X, node.Y);
                    }
                    Vector screenPosition = (sum / face.Nodes.Count).MapToScreen(view.Scale, view.Origin);
                    if(face.GraphElementColor!=Color.Transparent)
                    {
                        using(Brush brush=new SolidBrush(face.GraphElementColor))
                        {
                            graphics.FillPolygon(brush, face.Nodes.Select(node =>
                                new Vector(node.X, node.Y).MapToScreen(view.Scale, view.Origin).ToPoint()).ToArray());
                        }
                    }
                    if (face.Decorator is null)
                    {
                        if(view.IsDragging) // Debug paint
                            graphics.FillEllipse(pointBrush, new RectangleF((float)screenPosition.X - faceCircleSize / 2, (float)screenPosition.Y - faceCircleSize / 2, faceCircleSize, faceCircleSize));
                    }
                    else
                    {
                        double scale = face.Decorator is IUnifiedScaleDecorator ? view.Scale : view.Scale * (1 - graph.MetaData.EdgeWidth) * graph.MetaData.FaceDecorationScale;
                        DrawDecorator(face.Decorator, screenPosition, scale, view.Graph.MetaData, face.GraphElementColor, true);
                    }
                }
                foreach (Node node in graph.Nodes)
                {
                    if (view.IsDragging || !node.Hidden)
                        DrawNode(view, node, pointBrush, lineWidth);
                }
                foreach (Edge edge in graph.Edges)
                {
                    if(edge.GraphElementColor==Color.Transparent)
                    {
                        DrawEdge(view, edge, edgePen);
                    }
                }
            }
            foreach (Node node in graph.Nodes)
            {
                if (node.Decorator is PuzzleGraph.Decorators.StartDecorator || node.Decorator is PuzzleGraph.Decorators.EndDecorator)
                {
                    Vector screenPosition = new Vector(node.X, node.Y).MapToScreen(view.Scale, view.Origin);
                    double scale = node.Decorator is IUnifiedScaleDecorator ? view.Scale : view.Scale * graph.MetaData.EdgeWidth;
                    DrawDecorator(node.Decorator, screenPosition, scale, view.Graph.MetaData, view.Graph.MetaData.BackgroundColor, false);
                }
            }
            foreach (Edge edge in graph.Edges)
            {
                if (edge.Decorator is PuzzleGraph.Decorators.StartDecorator || edge.Decorator is PuzzleGraph.Decorators.EndDecorator)
                {
                    Vector screenPosition = new Vector((edge.Start.X + edge.End.X) / 2, (edge.Start.Y + edge.End.Y) / 2).MapToScreen(view.Scale, view.Origin);
                    double scale = edge.Decorator is IUnifiedScaleDecorator ? view.Scale : view.Scale * graph.MetaData.EdgeWidth;
                    DrawDecorator(edge.Decorator, screenPosition, scale, view.Graph.MetaData, view.Graph.MetaData.BackgroundColor, false);
                }
            }
            // Draw solutions
            foreach (Edge edge in graph.Edges)
            {
                if(edge.GraphElementColor != Color.Transparent)
                {
                    using (Pen edgePen = new Pen(edge.GraphElementColor, lineWidth))
                    using (Brush pointBrush = new SolidBrush(edge.GraphElementColor))
                    {
                        DrawEdge(view, edge, edgePen);
                        DrawNode(view, edge.Start, pointBrush, lineWidth);
                        DrawNode(view, edge.End, pointBrush, lineWidth);
                    }
                }
            }
            foreach (Node node in graph.Nodes)
            {
                if (node.Decorator != null && !(node.Decorator is PuzzleGraph.Decorators.EndDecorator) && !(node.Decorator is PuzzleGraph.Decorators.StartDecorator))
                {
                    Vector screenPosition = new Vector(node.X, node.Y).MapToScreen(view.Scale, view.Origin);
                    double scale = node.Decorator is IUnifiedScaleDecorator ? view.Scale : view.Scale * graph.MetaData.EdgeWidth;
                    DrawDecorator(node.Decorator, screenPosition, scale, view.Graph.MetaData, view.Graph.MetaData.BackgroundColor, false);
                }
            }
            foreach (Edge edge in graph.Edges)
            {
                if (edge.Decorator != null && !(edge.Decorator is PuzzleGraph.Decorators.BrokenDecorator) &&
                    !(edge.Decorator is PuzzleGraph.Decorators.EndDecorator) && !(edge.Decorator is PuzzleGraph.Decorators.StartDecorator))
                {
                    Vector screenPosition = new Vector((edge.Start.X + edge.End.X) / 2, (edge.Start.Y + edge.End.Y) / 2).MapToScreen(view.Scale, view.Origin);
                    double scale = edge.Decorator is IUnifiedScaleDecorator ? view.Scale : view.Scale * graph.MetaData.EdgeWidth;
                    DrawDecorator(edge.Decorator, screenPosition, scale, view.Graph.MetaData, view.Graph.MetaData.BackgroundColor, false);
                }
            }

            DrawSelectionBoxes(view, view.HoveredObjects, Color.DarkGreen, true);
            DrawSelectionBoxes(view, view.HoveredObjects, Color.LightGreen);
            DrawSelectionBoxes(view, view.SelectedObjects, Color.DarkGoldenrod, true);
            DrawSelectionBoxes(view, view.SelectedObjects, Color.Yellow);
            if (view.IsCreatingMode)
            {
                DrawCreatingModeLines(view, Color.DarkRed, false);
                DrawCreatingModeLines(view, Color.Red, false);
            }
        }

        public void DrawSelectionBoxes(EditView view, List<GraphElement> selectedObjects, Color color, bool skew=false)
        {
            Vector skewVector = skew ? new Vector(2.0, 2.0) : Vector.Zero;
            float width = skew ? 2.5f : 2f;
            float lineWidth = (float)(view.Scale * 0.175);
            using (Pen pen=new Pen(color, width))
            {
                foreach (object obj in selectedObjects)
                {
                    if (obj is Node node)
                    {
                        Vector screenPosition = new Vector(node.X, node.Y).MapToScreen(view.Scale, view.Origin) + skewVector;
                        graphics.DrawRectangle(pen, (float)screenPosition.X - lineWidth / 2, (float)screenPosition.Y - lineWidth / 2, lineWidth, lineWidth);
                    }
                    else if (obj is Edge edge)
                    {
                        Vector screenPosition1 = new Vector(edge.Start.X, edge.Start.Y).MapToScreen(view.Scale, view.Origin);
                        Vector screenPosition2 = new Vector(edge.End.X, edge.End.Y).MapToScreen(view.Scale, view.Origin);
                        Vector direction = screenPosition2 - screenPosition1;
                        if (direction.Length() < 1e-6)
                        {
                            graphics.DrawRectangle(pen, (float)screenPosition1.X - lineWidth / 2, (float)screenPosition1.Y - lineWidth / 2, lineWidth, lineWidth);
                        }
                        else
                        {
                            direction = direction / direction.Length();
                            Vector crossDir = new Vector(direction.Y, -direction.X);
                            Vector p1 = screenPosition1 - ( + crossDir) * lineWidth / 2 + skewVector;
                            Vector p2 = screenPosition1 - ( - crossDir) * lineWidth / 2 + skewVector;
                            Vector p3 = screenPosition2 + ( + crossDir) * lineWidth / 2 + skewVector;
                            Vector p4 = screenPosition2 + ( - crossDir) * lineWidth / 2 + skewVector;
                            graphics.DrawLines(pen, new PointF[] { p1.ToPoint(), p2.ToPoint(), p3.ToPoint(), p4.ToPoint(), p1.ToPoint() });
                        }
                    }
                    else if (obj is Face face)
                    {
                        graphics.DrawClosedCurve(pen, face.Nodes.Select(item => (new Vector(item.X, item.Y).MapToScreen(view.Scale, view.Origin) + skewVector).ToPoint()).ToArray(), 0.0f,
                            System.Drawing.Drawing2D.FillMode.Alternate);
                    }
                    else
                    {
                        throw new NotSupportedException();
                    }
                }
            }
        }

        public void DrawDecorator(Decorator decorator, Vector centerPosition, double scale, MetaData metaData, Color backgroudColor, bool isFaceScale)
        {
            if (backgroudColor == Color.Transparent)
                backgroudColor = metaData.BackgroundColor;
            graphics.TranslateTransform((float)centerPosition.X, (float)centerPosition.Y);
            if (decorator is TransformableDecorator transformableDecorator)
            {
                graphics.TranslateTransform((float)(transformableDecorator.DeltaX * scale),
                    (float)(transformableDecorator.DeltaY * scale));
                graphics.RotateTransform((float)transformableDecorator.Angle);
                double extraScale = transformableDecorator.ExtraScale <= 0.0 ? 1.0 : transformableDecorator.ExtraScale;
                graphics.ScaleTransform((float)extraScale, (float)extraScale);
            }
            if (decorator is PuzzleGraph.Decorators.EliminatorDecorator elimatorDecorator)
            {
                double eliminatorLength = 0.200;
                float thickness = (float)(0.115*scale);
                Vector[] endDirections = new Vector[] { new Vector(0.0, -1.0), new Vector(-0.8660254, 0.5), new Vector(0.8660254, 0.5) };
                using(Pen pen=new Pen(elimatorDecorator.Color,thickness))
                {
                    foreach (Vector endDirection in endDirections)
                    {
                        graphics.DrawLine(pen,
                            Vector.Zero.MapToScreen(scale, Vector.Zero).ToPoint(),
                            (endDirection * eliminatorLength).MapToScreen(scale, Vector.Zero).ToPoint());
                    }
                }
            }
            else if(decorator is PuzzleGraph.Decorators.SquareDecorator squareDecorator)
            {
                double circleRadius = 0.191;
                double mappingCircleRadius = circleRadius * scale;
                double distance = 0.067;
                using(Brush brush=new SolidBrush(squareDecorator.Color))
                {

                    graphics.FillEllipse(brush, new Vector(distance, distance).MapToScreen(scale, Vector.Zero).ToCircleBoundingBox(mappingCircleRadius));
                    graphics.FillEllipse(brush, new Vector(distance, -distance).MapToScreen(scale, Vector.Zero).ToCircleBoundingBox(mappingCircleRadius));
                    graphics.FillEllipse(brush, new Vector(-distance, distance).MapToScreen(scale, Vector.Zero).ToCircleBoundingBox(mappingCircleRadius));
                    graphics.FillEllipse(brush, new Vector(-distance, -distance).MapToScreen(scale, Vector.Zero).ToCircleBoundingBox(mappingCircleRadius));
                    graphics.FillRectangle(brush, Vector.ToRectangleF(new Vector(-distance - circleRadius, -distance).MapToScreen(scale, Vector.Zero),
                                                                      new Vector(distance + circleRadius, distance).MapToScreen(scale, Vector.Zero)));
                    graphics.FillRectangle(brush, Vector.ToRectangleF(new Vector(-distance, -distance - circleRadius).MapToScreen(scale, Vector.Zero),
                                                                      new Vector(distance, distance + circleRadius).MapToScreen(scale, Vector.Zero)));
                }
            }
            else if (decorator is PuzzleGraph.Decorators.StarDecorator starDecorator)
            {
                double distance = 0.194;
                double skewDistance = distance * 0.7071068;
                using(Pen pen=new Pen(starDecorator.Color,(float)(distance*2*scale)))
                {
                    graphics.DrawLine(pen,
                        new Vector(-distance, 0).MapToScreen(scale, Vector.Zero).ToPoint(),
                        new Vector(distance, 0).MapToScreen(scale, Vector.Zero).ToPoint());
                    graphics.DrawLine(pen,
                        new Vector(skewDistance, -skewDistance).MapToScreen(scale, Vector.Zero).ToPoint(),
                        new Vector(-skewDistance, skewDistance).MapToScreen(scale, Vector.Zero).ToPoint());

                }
            }
            else if(decorator is PuzzleGraph.Decorators.TriangleDecorator triangleDecorator)
            {
                double length = 0.2;
                double distance = 0.05;
                double height = 0.175;
                int levels = (triangleDecorator.Count - 1) / 3 + 1;
                int[] numbersPerlevel = new int[levels];
                int left = triangleDecorator.Count;
                for (int i=0;i<levels;++i)
                {
                    numbersPerlevel[i] = left <= 3 ? left : left == 4 ? 2 : 3;
                    left -= numbersPerlevel[i];
                }
                using (Brush brush=new SolidBrush(triangleDecorator.Color))
                {
                    double totalHeight = height * levels + distance * (levels - 1);
                    double currentHeight = totalHeight / 2;
                    for (int level = 0; level < levels; ++level)
                    {
                        double totalWidth = length * numbersPerlevel[level] + distance * (numbersPerlevel[level] - 1);
                        Vector p1 = new Vector(-totalWidth / 2, currentHeight);
                        Vector p2 = new Vector(-totalWidth / 2 + length / 2, currentHeight - height);
                        Vector p3 = new Vector(-totalWidth / 2 + length, currentHeight);
                        for (int i = 0; i < numbersPerlevel[level]; ++i)
                        {
                            graphics.FillPolygon(brush, new PointF[] {
                                p1.MapToScreen(scale,Vector.Zero).ToPoint(),
                                p2.MapToScreen(scale,Vector.Zero).ToPoint(),
                                p3.MapToScreen(scale,Vector.Zero).ToPoint(),
                                p1.MapToScreen(scale,Vector.Zero).ToPoint(),
                            });
                            p1 += new Vector(length + distance, 0);
                            p2 += new Vector(length + distance, 0);
                            p3 += new Vector(length + distance, 0);
                        }
                        currentHeight -= height + distance;
                    }
                }
            }
            else if (decorator is PuzzleGraph.Decorators.ArrowDecorator arrowDecorator)
            {
                double width = 0.3;
                double thickness = 0.08;
                double delta_height = thickness * 1.414213562;
                double arrow_distance = 0.08;
                double bar_length = 0.4;
                double head_height = 0.3 - thickness / 2;
                List<PointF> points = new List<PointF>();
                double current_height = bar_length;
                points.Add(new Vector(0, current_height + thickness * head_height / (2 * width)).MapToScreen(scale, Vector.Zero).ToPoint());
                for (int i = 0; i < arrowDecorator.Count; ++i)
                {
                    points.Add(new Vector(-width, current_height - head_height).MapToScreen(scale, Vector.Zero).ToPoint());
                    current_height -= delta_height;
                    points.Add(new Vector(-width, current_height - head_height).MapToScreen(scale, Vector.Zero).ToPoint());
                    points.Add(new Vector(-thickness / 2, current_height).MapToScreen(scale, Vector.Zero).ToPoint());
                    current_height -= arrow_distance;
                    points.Add(new Vector(-thickness / 2, current_height).MapToScreen(scale, Vector.Zero).ToPoint());
                }
                points.Add(new Vector(-thickness / 2, -bar_length).MapToScreen(scale, Vector.Zero).ToPoint());
                points.Add(new Vector(thickness / 2, -bar_length).MapToScreen(scale, Vector.Zero).ToPoint());
                for (int i = 0; i < arrowDecorator.Count; ++i)
                {
                    points.Add(new Vector(thickness / 2, current_height).MapToScreen(scale, Vector.Zero).ToPoint());
                    current_height += arrow_distance;
                    points.Add(new Vector(thickness / 2, current_height).MapToScreen(scale, Vector.Zero).ToPoint());
                    points.Add(new Vector(width, current_height - head_height).MapToScreen(scale, Vector.Zero).ToPoint());
                    current_height += delta_height;
                    points.Add(new Vector(width, current_height - head_height).MapToScreen(scale, Vector.Zero).ToPoint());
                }
                using (Brush brush = new SolidBrush(arrowDecorator.Color))
                {
                    graphics.FillPolygon(brush, points.ToArray());
                }
            }
            else if(decorator is PuzzleGraph.Decorators.TetrisDecorator)
            {
                DrawTetris(graphics, decorator, Vector.Zero, scale, metaData, backgroudColor);
            }
            else if (decorator is PuzzleGraph.Decorators.HollowTetrisDecorator)
            {
                DrawTetris(graphics, decorator, Vector.Zero, scale, metaData, backgroudColor);
            }
            else if (decorator is PuzzleGraph.Decorators.CircleDecorator circleDecorator)
            {
                double radius = 0.35;
                using (Brush brush = new SolidBrush(circleDecorator.Color))
                {
                    graphics.FillEllipse(brush, Vector.Zero.ToCircleBoundingBox(radius * scale));
                }
            }
            else if (decorator is PuzzleGraph.Decorators.RingDecorator ringDecorator)
            {
                double radius = 0.35;
                double innerRadius = 0.25;
                using (Brush brush = new SolidBrush(ringDecorator.Color))
                {
                    graphics.FillEllipse(brush, Vector.Zero.ToCircleBoundingBox(radius * scale));
                }
                using (Brush brush = new SolidBrush(backgroudColor))
                {
                    graphics.FillEllipse(brush, Vector.Zero.ToCircleBoundingBox(innerRadius * scale));
                }
            }
            else if (decorator is PuzzleGraph.Decorators.TextDecorator textDecorator)
            {
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                using (Brush brush=new SolidBrush(textDecorator.Color))
                {
                    Font originalFont = textDecorator.Font;
                    if(originalFont is null)
                    {
                        originalFont = SystemFonts.DefaultFont;
                    }
                    using (Font font = new Font(originalFont.FontFamily, (float)(originalFont.Size * scale / 20),
                        originalFont.Style, originalFont.Unit, originalFont.GdiCharSet, originalFont.GdiVerticalFont))
                    {
                        SizeF size = graphics.MeasureString(textDecorator.Text, font);
                        graphics.DrawString(textDecorator.Text, font, brush,
                             - size.Width / 2, - size.Height / 2);
                    }
                }
            }
            else if(decorator is PuzzleGraph.Decorators.PointDecorator pointDecorator)
            {
                double radius = 0.375;
                double width = 0.4330127; // radius * 2 / sqrt(3)
                double x2 = 0.3247595; // radius * sqrt(3)/2
                using (Pen pen = new Pen(pointDecorator.Color, (float)(width * scale)))
                {
                    graphics.DrawLine(pen,
                        new Vector(0, -radius).MapToScreen(scale, Vector.Zero).ToPoint(),
                        new Vector(0, radius).MapToScreen(scale, Vector.Zero).ToPoint());
                    graphics.DrawLine(pen,
                        new Vector(-x2, radius / 2).MapToScreen(scale, Vector.Zero).ToPoint(),
                        new Vector(x2, -radius / 2).MapToScreen(scale, Vector.Zero).ToPoint());
                    graphics.DrawLine(pen,
                        new Vector(x2, radius / 2).MapToScreen(scale, Vector.Zero).ToPoint(),
                        new Vector(-x2, -radius / 2).MapToScreen(scale, Vector.Zero).ToPoint());
                }
            }
            else if(decorator is PuzzleGraph.Decorators.StartDecorator startDecorator)
            {
                double radius = 2.55 / 2;
                using (Brush brush = new SolidBrush(
                    startDecorator.Color != Color.Transparent ? startDecorator.Color : metaData.ForegroundColor))
                {
                    graphics.FillEllipse(brush, Vector.Zero.ToCircleBoundingBox(radius * scale));
                }
            }
            else if (decorator is PuzzleGraph.Decorators.EndDecorator endDecorator)
            {
                using (Pen pen = new Pen(
                    endDecorator.Color != Color.Transparent ? endDecorator.Color : metaData.ForegroundColor, (float)scale)
                {
                    EndCap = System.Drawing.Drawing2D.LineCap.Round,
                    StartCap = System.Drawing.Drawing2D.LineCap.Round
                })
                {
                    double angle = endDecorator.Angle / 180 * Math.PI;
                    graphics.DrawLine(pen, Vector.Zero.ToPoint(),
                        new Vector(endDecorator.Length*Math.Cos(angle), endDecorator.Length * Math.Sin(angle)).MapToScreen(scale/metaData.EdgeWidth, Vector.Zero).ToPoint());
                }
            }
            else if(decorator is PuzzleGraph.Decorators.BrokenDecorator) // Only for illustration purpose
            {
                using (Pen pen = new Pen(metaData.ForegroundColor, (float)scale))
                {
                    graphics.DrawLine(pen,
                        new Vector(-0.5, 0.0).MapToScreen(scale / metaData.EdgeWidth, Vector.Zero).ToPoint(),
                        new Vector(-0.1, 0.0).MapToScreen(scale / metaData.EdgeWidth, Vector.Zero).ToPoint());
                    graphics.DrawLine(pen,
                        new Vector(0.5, 0.0).MapToScreen(scale / metaData.EdgeWidth, Vector.Zero).ToPoint(),
                        new Vector(0.1, 0.0).MapToScreen(scale / metaData.EdgeWidth, Vector.Zero).ToPoint());

                }
            }
            else if(decorator is PuzzleGraph.Decorators.SymmetryPuzzleDecorator symmetryPuzzleDecorator)
            {
                double unifiedScale = scale;
                double lineWidth = unifiedScale * 0.1;
                for (int lineGroup = 0; lineGroup <= 1; ++lineGroup)
                {
                    double xMul = lineGroup == 0 ? 1 : -1;
                    double yMul = lineGroup == 0 && symmetryPuzzleDecorator.IsRotational ? 1 : -1;
                    Color color = lineGroup == 0 ? metaData.LineColor : symmetryPuzzleDecorator.SecondLineColor;
                    using (Pen pen = new Pen(color, (float)lineWidth)
                    {
                        EndCap = System.Drawing.Drawing2D.LineCap.Round,
                        StartCap = System.Drawing.Drawing2D.LineCap.Round
                    })
                    {
                        graphics.DrawLine(pen, new Vector(-0.15 * xMul, -0.2 * yMul).MapToScreen(unifiedScale, Vector.Zero).ToPoint(),
                            new Vector(-0.15 * xMul, 0.2 * yMul).MapToScreen(unifiedScale, Vector.Zero).ToPoint());
                        graphics.DrawLine(pen, new Vector(-0.15 * xMul, 0.2 * yMul).MapToScreen(unifiedScale, Vector.Zero).ToPoint(),
                            new Vector(-0.3 * xMul, 0.2 * yMul).MapToScreen(unifiedScale, Vector.Zero).ToPoint());
                    }
                    graphics.FillEllipse(new SolidBrush(color),
                        new Vector(-0.15 * xMul, -0.2 * yMul).MapToScreen(unifiedScale, Vector.Zero).ToCircleBoundingBox(lineWidth));
                }
                graphics.FillEllipse(Brushes.Black, Vector.Zero.MapToScreen(unifiedScale, Vector.Zero).ToCircleBoundingBox(lineWidth * 0.3));
            }
            else if (decorator is PuzzleGraph.Decorators.ParallelPuzzleDecorator parallelDecorator)
            {
                double unifiedScale = scale;
                double lineWidth = unifiedScale * 0.1;
                for (int lineGroup = 0; lineGroup <= 1; ++lineGroup)
                {
                    double xTranslation = lineGroup == 0 ? 0 : parallelDecorator.TranslationX;
                    double yTranslation = lineGroup == 0 ? 0 : parallelDecorator.TranslationY;
                    Color color = lineGroup == 0 ? metaData.LineColor : parallelDecorator.SecondLineColor;
                    using (Pen pen = new Pen(color, (float)lineWidth)
                    {
                        EndCap = System.Drawing.Drawing2D.LineCap.Round,
                        StartCap = System.Drawing.Drawing2D.LineCap.Round
                    })
                    {
                        graphics.DrawLine(pen, new Vector(-0.15 + xTranslation, -0.2 + yTranslation).MapToScreen(unifiedScale, Vector.Zero).ToPoint(),
                            new Vector(-0.15 + xTranslation, 0.2 + yTranslation).MapToScreen(unifiedScale, Vector.Zero).ToPoint());
                        graphics.DrawLine(pen, new Vector(-0.15 + xTranslation, 0.2 + yTranslation).MapToScreen(unifiedScale, Vector.Zero).ToPoint(),
                            new Vector(-0.3 + xTranslation, 0.2 + yTranslation).MapToScreen(unifiedScale, Vector.Zero).ToPoint());
                    }
                    graphics.FillEllipse(new SolidBrush(color),
                        new Vector(-0.15 + xTranslation, -0.2 + yTranslation).MapToScreen(unifiedScale, Vector.Zero).ToCircleBoundingBox(lineWidth));
                    graphics.FillEllipse(Brushes.Black, new Vector(xTranslation, yTranslation).MapToScreen(unifiedScale, Vector.Zero).ToCircleBoundingBox(lineWidth * 0.3));
                }
            }
            else if (decorator is PuzzleGraph.Decorators.ThreeWayPuzzleDecorator threeWayPuzzleDecorator)
            {
                double unifiedScale = isFaceScale ? scale : scale / metaData.EdgeWidth * (1 - metaData.EdgeWidth) * metaData.FaceDecorationScale;
                double lineWidth = unifiedScale * 0.1;
                for (int lineGroup = 0; lineGroup <= 2; ++lineGroup)
                {
                    Color color = lineGroup == 0 ? metaData.LineColor : lineGroup == 1 ? 
                        threeWayPuzzleDecorator.SecondLineColor : threeWayPuzzleDecorator.ThirdLineColor;
                    using (Pen pen = new Pen(color, (float)lineWidth)
                    {
                        EndCap = System.Drawing.Drawing2D.LineCap.Round,
                        StartCap = System.Drawing.Drawing2D.LineCap.Round
                    })
                    {
                        graphics.DrawLine(pen, new Vector(-0.15, -0.2).MapToScreen(unifiedScale, Vector.Zero).ToPoint(),
                            new Vector(-0.15, 0.0).MapToScreen(unifiedScale, Vector.Zero).ToPoint());
                        graphics.DrawLine(pen, new Vector(-0.15, 0.0).MapToScreen(unifiedScale, Vector.Zero).ToPoint(),
                            new Vector(-0.15 - 0.1732, 0.1).MapToScreen(unifiedScale, Vector.Zero).ToPoint());
                    }
                    graphics.FillEllipse(new SolidBrush(color),
                        new Vector(-0.15, -0.2).MapToScreen(unifiedScale, Vector.Zero).ToCircleBoundingBox(lineWidth));
                    graphics.RotateTransform(120);
                }
                graphics.FillEllipse(Brushes.Black, Vector.Zero.MapToScreen(unifiedScale, Vector.Zero).ToCircleBoundingBox(lineWidth * 0.3));
            }
            else if(decorator is PuzzleGraph.Decorators.CombinedDecorator combinedDecorator)
            {
                graphics.ResetTransform();
                DrawDecorator(combinedDecorator.First, centerPosition, scale, metaData, backgroudColor, isFaceScale);
                DrawDecorator(combinedDecorator.Second, centerPosition, scale, metaData, backgroudColor, isFaceScale);
            }
            graphics.ResetTransform();
        }

        void DrawTetris(Graphics graphics, Decorator decorator, Vector centerPosition, double scale, MetaData metaData, Color backgroudColor)
        {
            double angle;
            List<List<Node>> shapes;
            Color color;
            bool isHollow;
            double margin;
            double hollowThickness;
            if (decorator is PuzzleGraph.Decorators.TetrisDecorator tetrisDecorator)
            {
                shapes = tetrisDecorator.Shapes;
                color = tetrisDecorator.Color;
                isHollow = false;
                margin = tetrisDecorator.MarginSize;
                hollowThickness = 0.19;
            }
            else if (decorator is PuzzleGraph.Decorators.HollowTetrisDecorator hollowTetrisDecorator)
            {
                shapes = hollowTetrisDecorator.Shapes;
                color = hollowTetrisDecorator.Color;
                isHollow = true;
                margin = hollowTetrisDecorator.MarginSize;
                hollowThickness = hollowTetrisDecorator.BorderSize;
            }
            else throw new NotSupportedException();
            if (shapes.Count == 0)
            {
                return;
            }
            double minX = double.PositiveInfinity, minY = double.PositiveInfinity;
            double maxX = double.NegativeInfinity, maxY = double.NegativeInfinity;
            foreach (List<Node> shape in shapes)
            {
                foreach (Node node in shape)
                {
                    minX = Math.Min(minX, node.X);
                    minY = Math.Min(minY, node.Y);
                    maxX = Math.Max(maxX, node.X);
                    maxY = Math.Max(maxY, node.Y);
                }
            }
            Vector selfBias = new Vector((minX + maxX) / 2, (minY + maxY) / 2);
            double totalScale = metaData.TetrisScale * scale;
            float compoundPercent = (float)(1 - (hollowThickness + margin / 2) / (2 * (hollowThickness + margin)));
            // Well, there are really some strange things here, which I assume is Winform's bug
            // Inset & CompoundArray both have rendering issues in this case, but CompoundArray is better
            // Inset will cause antialiasing to go away & CompoundArray will cause strage random lines in the corner
            using (Pen pen = new Pen(color, (float)((hollowThickness + margin) * totalScale)) {
                CompoundArray = new float[] { compoundPercent, 1.0f}})
            using (Brush brush = new SolidBrush(color))
            {
                foreach (List<Node> shape in shapes)
                {
                    PointF[] points = shape.Select(node => (new Vector(node.X, node.Y) - selfBias)
                    .MapToScreen(totalScale, centerPosition).ToPoint()).ToArray();
                    if (isHollow)
                        graphics.DrawClosedCurve(pen, points, 0.0f, System.Drawing.Drawing2D.FillMode.Alternate);
                    else
                        graphics.FillClosedCurve(brush, points, System.Drawing.Drawing2D.FillMode.Alternate, 0.0f);
                }
            }
            if (margin > 0)
            {
                using (Pen pen = new Pen(backgroudColor, (float)(margin * totalScale)))
                {
                    foreach (List<Node> shape in shapes)
                    {
                        PointF[] points = shape.Select(node => (new Vector(node.X, node.Y) - selfBias)
                            .MapToScreen(totalScale, centerPosition).ToPoint()).ToArray();
                        graphics.DrawClosedCurve(pen, points, 0.0f, System.Drawing.Drawing2D.FillMode.Alternate);

                    }
                }
            }
        }

        private void DrawCreatingModeLines(EditView view, Color color, bool skew)
        {
            Vector skewVector = skew ? new Vector(2.0, 2.0) : Vector.Zero;
            float width = skew ? 2.5f : 2f;
            float selectionIconSize = 5;
            List<Node> drawNodes = new List<Node>();
            drawNodes.AddRange(view.CreatingNodes);
            if (view.HoveredCreatingNode != null)
                drawNodes.Add(view.HoveredCreatingNode);
            PointF[] points = drawNodes.Select(node => (new Vector(node.X, node.Y).MapToScreen(view.Scale, view.Origin) + skewVector).ToPoint()).ToArray();

            using (Pen pen = new Pen(color, width) { LineJoin = System.Drawing.Drawing2D.LineJoin.Round })
            {
                foreach(Node node in drawNodes)
                {
                    RectangleF boundingBox = (new Vector(node.X, node.Y).MapToScreen(view.Scale, view.Origin) + skewVector).ToCircleBoundingBox(selectionIconSize);
                    graphics.DrawEllipse(pen, boundingBox);
                }
                if (points.Length > 1)
                {
                    graphics.DrawPolygon(pen, points);
                }
            }
            if (points.Length > 2 && !skew)
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(50, color)))
                {
                    graphics.FillPolygon(brush, points);
                }
            }
        }
    }
}
