using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph.Decorators
{
    public class SymmetryPuzzleDecorator: TransformableDecorator, IFaceDecorable, IEdgeDecorable, INodeDecorable, IUnifiedScaleDecorator
    {
        [LocalizedDisplayName("SecondLineColor")]
        [XmlElement(Type = typeof(XmlColor))]
        public Color SecondLineColor { get; set; } = Color.Aqua;

        [LocalizedDisplayName("IsRotational")]
        public bool IsRotational { get; set; } = false;
    }
}
