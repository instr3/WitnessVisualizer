using System;

namespace PuzzleGraph
{
    public class Node: GraphElement
    {
        public double X { get; set; }
        public double Y { get; set; }
        private Node() { }
        public Node(double inputX,double inputY)
        {
            X = inputX;
            Y = inputY;
            Decorator = null;
        }
    }
}
