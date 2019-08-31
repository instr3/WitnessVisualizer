using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateGenerator
{
    class HexagonTemplateGenerator
    {
        public Graph Generate(int X, int Y, int tetrisTemplateSize)
        {
            double sqrt3 = Math.Sqrt(3.0);
            double scale = 0.75;
            Graph graph = new Graph();
            List<Node> nodes = new List<Node>();
            List<Edge> edges = new List<Edge>();
            Node[,] dict1 = new Node[X + 1, Y + 1];
            Node[,] dict2 = new Node[X + 1, Y + 1];
            for (int i = 0; i <= X; ++i)
            {
                for (int j = 0; j <= Y; ++j)
                {
                    dict1[i, j] = new Node(((j - i) * 1.5 - 0.5) * scale, ((j + i) * sqrt3 / 2) * scale);
                    dict2[i, j] = new Node(((j - i) * 1.5 + 0.5) * scale, ((j + i) * sqrt3 / 2) * scale);
                    nodes.Add(dict1[i, j]);
                    nodes.Add(dict2[i, j]);
                    edges.Add(new Edge(dict1[i, j], dict2[i, j]));
                }
            }
            for (int i = 1; i <= X; ++i)
                for (int j = 0; j <= Y; ++j)
                    edges.Add(new Edge(dict1[i - 1, j], dict2[i, j]));
            for (int i = 0; i <= X; ++i)
                for (int j = 1; j <= Y; ++j)
                    edges.Add(new Edge(dict2[i, j - 1], dict1[i, j]));
            List<Face> faces = new List<Face>();
            for (int i = 1; i <= X; ++i)
                for (int j = 1; j <= Y; ++j)
                    faces.Add(new Face(new List<Node>() { dict1[i - 1, j - 1], dict2[i - 1, j - 1], dict1[i - 1, j], dict2[i, j], dict1[i, j], dict2[i, j - 1] }));
            graph.Nodes.AddRange(nodes);
            graph.Edges.AddRange(edges);
            graph.Faces.AddRange(faces);
            GenerateTetrisTemplate(graph, tetrisTemplateSize);
            graph.MetaData.PuzzleTitle = string.Format("HexPuzzle_{0}x{1}", X, Y);
            return graph;
        }
        void GenerateTetrisTemplate(Graph graph,int tetrisTemplateSize)
        {
            double sqrt3 = Math.Sqrt(3.0);
            Node[,] dict1 = new Node[tetrisTemplateSize + 1, tetrisTemplateSize + 1];
            Node[,] dict2 = new Node[tetrisTemplateSize + 1, tetrisTemplateSize + 1];
            List<List<Node>> result = new List<List<Node>>();
            for (int i = 0; i <= tetrisTemplateSize; ++i)
            {
                for (int j = 0; j <= tetrisTemplateSize; ++j)
                {
                    dict1[i, j] = new Node((j - i) * 1.5 - 0.5, (j + i) * sqrt3 / 2);
                    dict2[i, j] = new Node((j - i) * 1.5 + 0.5, (j + i) * sqrt3 / 2);
                }
            }
            for (int i = 1; i <= tetrisTemplateSize; ++i)
            {
                for (int j = 1; j <= tetrisTemplateSize; ++j)
                {
                    result.Add(new List<Node>() { dict1[i - 1, j - 1], dict2[i - 1, j - 1], dict1[i - 1, j], dict2[i, j], dict1[i, j], dict2[i, j - 1] });
                }
            }
            graph.MetaData.TetrisTemplate.Shapes.AddRange(result);
            
        }
    }
}
