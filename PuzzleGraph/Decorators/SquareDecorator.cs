using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph.Decorators
{
    public class SquareDecorator : Decorator, IFaceDecorable
    {
        [XmlElement(Type = typeof(XmlColor))]
        public Color Color { get; set; } = Color.Black;
    }
}
