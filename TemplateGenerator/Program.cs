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
            RightTriangleTemplateGenerator rightTriangleTemplateGenerator = new RightTriangleTemplateGenerator();
            for (int i=1;i<=8;++i)
            {
                for(int j=1;j<=8;++j)
                {
                    SaveGeneratedPuzzle(squareTemplateGenerator.Generate(i, j, 6));
                    SaveGeneratedPuzzle(rightTriangleTemplateGenerator.Generate(i, j, 6));
                    SaveGeneratedPuzzle(hexagonTemplateGenerator.Generate(i, j, 7, false, true));
                }
            }
            for(int i=3;i<=7;i+=2)
            {
                SaveGeneratedPuzzle(hexagonTemplateGenerator.Generate(i, i, 7, true, true));
            }
        }
        static void SaveGeneratedPuzzle(Graph graph)
        {
            string name = graph.MetaData.PuzzleTitle;
            if (name.Contains("/"))
            {
                Directory.CreateDirectory("Templates/" + name.Substring(0, name.IndexOf("/")));
            }
            graph.SaveToFile("Templates/" + name + ".wit");
        }
        
    }
}
