using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitnessVisualizer
{
    class PuzzleToolkit
    {
        public List<PuzzleToolkitItem> Items { get; private set; } = new List<PuzzleToolkitItem>();

        public static PuzzleToolkit CreateDefaultPuzzleToolkit()
        {
            PuzzleToolkit Toolkit = new PuzzleToolkit();
            Toolkit.Items.Add(new PuzzleToolkitMiscItem("Pointer", Image.FromFile("Icons/Cursor.png")));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Triangle 1", new PuzzleGraph.Decorators.TriangleDecorator() { Count = 1 }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Triangle 2", new PuzzleGraph.Decorators.TriangleDecorator() { Count = 2 }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Triangle 3", new PuzzleGraph.Decorators.TriangleDecorator() { Count = 3 }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Tetris", new PuzzleGraph.Decorators.TetrisDecorator() { Indexes=new List<int>() { 0, 1, 2, 3 } }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Hollow Tetris", new PuzzleGraph.Decorators.HollowTetrisDecorator() { Indexes = new List<int>() { 0, 1, 2, 3 } }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Skew Tetris", new PuzzleGraph.Decorators.TetrisDecorator() { Indexes = new List<int>() { 0, 1, 2, 3 }, Angle = -15 }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Skew Hollow Tetris", new PuzzleGraph.Decorators.HollowTetrisDecorator() { Indexes = new List<int>() { 0, 1, 2, 3 }, Angle = -15 }));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Star", new PuzzleGraph.Decorators.StarDecorator()));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Square", new PuzzleGraph.Decorators.SquareDecorator()));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Point", new PuzzleGraph.Decorators.PointDecorator(), 0.5));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Broken", new PuzzleGraph.Decorators.BrokenDecorator(), 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("Start", new PuzzleGraph.Decorators.StartDecorator(), 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndR", new PuzzleGraph.Decorators.EndDecorator() { DirX = 0.2, DirY = 0 }, 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndL", new PuzzleGraph.Decorators.EndDecorator() { DirX = -0.2, DirY = 0 }, 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndU", new PuzzleGraph.Decorators.EndDecorator() { DirX = 0, DirY = -0.2 }, 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndD", new PuzzleGraph.Decorators.EndDecorator() { DirX = 0, DirY = 0.2 }, 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndRD", new PuzzleGraph.Decorators.EndDecorator() { DirX = 0.1414, DirY = 0.1414 }, 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndLD", new PuzzleGraph.Decorators.EndDecorator() { DirX = -0.1414, DirY = 0.1414 }, 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndLU", new PuzzleGraph.Decorators.EndDecorator() { DirX = -0.1414, DirY = -0.1414 }, 0.25));
            Toolkit.Items.Add(new PuzzleToolkitDecoratorItem("EndRU", new PuzzleGraph.Decorators.EndDecorator() { DirX = 0.1414, DirY = -0.1414 }, 0.25));
            return Toolkit;
        }
    }
}
