using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGraph.Decorators
{
    public class EndDecorator : Decorator, INodeDecorable
    {
        public double Length { get; set; } = 0.2;
        public double Angle { get; set; } = 135;
    }
}
