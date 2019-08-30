using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGraph.Decorators
{
    public class EndDecorator : Decorator, INodeDecorable
    {
        public double DirX { get; set; } = 0.141;
        public double DirY { get; set; } = 0.141;
    }
}
