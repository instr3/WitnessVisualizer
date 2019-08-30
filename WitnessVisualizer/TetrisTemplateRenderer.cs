using MathHelper;
using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitnessVisualizer
{
    class TetrisTemplateRenderer
    {
        Graphics graphics;
        double borderPercent = 0.1;
        public TetrisTemplateRenderer(Graphics inputGraphics)
        {
            graphics = inputGraphics;
        }
        public void Draw(EditView view)
        {
            Graph graph = view.Graph;
            TetrisTemplate template = graph.MetaData.TetrisTemplate;
            double scale = view.TetrisTemplateScale;
            Vector origin = view.TetrisTemplateOrigin;
            graphics.Clear(graph.MetaData.BackgroundColor);
            if (template.Shapes.Count == 0)
                return;
            using (Brush activatedBrush = new SolidBrush(Color.Yellow), deactivatedBrush = new SolidBrush(graph.MetaData.ForegroundColor))
            {
                for (int k = 0; k < template.Shapes.Count; ++k)
                {
                    List<Node> shape = template.Shapes[k];
                    graphics.FillClosedCurve(view.SelectedTetrisShapes[k] ? activatedBrush : deactivatedBrush,
                        shape.Select(node => new Vector(node.X, node.Y).MapToScreen(scale, origin).ToPoint()).ToArray(),
                        System.Drawing.Drawing2D.FillMode.Alternate, 0.0f);
                }
            }
            float penWidth = (float)(borderPercent * scale);
            using (Pen pen = new Pen(graph.MetaData.BackgroundColor, penWidth ))
            {
                for (int k = 0; k < template.Shapes.Count; ++k)
                {
                    List<Node> shape = template.Shapes[k];
                    graphics.DrawClosedCurve(pen,
                        shape.Select(node => new Vector(node.X, node.Y).MapToScreen(scale, origin).ToPoint()).ToArray(),
                        0.0f, System.Drawing.Drawing2D.FillMode.Alternate);
                }
            }
        }
    }
}
