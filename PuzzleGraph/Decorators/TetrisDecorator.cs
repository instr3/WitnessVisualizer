using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph.Decorators
{
    public class TetrisDecorator : AbstractTetrisDecorator, IFaceDecorable, IEdgeDecorable, INodeDecorable
    {
        [LocalizedDisplayName("Color")]
        [XmlElement(Type = typeof(XmlColor))]
        public Color Color { get; set; } = Color.Yellow;
        [LocalizedDisplayName("MarginSize")]
        public double MarginSize { get; set; } = 0.14;

    }
}
