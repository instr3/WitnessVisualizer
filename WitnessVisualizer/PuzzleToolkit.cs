using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WitnessVisualizer
{
    public class PuzzleToolkit
    {
        public List<PuzzleToolkitItem> Items { get; set; } = new List<PuzzleToolkitItem>();

        public static PuzzleToolkit CreateDefaultPuzzleToolkit()
        {
            List<List<Node>> exampleShapes = new List<List<Node>>() {
                    new List<Node>() { new Node(1.0,1.0), new Node(2.0, 1.0), new Node(2.0,2.0), new Node(1.0, 2.0) }
                };
            List<int> exampleIndex = new List<int>() { 0 };
            PuzzleToolkit Toolkit = new PuzzleToolkit();
            Toolkit.Items.Add(new PuzzleToolkitMiscItem("Pointer", "Icons/Cursor.png"));
            Toolkit.Items.Add(new PuzzleToolkitMiscItem("Painter", "Icons/Paint.png"));
            // Toolkit.Items.Add(new PuzzleToolkitMiscItem("Color Picker", Image.FromFile("Icons/ColorPicker.png")));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Empty", null));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Eliminator", new PuzzleGraph.Decorators.EliminatorDecorator()));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Triangle 1", new PuzzleGraph.Decorators.TriangleDecorator() { Count = 1 }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Triangle 2", new PuzzleGraph.Decorators.TriangleDecorator() { Count = 2 }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Triangle 3", new PuzzleGraph.Decorators.TriangleDecorator() { Count = 3 }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Triangle 4", new PuzzleGraph.Decorators.TriangleDecorator() { Count = 4 }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Triangle 5", new PuzzleGraph.Decorators.TriangleDecorator() { Count = 5 }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Tetris", new PuzzleGraph.Decorators.TetrisDecorator() { Indexes = exampleIndex, Shapes = exampleShapes }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Hollow Tetris", new PuzzleGraph.Decorators.HollowTetrisDecorator() { Indexes = exampleIndex, Shapes = exampleShapes }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Skew Tetris", new PuzzleGraph.Decorators.TetrisDecorator() { Indexes = exampleIndex, Shapes = exampleShapes, Angle = -15 }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Skew Hollow Tetris", new PuzzleGraph.Decorators.HollowTetrisDecorator() { Indexes = exampleIndex, Shapes = exampleShapes, Angle = -15 }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Star", new PuzzleGraph.Decorators.StarDecorator()));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Square", new PuzzleGraph.Decorators.SquareDecorator()));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Circle", new PuzzleGraph.Decorators.CircleDecorator()));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Ring", new PuzzleGraph.Decorators.RingDecorator()));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Point", new PuzzleGraph.Decorators.PointDecorator(), 0.5));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Broken", new PuzzleGraph.Decorators.BrokenDecorator(), 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Start", new PuzzleGraph.Decorators.StartDecorator(), 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndR", new PuzzleGraph.Decorators.EndDecorator() { Angle = 0 }, 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndL", new PuzzleGraph.Decorators.EndDecorator() { Angle = 180 }, 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndU", new PuzzleGraph.Decorators.EndDecorator() { Angle = -90 }, 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndD", new PuzzleGraph.Decorators.EndDecorator() { Angle = 90 }, 0.25));
            // Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndRD", new PuzzleGraph.Decorators.EndDecorator() { Angle = 45 }, 0.25));
            // Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndLD", new PuzzleGraph.Decorators.EndDecorator() { Angle = 135 }, 0.25));
            // Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndLU", new PuzzleGraph.Decorators.EndDecorator() { Angle = -135 }, 0.25));
            // Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndRU", new PuzzleGraph.Decorators.EndDecorator() { Angle = -45 }, 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Text", new PuzzleGraph.Decorators.TextDecorator() { Font = SystemFonts.MessageBoxFont, Text = "A" }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Symbol", new PuzzleGraph.Decorators.TextDecorator() { Font = SystemFonts.MessageBoxFont, Text = "\u2460" }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Emoji", new PuzzleGraph.Decorators.TextDecorator() { Font = new Font("Segoe UI Emoji",9), Text = "\U0001F600" }));
            return Toolkit;
        }
        public static double GetSuggestedDecorationScale(PuzzleGraph.Decorator decorator)
        {
            if (decorator is PuzzleGraph.Decorators.StartDecorator) return 0.25;
            if (decorator is PuzzleGraph.Decorators.BrokenDecorator) return 0.25;
            if (decorator is PuzzleGraph.Decorators.EndDecorator) return 0.25;
            if (decorator is PuzzleGraph.Decorators.PointDecorator) return 0.5;
            return 1.0;
        }
        public void SaveToFile(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(PuzzleToolkit));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xml.Serialize(fs, this);
            }
        }
        public static PuzzleToolkit LoadFromFile(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(PuzzleToolkit));
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return xml.Deserialize(fs) as PuzzleToolkit;
            }
        }
    }
}
