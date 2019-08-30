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
    }
    /*[XmlInclude(typeof(Color)), XmlInclude(typeof(Point))]
    public class NewObjectClass
    {
        public object Object { get; set; }
    }*/
}
