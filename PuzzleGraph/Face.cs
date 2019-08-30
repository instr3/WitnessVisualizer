using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleGraph
{
    public class Face : GraphElement
    {
        public List<Node> Nodes { get; set; }

        public Face(List<Node> inputNodes)
        {
            Nodes = inputNodes;
            Decorator = null;
        }
    }
}
