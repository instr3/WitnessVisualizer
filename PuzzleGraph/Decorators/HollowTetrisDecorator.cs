using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph.Decorators
{
    public class HollowTetrisDecorator : AbstractTetrisDecorator, IFaceDecorable, IEdgeDecorable, INodeDecorable
    {
        [LocalizedDisplayName("Color")]
        [XmlElement(Type = typeof(XmlColor))]
        public Color Color { get; set; } = Color.Blue;
        [LocalizedDisplayName("BorderSize")]
        public double BorderSize { get; set; } = 0.19;
        [LocalizedDisplayName("MarginSize")]
        public double MarginSize { get; set; } = 0.14;
    }
}
