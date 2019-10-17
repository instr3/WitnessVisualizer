using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WitnessVisualizer
{
    [
        XmlInclude(typeof(PuzzleToolkitMiscItem)),
        XmlInclude(typeof(PuzzleToolkitDecoratorItem)),
    ]
    public abstract class PuzzleToolkitItem
    {
        public string Name { get; set; }
        public abstract Image GetImage(int width, int height);
    }
}
