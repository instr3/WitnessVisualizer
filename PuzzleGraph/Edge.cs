using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;

namespace PuzzleGraph
{
    public class Edge : GraphElement
    {
        public Node Start { get; set; }
        public Node End { get; set; }
        [XmlElement(Type = typeof(XmlColor))]
        public Color GraphElementColor { get; set; } = Color.Transparent;

        public Edge(Node inputStart,Node inputEnd)
        {
            Start = inputStart;
            End = inputEnd;
            Decorator = null;
        }
    }
}
