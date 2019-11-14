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
                if (face.Decorator is Decorators.AbstractTetrisDecorator tetris)
                {
                    if(tetris.Shapes.Count == 0 && tetris.Indexes.Count > 0)
                    {
                        upgraded = true;
                        tetris.Shapes = IndexToShape(graph, tetris.Indexes);
                        if (tetris.Shapes.Count == 0)
                            tetris.Indexes.Clear();
                    }
                }
            }
            return upgraded;
        }
    }
}
