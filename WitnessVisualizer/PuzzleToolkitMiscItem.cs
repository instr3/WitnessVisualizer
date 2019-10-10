using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitnessVisualizer
{
    class PuzzleToolkitMiscItem : PuzzleToolkitItem
    {
        Image icon;
        public PuzzleToolkitMiscItem(string inputName,Image inputIcon)
        {
            Name = inputName;
            icon = inputIcon;
        }

        public override Image GetImage(int width, int height)
        {
            return icon;
        }
    }
}
