using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph.Decorators
{
    public class SelfIntersectionDecorator : TransformableDecorator, IFaceDecorable, IEdgeDecorable, INodeDecorable
    {
        [LocalizedDisplayName("Color1")]
        [XmlElement(Type = typeof(XmlColor))]
        public Color Color1 { get; set; } = Color.Black;
        [LocalizedDisplayName("Color2")]
        [XmlElement(Type = typeof(XmlColor))]
        public Color Color2 { get; set; } = Color.Black;
    }
}
