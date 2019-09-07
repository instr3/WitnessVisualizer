using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGraph
{
    public abstract class GraphElement
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Decorator Decorator { get; set; }
    }
}
