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
        XmlInclude(typeof(CircleDecorator)),
        XmlInclude(typeof(RingDecorator)),
        XmlInclude(typeof(TextDecorator)),
        XmlInclude(typeof(CombinedDecorator)),
        XmlInclude(typeof(SymmetryPuzzleDecorator)),
    ]
    public abstract class Decorator : ICloneable
    {
        public virtual bool IsFaceDecorable() => this is IFaceDecorable;
        public virtual bool IsEdgeDecorable() => this is IEdgeDecorable;
        public virtual bool IsNodeDecorable() => this is INodeDecorable;

        public bool IsDecorableFor(GraphElement element)
        {
            return (element is Node && IsNodeDecorable()) ||
                (element is Edge && IsEdgeDecorable()) ||
                (element is Face && IsFaceDecorable());
        }
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
        public override string ToString()
        {
            return Resources.Lang.ResourceManager.GetString(this.GetType().Name) ?? this.GetType().Name;
        }
    }
}
