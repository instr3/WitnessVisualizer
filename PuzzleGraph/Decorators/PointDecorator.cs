using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGraph.Decorators
{
    public class PointDecorator : Decorator, INodeDecorable, IEdgeDecorable
    {
        public Color Color { get; set; } = Color.Black;
    }
}
