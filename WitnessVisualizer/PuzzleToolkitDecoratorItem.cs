using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathHelper;
using System.Drawing.Drawing2D;

namespace WitnessVisualizer
{
    public class PuzzleToolkitDecoratorItem : PuzzleToolkitItem
    {
        public Decorator Decorator { get; set; }
        private static MetaData metaData;
        public double AdditionalScale { get; set; }
        Image image;
        static PuzzleToolkitDecoratorItem()
        {
            metaData = new MetaData();
            metaData.BackgroundColor = Color.FromArgb(240, 240, 240);
            metaData.ForegroundColor = Color.Black;
            metaData.TetrisTemplate = new TetrisTemplate()
            {
                Shapes = new List<List<Node>>() {
                    new List<Node>() { new Node(1.0,1.0), new Node(2.0, 1.0), new Node(2.0,2.0), new Node(1.0, 2.0) }
                }
            };
        }
        public PuzzleToolkitDecoratorItem(string inputName, Decorator inputDecorator,double inputAdditionalScale=1.0)
        {
            Name = inputName;
            Decorator = inputDecorator;
            AdditionalScale = inputAdditionalScale;
        }

        private PuzzleToolkitDecoratorItem() { }

        public void Draw(Graphics graphics, int width, int height)
        {
            PuzzleGraphRenderer renderer = new PuzzleGraphRenderer(graphics);
            renderer.DrawDecorator(Decorator, new Vector(width / 2.0, height / 2.0), width * AdditionalScale, metaData, metaData.BackgroundColor, true);
        }
        public override Image GetImage(int width, int height)
        {
            if(image==null)
            {
                image = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(image))
                {
                    using (Pen pen = new Pen(Color.Gray, 3))
                    {
                        g.Clear(metaData.BackgroundColor);
                        g.DrawRectangle(pen, 0.0f, 0.0f, width - 1, height - 1);
                    }
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    Draw(g, width, height);
                }
            }
            return image;
        }
    }
}
