using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateGenerator
{
    class RightTriangleTemplateGenerator
    {
        public Graph Generate(int X, int Y, int tetrisTemplateSize)
        {
            double scale = 1.2;
            Graph graph = new Graph();
            List<Node> nodes = new List<Node>();
            Node[,] dict = new Node[X + 1, Y + 1];
            for (int i = 0; i <= X; ++i)
            {
                for (int j = 0; j <= Y; ++j)
                {
                    dict[i, j] = new Node((i + 1) * scale, (j + 1) * scale);
                    nodes.Add(dict[i, j]);
                }
            }
            List<Edge> edges = new List<Edge>();
            for (int i = 1; i <= X; ++i)
                for (int j = 0; j <= Y; ++j)
                    edges.Add(new Edge(dict[i - 1, j], dict[i, j]));
            for (int i = 0; i <= X; ++i)
                for (int j = 1; j <= Y; ++j)
                    edges.Add(new Edge(dict[i, j - 1], dict[i, j]));
            List<Face> faces = new List<Face>();
            for (int i = 1; i <= X; ++i)
            {
                for (int j = 1; j <= Y; ++j)
                {
                    edges.Add(new Edge(dict[i - 1, j - 1], dict[i, j]));
                    faces.Add(new Face(new List<Node>() { dict[i - 1, j - 1], dict[i, j], dict[i - 1, j] }));
                    faces.Add(new Face(new List<Node>() { dict[i - 1, j - 1], dict[i, j - 1], dict[i, j] }));
                }
            }
            graph.Nodes.AddRange(nodes);
            graph.Edges.AddRange(edges);
            graph.Faces.AddRange(faces);
            List<List<Node>> result = new List<List<Node>>();
            dict = new Node[tetrisTemplateSize + 1, tetrisTemplateSize + 1];
            for (int i = 0; i <= tetrisTemplateSize; ++i)
            {
                for (int j = 0; j <= tetrisTemplateSize; ++j)
                {
                    dict[i, j] = new Node((i + 1) * scale, (j + 1) * scale);
                }
            }
            for (int i = 1; i <= tetrisTemplateSize; ++i)
            {
                for (int j = 1; j <= tetrisTemplateSize; ++j)
                {
                    result.Add(new List<Node>() { dict[i - 1, j - 1], dict[i, j], dict[i - 1, j] });
                    result.Add(new List<Node>() { dict[i - 1, j - 1], dict[i, j - 1], dict[i, j] });
                }
            }
            graph.MetaData.TetrisTemplate.Shapes.AddRange(result);
            graph.MetaData.PuzzleTitle = string.Format("RightTriangle/RightTrianglePuzzle_{0}x{1}", X, Y);
            graph.MetaData.FaceDecorationScale = 0.8;
            graph.MetaData.TetrisScale = 0.3;
            return graph;
        }
    }
}
