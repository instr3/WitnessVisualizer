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
    class PuzzleToolkitDecoratorItem : PuzzleToolkitItem
    {
        public Decorator Decorator { get; private set; }
        private static MetaData metaData;
        private double additionalScale;
        static PuzzleToolkitDecoratorItem()
        {
            metaData = new MetaData();
            metaData.BackgroundColor = Color.White;
            metaData.ForegroundColor = Color.Black;
            metaData.TetrisTemplate = new TetrisTemplate()
            {
                Shapes = new List<List<Node>>() {
                    new List<Node>() { new Node(0.0,0.0),new Node(0.0,1.0),new Node(1.0,1.0),new Node(1.0,0.0)},
                    new List<Node>() { new Node(0.0,1.0),new Node(0.0,2.0),new Node(1.0,2.0),new Node(1.0,1.0)},
                    new List<Node>() { new Node(1.0,0.0),new Node(1.0,1.0),new Node(2.0,1.0),new Node(2.0,0.0)},
                    new List<Node>() { new Node(1.0,1.0),new Node(1.0,2.0),new Node(2.0,2.0),new Node(2.0,1.0)}
                }
            };
        }
        public PuzzleToolkitDecoratorItem(string inputName, Decorator inputDecorator,double inputAdditionalScale=1.0)
        {
            Name = inputName;
            Decorator = inputDecorator;
            additionalScale = inputAdditionalScale;
        }

        public void Draw(Graphics graphics, int width, int height)
        {
            PuzzleGraphRenderer renderer = new PuzzleGraphRenderer(graphics);
            renderer.DrawDecorator(graphics, Decorator, new Vector(width / 2.0, height / 2.0), width * additionalScale, metaData);
        }
        public override Image GetImage(int width, int height)
        {
            Image image = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(image))
            {
                using (Pen pen = new Pen(Color.Gray, 3))
                {
                    g.DrawRectangle(pen, 0.0f, 0.0f, width - 1, height - 1);
                }
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Draw(g, width, height);
            }
            return image;
        }
    }
}
