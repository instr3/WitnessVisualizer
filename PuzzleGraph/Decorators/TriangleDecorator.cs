using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph.Decorators
{
    [LocalizedDisplayName("fff")]
    public class TriangleDecorator : TransformableDecorator, IFaceDecorable, IEdgeDecorable, INodeDecorable
    {
        [LocalizedDisplayName("Count")]
        public int Count { get; set; } = 1;
        [LocalizedDisplayName("Color")]
        [XmlElement(Type = typeof(XmlColor))]
        public Color Color { get; set; } = Color.Gold;
    }
}
