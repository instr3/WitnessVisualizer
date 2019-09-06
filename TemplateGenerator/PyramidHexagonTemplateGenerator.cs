using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateGenerator
{
    class PyramidHexagonTemplateGenerator
    {
        public Graph Generate(int X, int Y, int tetrisTemplateSize, bool roundShapeTetris)
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
                    if (i != X || j != 0)
                    {
                        dict1[i, j] = new Node(((j - i) * 1.5 - 0.5) * scale, ((j + i) * sqrt3 / 2) * scale);
                        nodes.Add(dict1[i, j]);
                    }
                    if (i != 0 || j != Y)
                    {
                        dict2[i, j] = new Node(((j - i) * 1.5 + 0.5) * scale, ((j + i) * sqrt3 / 2) * scale);
                        nodes.Add(dict2[i, j]);
                    }
                    if (dict1[i, j] != null && dict2[i, j] != null)
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
            List<Node> toDelete = new List<Node>();
            double limit = 1.1 * scale;
            foreach (Node node in graph.Nodes)
            {
                if (node.X > limit)
                    toDelete.Add(node);
            }
            foreach (Node node in toDelete)
                graph.RemoveElement(node);
            graph.MetaData.PuzzleTitle = string.Format("HexPyramid/HexPyramidPuzzle_{0}x{1}", X, Y);
            GenerateTetrisTemplate(graph, tetrisTemplateSize, roundShapeTetris);
            return Graph.FlipGraph(graph, Graph.FlipType.XY);
        }
        void GenerateTetrisTemplate(Graph graph, int tetrisTemplateSize, bool roundShape)
        {
            double sqrt3 = Math.Sqrt(3.0);
            double scale = 0.75;
            Node[,] dict1 = new Node[tetrisTemplateSize + 1, tetrisTemplateSize + 1];
            Node[,] dict2 = new Node[tetrisTemplateSize + 1, tetrisTemplateSize + 1];
            List<List<Node>> result = new List<List<Node>>();
            List<List<Node>> toDelete = new List<List<Node>>();
            for (int i = 0; i <= tetrisTemplateSize; ++i)
            {
                for (int j = 0; j <= tetrisTemplateSize; ++j)
                {
                    dict1[i, j] = new Node(((j - i) * 1.5 - 0.5) * scale, ((j + i) * sqrt3 / 2) * scale);
                    dict2[i, j] = new Node(((j - i) * 1.5 + 0.5) * scale, ((j + i) * sqrt3 / 2) * scale);
                }
            }
            for (int i = 1; i <= tetrisTemplateSize; ++i)
            {
                for (int j = 1; j <= tetrisTemplateSize; ++j)
                {
                    result.Add(new List<Node>() { dict1[i - 1, j - 1], dict2[i - 1, j - 1], dict1[i - 1, j], dict2[i, j], dict1[i, j], dict2[i, j - 1] });
                }
            }
            if (roundShape)
            {
                double limit = 0.0 * scale;
                foreach (List<Node> shape in result)
                {
                    foreach (Node node in shape)
                    {
                        if (node.X > limit)
                            toDelete.Add(shape);
                        break;
                    }
                }
            }
            graph.MetaData.TetrisTemplate.Shapes.AddRange(result.Except(toDelete));

        }

    }
}
