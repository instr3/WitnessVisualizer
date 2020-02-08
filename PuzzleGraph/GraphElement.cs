using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph
{
    public abstract class GraphElement
    {
        [LocalizedDisplayName("Decorator")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Decorator Decorator { get; set; }
        public override string ToString()
        {
            return Resources.Lang.ResourceManager.GetString(this.GetType().Name) ?? this.GetType().Name;
        }
    }
}
