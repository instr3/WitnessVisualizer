﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGraph.Decorators
{
    public class CombinedDecorator : Decorator
    {
        public override bool IsFaceDecorable()
        {
            if(First is null || Second is null) return false;
            return First.IsFaceDecorable() && Second.IsFaceDecorable();
        }
        public override bool IsEdgeDecorable()
        {
            if (First is null || Second is null) return false;
            return First.IsEdgeDecorable() && Second.IsEdgeDecorable();
        }
        public override bool IsNodeDecorable()
        {
            if (First is null || Second is null) return false;
            return First.IsNodeDecorable() && Second.IsNodeDecorable();
        }
        [LocalizedDisplayName("First")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Decorator First { get; set; }
        [LocalizedDisplayName("Second")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Decorator Second { get; set; }

    }
}
