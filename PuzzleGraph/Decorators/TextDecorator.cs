using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph.Decorators
{
    public class TextDecorator : Decorator, IFaceDecorable, IEdgeDecorable, INodeDecorable
    {
        // [XmlElement(Type = typeof(XmlFont))]
        [LocalizedDisplayName("Font")]
        [XmlIgnore()]
        public Font Font { get { return SerializableFont?.ToFont(); }
            set { SerializableFont = new SerializableFont(value); }
        }
        [Browsable(false)]
        public SerializableFont SerializableFont { get; set; }
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [LocalizedDisplayName("Text")]
        public string Text { get; set; }
        [LocalizedDisplayName("Angle")]
        public double Angle { get; set; }
        [LocalizedDisplayName("Color")]
        [XmlElement(Type = typeof(XmlColor))]
        public Color Color { get; set; } = Color.Black;

    }
}
