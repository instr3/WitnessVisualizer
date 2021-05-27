using System;

namespace PuzzleGraph
{
    public class Node: GraphElement
    {
        [LocalizedDisplayName("X")]
        public double X { get; set; }
        [LocalizedDisplayName("Y")]
        public double Y { get; set; }
        [LocalizedDisplayName("Hidden")]
        public bool Hidden { get; set; }

        private Node() { }
        public Node(double inputX,double inputY)
        {
            X = inputX;
            Y = inputY;
            Decorator = null;
            Hidden = false;
        }
    }
}
