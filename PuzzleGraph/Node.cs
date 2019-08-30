using System;

namespace PuzzleGraph
{
    public class Node
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Decorator Decorator { get; set; }
        public Node(double inputX,double inputY)
        {
            X = inputX;
            Y = inputY;
            Decorator = null;
        }
    }
}
