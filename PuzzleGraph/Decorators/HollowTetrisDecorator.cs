using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph.Decorators
{
    public class HollowTetrisDecorator : AbstractTetrisDecorator, IFaceDecorable
    {
        [XmlElement(Type = typeof(XmlColor))]
        public Color Color { get; set; } = Color.Blue;
        public double BorderSize { get; set; } = 0.19;
        public double MarginSize { get; set; } = 0.14;
    }
}
