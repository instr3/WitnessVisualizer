using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;

namespace PuzzleGraph
{
    public class Face : GraphElement
    {
        [LocalizedDisplayName("Nodes")]
        public List<Node> Nodes { get; set; }
        [LocalizedDisplayName("GraphElementColor")]
        [XmlElement(Type = typeof(XmlColor))]
        public Color GraphElementColor { get; set; } = Color.Transparent;

        public Face(List<Node> inputNodes)
        {
            Nodes = inputNodes;
            Decorator = null;
        }
    }
}
