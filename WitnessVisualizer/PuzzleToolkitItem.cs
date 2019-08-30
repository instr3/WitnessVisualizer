using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitnessVisualizer
{
    abstract class PuzzleToolkitItem
    {
        public string Name { get; protected set; }
        public abstract Image GetImage(int width, int height);
    }
}
