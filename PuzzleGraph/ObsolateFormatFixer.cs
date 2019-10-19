using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGraph
{
    public class ObsolateFormatFixer
    {
        private static List<List<Node>> IndexToShape(Graph graph, List<int> indexes)
        {
            List<List<Node>> result = new List<List<Node>>();
            TetrisTemplate template = graph.MetaData.TetrisTemplate;
            foreach (int index in indexes)
            {
                if (index < template.Shapes.Count)
                {
                    result.Add(template.Shapes[index].Select(node => new Node(node.X, node.Y)).ToList());
                }
            }
            return result;
        }

        public static bool FixObsoletedTetrisFormat(Graph graph)
        {
            bool upgraded = false;
            foreach (Face face in graph.Faces)
            {
                if (face.Decorator is Decorators.TetrisDecorator tetrisDecorator)
                {
                    if(tetrisDecorator.Shapes.Count == 0 && tetrisDecorator.Indexes.Count > 0)
                    {
                        upgraded = true;
                        tetrisDecorator.Shapes = IndexToShape(graph, tetrisDecorator.Indexes);
                        if (tetrisDecorator.Shapes.Count == 0)
                            tetrisDecorator.Indexes.Clear();
                    }
                }
                if (face.Decorator is Decorators.HollowTetrisDecorator hollowTetrisDecorator)
                {
                    if (hollowTetrisDecorator.Shapes.Count == 0 && hollowTetrisDecorator.Indexes.Count > 0)
                    {
                        upgraded = true;
                        hollowTetrisDecorator.Shapes = IndexToShape(graph, hollowTetrisDecorator.Indexes);
                        if (hollowTetrisDecorator.Shapes.Count == 0)
                            hollowTetrisDecorator.Indexes.Clear();
                    }
                }
            }
            return upgraded;
        }
    }
}
