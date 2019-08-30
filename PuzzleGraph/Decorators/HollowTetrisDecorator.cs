using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGraph.Decorators
{
    public class HollowTetrisDecorator : Decorator, IFaceDecorable
    {
        public Color Color { get; set; } = Color.Blue;
        public double Angel { get; set; } = 0.0;
        public List<int> Indexes { get; set; } = new List<int>();
    }
}
