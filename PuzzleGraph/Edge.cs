using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleGraph
{
    public class Edge : GraphElement
    {
        public Node Start { get; set; }
        public Node End { get; set; }

        public Edge(Node inputStart,Node inputEnd)
        {
            Start = inputStart;
            End = inputEnd;
            Decorator = null;
        }
    }
}
