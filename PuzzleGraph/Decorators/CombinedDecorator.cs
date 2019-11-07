using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGraph.Decorators
{
    public class CombinedDecorator : Decorator, IFaceDecorable
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Decorator First { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Decorator Second { get; set; }

    }
}
