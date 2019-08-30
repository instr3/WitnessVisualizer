using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

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
        public override string ToString()
        {
            XmlSerializer xml = new XmlSerializer(typeof(MetaData));
            using(MemoryStream ms=new MemoryStream())
            {
                xml.Serialize(ms, MetaData);
                return Encoding.UTF8.GetString(ms.ToArray());
            }

        }

    }
}
