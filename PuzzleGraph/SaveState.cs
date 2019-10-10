using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph
{
    public class SaveState
    {
        public class SaveEdge
        {
            public int Start { get; set; }
            public int End { get; set; }
            public Decorator Decorator { get; set; }
            [XmlElement(Type = typeof(XmlColor))]
            public Color GraphElementColor { get; set; } = Color.Transparent;
        }
        public class SaveFace
        {
            public List<int> Nodes { get; set; }
            public Decorator Decorator { get; set; }
            [XmlElement(Type = typeof(XmlColor))]
            public Color GraphElementColor { get; set; } = Color.Transparent;
        }

        public List<Node> Nodes { get; set; }
        public List<SaveEdge> EdgesID { get; set; }
        public List<SaveFace> FacesID { get; set; }
        public MetaData MetaData { get; set; }

        private SaveState() { }
        public SaveState(Graph graph)
        {
            Dictionary<object, int> nodeIDs = new Dictionary<object, int>();
            Nodes = graph.Nodes;
            for(int i=0;i<Nodes.Count;++i)
            {
                nodeIDs[Nodes[i]] = i;
            }
            EdgesID = new List<SaveEdge>(graph.Edges.Count);
            for(int i=0;i<graph.Edges.Count;++i)
            {
                Edge edge = graph.Edges[i];
                EdgesID.Add(new SaveEdge() { Start = nodeIDs[edge.Start], End = nodeIDs[edge.End],
                    Decorator = edge.Decorator, GraphElementColor = edge.GraphElementColor});
            }
            FacesID = new List<SaveFace>(graph.Faces.Count);
            for(int i=0;i<graph.Faces.Count;++i)
            {
                Face face = graph.Faces[i];
                FacesID.Add(new SaveFace() { Nodes = face.Nodes.Select(node => nodeIDs[node]).ToList(),
                    Decorator = face.Decorator, GraphElementColor = face.GraphElementColor
                });
            }
            MetaData = graph.MetaData;
        }
    }
}
