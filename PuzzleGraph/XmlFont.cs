using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph
{
    class XmlFont
    {
        private Font font_ = SystemFonts.DefaultFont;

        public XmlFont() { }
        public XmlFont(Font font) { font_ = font; }

        public static implicit operator Font(XmlFont x)
        {
            return x.font_;
        }

        public static implicit operator XmlFont(Font font)
        {
            return new XmlFont(font);
        }

        // Code from https://stackoverflow.com/questions/19263202/how-to-serialize-font
        public static string FromFont(Font font)
        {
            return font.FontFamily.Name
                    + ":" + font.Size
                    + ":" + font.Style
                    + ":" + font.Unit
                    + ":" + font.GdiCharSet
                    + ":" + font.GdiVerticalFont
                    ;
        }
        public static Font ToFont(string value)
        {
            var parts = value.Split(':');
            return new Font(
                new FontFamily(parts[0]),                                                   // FontFamily.Name
                float.Parse(parts[1]),                                      // Size
                EnumSerializationHelper.FromString<FontStyle>(parts[2]),    // Style
                EnumSerializationHelper.FromString<GraphicsUnit>(parts[3]), // Unit
                byte.Parse(parts[4]),                                       // GdiCharSet
                bool.Parse(parts[5])                                        // GdiVerticalFont
            );
        }

        [XmlText]
        public string Default
        {
            get { return FromFont(font_); }
            set { font_ = ToFont(value); }
        }

    }
    [TypeConverter(typeof(EnumConverter))]
    static public class EnumSerializationHelper
    {

        static public T FromString<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
