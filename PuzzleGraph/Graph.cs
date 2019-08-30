using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace PuzzleGraph
{
    public class Graph
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
            Edges = state.EdgesID.Select(edgeID => new Edge(Nodes[edgeID.Start], Nodes[edgeID.End]) { Decorator = edgeID.Decorator }).ToList();
            Faces = state.FacesID.Select(faceID => new Face(faceID.Nodes.Select(id => Nodes[id]).ToList()) { Decorator = faceID.Decorator }).ToList();
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
    }
}
