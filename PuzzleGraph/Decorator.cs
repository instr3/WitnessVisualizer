using System;
using System.Collections.Generic;
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
    public abstract class Decorator
    {

    }
}
