using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;

namespace PuzzleGraph
{
    public class MetaData
    {
        public string PuzzleTitle { get; set; } = "";
        [XmlElement(Type = typeof(XmlColor))]
        public Color BackgroundColor { get; set; } = Color.LightGray;
        [XmlElement(Type = typeof(XmlColor))]
        public Color ForegroundColor { get; set; } = Color.DarkGray;
        public double EdgeWidth { get; set; } = 0.2;
        public TetrisTemplate TetrisTemplate { get; set; } = new TetrisTemplate();
        public double TetrisScale { get; set; } = 0.2;
        public double FaceDecorationScale { get; set; } = 1.0;
    }
}
