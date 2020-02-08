using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;

namespace PuzzleGraph
{
    [LocalizedDisplayName("MetaData")]
    public class MetaData
    {
        [LocalizedDisplayName("PuzzleTitle")]
        public string PuzzleTitle { get; set; } = "";
        [LocalizedDisplayName("BackgroundColor")]
        [XmlElement(Type = typeof(XmlColor))]
        public Color BackgroundColor { get; set; } = Color.LightGray;
        [LocalizedDisplayName("ForegroundColor")]
        [XmlElement(Type = typeof(XmlColor))]
        public Color ForegroundColor { get; set; } = Color.DarkGray;
        [LocalizedDisplayName("EdgeWidth")]
        public double EdgeWidth { get; set; } = 0.2;
        [LocalizedDisplayName("TetrisTemplate")]
        public TetrisTemplate TetrisTemplate { get; set; } = new TetrisTemplate();
        [LocalizedDisplayName("TetrisScale")]
        public double TetrisScale { get; set; } = 0.2;
        [LocalizedDisplayName("FaceDecorationScale")]
        public double FaceDecorationScale { get; set; } = 1.0;
        [LocalizedDisplayName("ExportWidth")]
        public int ExportWidth { get; set; } = 768;
        [LocalizedDisplayName("ExportHeight")]
        public int ExportHeight { get; set; } = 768;
    }
}
