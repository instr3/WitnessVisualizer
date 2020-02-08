using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph.Decorators
{
    public class EndDecorator : Decorator, INodeDecorable, IEdgeDecorable
    {
        [LocalizedDisplayName("Length")]
        public double Length { get; set; } = 0.2;
        [LocalizedDisplayName("Angle")]
        public double Angle { get; set; } = 135;
        [LocalizedDisplayName("Color")]
        [XmlElement(Type = typeof(XmlColor))]
        public Color Color { get; set; } = Color.Transparent;
    }
}
