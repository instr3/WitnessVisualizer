using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleGraph
{
    public class Face
    {
        public List<Node> Nodes { get; set; }
        public Decorator Decorator { get; set; }

        public Face(List<Node> inputNodes)
        {
            Nodes = inputNodes;
            Decorator = null;
        }
    }
}
