using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitnessVisualizer
{
    class TetrisTransferHelper
    {
        private const double EPS = 1e-6;
        private static bool ShapeCompatible(List<Node> shape1, List<Node> shape2)
        {
            if (shape1.Count != shape2.Count) return false;
            for(int i=0;i<shape1.Count;++i)
            {
                Node p1 = shape1[i], p2 = shape2[i];
                if (p1.X - p2.X > EPS || p2.X - p1.X > EPS) return false;
                if (p1.Y - p2.Y > EPS || p2.Y - p1.Y > EPS) return false;
            }
            return true;
        }
        public static bool TetrisCompatible(Graph graph, List<int> indexes, List<List<Node>> shapes)
        {
            if (indexes.Count != shapes.Count) return false;
            TetrisTemplate template = graph.MetaData.TetrisTemplate;
            for (int i = 0; i < indexes.Count; ++i)
            {
                int index = indexes[i];
                if (index >= template.Shapes.Count) return false;
                if (!ShapeCompatible(template.Shapes[index], shapes[i])) return false;
            }
            return true;
        }
        public static bool TetrisCompatible(Graph graph, Decorator decorator)
        {
            if (decorator is PuzzleGraph.Decorators.AbstractTetrisDecorator tetris)
            {
                return TetrisCompatible(graph, tetris.Indexes, tetris.Shapes);
            }
            else return false;
        }

        internal static void ClearTetrisIndex(Decorator decorator)
        {
            if (decorator is PuzzleGraph.Decorators.AbstractTetrisDecorator tetris)
            {
                tetris.Indexes = new List<int>();
            }
        }
    }
}
