using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitnessVisualizer
{
    public class PuzzleToolkitMiscItem : PuzzleToolkitItem
    {
        public string IconPath { get; set; }
        Image icon;
        public PuzzleToolkitMiscItem(string inputName,string inputIconPath)
        {
            Name = inputName;
            IconPath = inputIconPath;
        }

        private PuzzleToolkitMiscItem() { }

        public override Image GetImage(int width, int height)
        {
            if(icon==null)
            {
                try
                {
                    icon = Image.FromFile(IconPath);
                }
                catch
                {
                    return null;
                }
            }
            return icon;
        }
    }
}
