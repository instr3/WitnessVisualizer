using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph.Decorators
{
    public class EndDecorator : Decorator, INodeDecorable
    {
        public double Length { get; set; } = 0.2;
        public double Angle { get; set; } = 135;
        [XmlElement(Type = typeof(XmlColor))]
        public Color Color { get; set; } = Color.Transparent;
    }
}
