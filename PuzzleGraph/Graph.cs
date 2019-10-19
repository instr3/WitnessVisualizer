using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace PuzzleGraph
{
    public class Graph : ICloneable
    {
        public List<Node> Nodes { get; private set; }
        public List<Edge> Edges { get; private set; }
        public List<Face> Faces { get; private set; }
        public MetaData MetaData { get; private set; }
        public Graph()
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
            Faces = new List<Face>();
            MetaData = new MetaData();
        }
        private Graph(SaveState state)
        {
            Nodes = state.Nodes;
            Edges = state.EdgesID.Select(edgeID => new Edge(Nodes[edgeID.Start], Nodes[edgeID.End]) { Decorator = edgeID.Decorator, GraphElementColor=edgeID.GraphElementColor }).ToList();
            Faces = state.FacesID.Select(faceID => new Face(faceID.Nodes.Select(id => Nodes[id]).ToList()) { Decorator = faceID.Decorator, GraphElementColor = faceID.GraphElementColor }).ToList();
            MetaData = state.MetaData;
        }
        public override string ToString()
        {
            XmlSerializer xml = new XmlSerializer(typeof(SaveState));
            using(MemoryStream ms=new MemoryStream())
            {
                xml.Serialize(ms, new SaveState(this));
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
        public Graph(string saveState):this(new XmlSerializer(typeof(SaveState))
                .Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(saveState))) as SaveState)
        {

        }
        public static Graph LoadFromFile(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(SaveState));
            using (FileStream fs=new FileStream(fileName,FileMode.Open))
            {
                return new Graph(xml.Deserialize(fs) as SaveState);
            }
        }
        public void SaveToFile(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(SaveState));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xml.Serialize(fs, new SaveState(this));
            }
        }

        public void RemoveElement(GraphElement element)
        {
            if(element is Node node)
            {
                List<GraphElement> elementsToDelete = new List<GraphElement>();
                foreach(Edge edge in Edges)
                {
                    if(edge.Start== node || edge.End==node)
                    {
                        elementsToDelete.Add(edge);
                    }
                }
                foreach (Face face in Faces)
                {
                    if (face.Nodes.Contains(node))
                    {
                        elementsToDelete.Add(face);
                    }
                }
                foreach (GraphElement newElement in elementsToDelete)
                    RemoveElement(newElement);
                Nodes.Remove(node);
            }
            else if(element is Edge edge)
            {
                Edges.Remove(edge);
            }
            else if(element is Face face)
            {
                Faces.Remove(face);
            }
        }

        public enum FlipType
        {
            XY=0,
            Horizontal=1,
            Vertical=2,
            Rotate=3
        }
        private static Node TransformNode(Node node,FlipType flipType,double angle=0)
        {
            if (flipType == FlipType.XY)
                return new Node(node.Y, node.X);
            else if (flipType == FlipType.Horizontal)
                return new Node(-node.X, node.Y);
            else if (flipType == FlipType.Vertical)
                return new Node(node.X, -node.Y);
            else if (flipType == FlipType.Rotate)
            {
                double cosValue = Math.Cos(angle), sinValue = Math.Sin(angle);
                return new Node(cosValue * node.X - sinValue * node.Y, sinValue * node.X + cosValue * node.Y);
            }
            else throw new NotSupportedException();
        }
        public static Graph FlipGraph(Graph graph, FlipType flipType)
        {
            Graph graphClone = new Graph(graph.ToString());
            Graph newGraph = new Graph();
            Dictionary<Node, Node> mapping = new Dictionary<Node, Node>();
            foreach (Node node in graphClone.Nodes)
            {
                mapping[node] = TransformNode(node, flipType);
                mapping[node].Decorator = node.Decorator;
            }
            foreach (Node node in graphClone.Nodes)
            {
                newGraph.Nodes.Add(mapping[node]);
            }
            foreach (Edge edge in graphClone.Edges)
            {
                Edge newEdge = new Edge(mapping[edge.Start], mapping[edge.End]);
                newEdge.Decorator = edge.Decorator;
                newEdge.GraphElementColor = edge.GraphElementColor;
                newGraph.Edges.Add(newEdge);
            }
            foreach (Face face in graphClone.Faces)
            {
                List<Node> nodes = new List<Node>();
                nodes.AddRange(face.Nodes);
                nodes.Reverse();
                Face newFace = new Face(nodes.Select(node => mapping[node]).ToList());
                newFace.Decorator = face.Decorator;
                newFace.GraphElementColor = face.GraphElementColor;
                newGraph.Faces.Add(newFace);
            }
            TetrisTemplate oldTetrisTemplate = graphClone.MetaData.TetrisTemplate;
            newGraph.MetaData = graphClone.MetaData;
            newGraph.MetaData.TetrisTemplate = new TetrisTemplate();
            foreach (List<Node> shape in oldTetrisTemplate.Shapes)
            {
                List<Node> newShape = new List<Node>();
                newShape.AddRange(shape);
                newShape.Reverse();
                newGraph.MetaData.TetrisTemplate.Shapes.Add(newShape.Select(node => TransformNode(node, flipType)).ToList());
            }
            return newGraph;
        }
        public static Graph RotateGraph(Graph graph, double angle)
        {
            Graph graphClone = new Graph(graph.ToString());
            Graph newGraph = new Graph();
            Dictionary<Node, Node> mapping = new Dictionary<Node, Node>();
            foreach (Node node in graphClone.Nodes)
            {
                mapping[node] = TransformNode(node, FlipType.Rotate, angle);
                mapping[node].Decorator = node.Decorator;
            }
            foreach (Node node in graphClone.Nodes)
            {
                newGraph.Nodes.Add(mapping[node]);
            }
            foreach (Edge edge in graphClone.Edges)
            {
                Edge newEdge = new Edge(mapping[edge.Start], mapping[edge.End]);
                newEdge.Decorator = edge.Decorator;
                newGraph.Edges.Add(newEdge);
            }
            foreach (Face face in graphClone.Faces)
            {
                List<Node> nodes = new List<Node>();
                nodes.AddRange(face.Nodes);
                Face newFace = new Face(nodes.Select(node => mapping[node]).ToList());
                newFace.Decorator = face.Decorator;
                newGraph.Faces.Add(newFace);
            }
            TetrisTemplate oldTetrisTemplate = graphClone.MetaData.TetrisTemplate;
            newGraph.MetaData = graphClone.MetaData;
            newGraph.MetaData.TetrisTemplate = new TetrisTemplate();
            foreach (List<Node> shape in oldTetrisTemplate.Shapes)
            {
                List<Node> newShape = new List<Node>();
                newShape.AddRange(shape);
                newGraph.MetaData.TetrisTemplate.Shapes.Add(newShape.Select(node => TransformNode(node, FlipType.Rotate, angle)).ToList());
            }
            return newGraph;

        }

        public object Clone()
        {
            return new Graph(ToString());
        }
    }
}
