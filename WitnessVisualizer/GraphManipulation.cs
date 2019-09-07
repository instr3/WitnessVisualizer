using MathHelper;
using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitnessVisualizer
{
    class GraphManipulation
    {
        public static Face QueryFace(Graph graph, Node node1, Node node2)
        {
            foreach (Face face in graph.Faces)
            {
                for (int i = 0; i < face.Nodes.Count; ++i)
                {
                    if (face.Nodes[i] == node2 && face.Nodes[i == 0 ? face.Nodes.Count - 1 : i - 1] == node1)
                    {
                        return face;
                    }
                }
            }
            return null;
        }

        public static Edge QueryEdge(Graph graph, Node node1, Node node2)
        {
            foreach (Edge edge in graph.Edges)
            {
                if (edge.Start == node1 && edge.End == node2) return edge;
                if (edge.Start == node2 && edge.End == node1) return edge;
            }
            return null;
        }

        public static Node QueryNearByNodes(Graph graph, Vector query, double Eps = 1e-3)
        {
            foreach (Node node in graph.Nodes)
            {
                Vector position = new Vector(node.X, node.Y);
                if (Vector.PointDistance(position, query) <= Eps)
                    return node;
            }
            return null;
        }

        private static List<Node> MappingShapesToNewPosition(List<Node> shape, Node node0, Node node1)
        {
            if(shape.Count<2)
            {
                throw new NotSupportedException("The shape has too few nodes.");
            }
            Vector o1 = new Vector(shape[0].X, shape[0].Y);
            Vector o2 = new Vector(node0.X, node0.Y);
            Vector v1 = new Vector(shape[1].X - shape[0].X, shape[1].Y - shape[0].Y);
            Vector v2 = new Vector(node1.X - node0.X, node1.Y - node0.Y);
            Vector u1 = new Vector(v1.Y, -v1.X);
            Vector u2 = new Vector(v2.Y, -v2.X);
            double l1 = v1.X * v1.X + v1.Y * v1.Y;
            double l2 = v2.X * v2.X + v2.Y * v2.Y;
            List<Node> newShape = new List<Node>(shape.Count);
            foreach(Node node in shape)
            {
                Vector pos = new Vector(node.X, node.Y) - o1;
                double uCoord = (pos ^ u1) / l1;
                double vCoord = (pos ^ v1) / l1;
                Vector pos2 = uCoord * u2 + vCoord * v2 + o2;
                newShape.Add(new Node(pos2.X, pos2.Y));
            }
            return newShape;
        }
        public static void AddShapeWithBaseDirectedSegment(Graph graph, Node node0, Node node1, List<Node> shape)
        {
            List<Node> mappedShape = MappingShapesToNewPosition(shape, node0, node1);
            List<Node> existNodes = mappedShape.Select(node => QueryNearByNodes(graph, new Vector(node.X, node.Y))).ToList();
            List<Node> faceNodes = new List<Node>(mappedShape.Count);
            for (int i = 0; i < mappedShape.Count; ++i)
            {
                if (existNodes[i] is null)
                {
                    graph.Nodes.Add(mappedShape[i]);
                    faceNodes.Add(mappedShape[i]);
                }
                else
                {
                    faceNodes.Add(existNodes[i]);
                }
            }
            for (int i = 0; i < mappedShape.Count; ++i)
            {
                int prev = i == 0 ? mappedShape.Count - 1 : i - 1;
                if (QueryEdge(graph, faceNodes[prev], faceNodes[i]) is null)
                {
                    graph.Edges.Add(new Edge(faceNodes[prev], faceNodes[i]));
                }
            }
            graph.Faces.Add(new Face(faceNodes));
        }
        public static List<Node> CreateRegularPolygon(int edges)
        {
            double angle = 2 * Math.PI / edges;
            return Enumerable.Range(0, edges).Select(i => new Node(Math.Cos(i * angle), Math.Sin(i * angle))).ToList();
        }

        public static void TryAddShapeWithBaseSegment(Graph graph, Edge edge, List<Node> shape)
        {
            if(QueryFace(graph, edge.Start, edge.End) is null)
                AddShapeWithBaseDirectedSegment(graph, edge.Start, edge.End, shape);
            else if(QueryFace(graph, edge.End, edge.Start) is null)
                AddShapeWithBaseDirectedSegment(graph, edge.End, edge.Start, shape);
        }
    }
}
