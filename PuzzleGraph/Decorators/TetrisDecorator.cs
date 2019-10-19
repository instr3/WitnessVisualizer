using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph.Decorators
{
    public class TetrisDecorator : Decorator, IFaceDecorable
    {
        [XmlElement(Type = typeof(XmlColor))]
        public Color Color { get; set; } = Color.Yellow;
        public double Angle { get; set; } = 0.0;
        public List<List<Node>> Shapes { get; set; } = new List<List<Node>>();
        public List<int> Indexes { get; set; } = new List<int>();
    }
}
