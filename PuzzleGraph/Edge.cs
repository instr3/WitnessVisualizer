using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;

namespace PuzzleGraph
{
    public class Edge : GraphElement
    {
        [LocalizedDisplayName("Start")]
        public Node Start { get; set; }
        [LocalizedDisplayName("End")]
        public Node End { get; set; }
        [LocalizedDisplayName("GraphElementColor")]
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
