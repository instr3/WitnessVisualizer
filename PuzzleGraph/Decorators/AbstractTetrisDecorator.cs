using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGraph.Decorators
{
    public class AbstractTetrisDecorator : Decorator
    {
        public double Angle { get; set; } = 0.0;
        public List<List<Node>> Shapes { get; set; } = new List<List<Node>>();
        public List<int> Indexes { get; set; } = new List<int>();
    }
}
