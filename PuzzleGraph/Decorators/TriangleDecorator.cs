using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGraph.Decorators
{
    public class TriangleDecorator : Decorator, IFaceDecorable
    {
        public int Count { get; set; } = 1;
        public Color Color { get; set; } = Color.Gold;
    }
}
