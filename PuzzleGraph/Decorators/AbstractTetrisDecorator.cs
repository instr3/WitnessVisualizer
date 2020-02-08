using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGraph.Decorators
{
    public class AbstractTetrisDecorator : Decorator
    {
        [LocalizedDisplayName("Angle")]
        public double Angle { get; set; } = 0.0;
        [LocalizedDisplayName("Shapes")]
        public List<List<Node>> Shapes { get; set; } = new List<List<Node>>();
        [LocalizedDisplayName("Indexes")]
        public List<int> Indexes { get; set; } = new List<int>();
    }
}
