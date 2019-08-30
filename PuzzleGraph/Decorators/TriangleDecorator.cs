using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph.Decorators
{
    public class TriangleDecorator : Decorator, IFaceDecorable
    {
        public int Count { get; set; } = 1;
        [XmlElement(Type = typeof(XmlColor))]
        public Color Color { get; set; } = Color.Gold;
    }
}
