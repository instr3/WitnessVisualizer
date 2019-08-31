using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            SquareTemplateGenerator squareTemplateGenerator = new SquareTemplateGenerator();
            HexagonTemplateGenerator hexagonTemplateGenerator = new HexagonTemplateGenerator();
            for (int i=1;i<=8;++i)
            {
                for(int j=1;j<=8;++j)
                {
                    SaveGeneratedPuzzle(squareTemplateGenerator.Generate(i, j, 6));
                    SaveGeneratedPuzzle(hexagonTemplateGenerator.Generate(i, j, 6));
                }
            }
        }
        static void SaveGeneratedPuzzle(Graph graph)
        {
            string name = graph.MetaData.PuzzleTitle;
            graph.SaveToFile("Templates/" + name + ".wit");
        }
        
    }
}
