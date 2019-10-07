using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph.Decorators
{
    public class TextDecorator : Decorator, IFaceDecorable, IEdgeDecorable, INodeDecorable
    {
        // [XmlElement(Type = typeof(XmlFont))]
        [XmlIgnore()]
        public Font Font { get { return SerializableFont.ToFont(); }
            set { SerializableFont = new SerializableFont(value); }
        }
        [Browsable(false)]
        public SerializableFont SerializableFont { get; set; }
        public string Text { get; set; }
        public double Angle { get; set;  }
        [XmlElement(Type = typeof(XmlColor))]
        public Color Color { get; set; } = Color.Black;

    }
}
