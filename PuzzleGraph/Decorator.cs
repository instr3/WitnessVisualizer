using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using PuzzleGraph.Decorators;

namespace PuzzleGraph
{
    [
        XmlInclude(typeof(BrokenDecorator)),
        XmlInclude(typeof(EliminatorDecorator)),
        XmlInclude(typeof(EndDecorator)),
        XmlInclude(typeof(HollowTetrisDecorator)),
        XmlInclude(typeof(PointDecorator)),
        XmlInclude(typeof(SquareDecorator)),
        XmlInclude(typeof(StarDecorator)),
        XmlInclude(typeof(StartDecorator)),
        XmlInclude(typeof(TetrisDecorator)),
        XmlInclude(typeof(TriangleDecorator)),
    ]
    public abstract class Decorator : ICloneable
    {
        public object Clone()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer xml = new XmlSerializer(typeof(Decorator));
                xml.Serialize(ms, this);
                ms.Position = 0;
                return xml.Deserialize(ms);
            }
        }
    }
}
