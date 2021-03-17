using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuzzleGraph.Decorators
{
    public class ThreeWayPuzzleDecorator: TransformableDecorator, IFaceDecorable, IEdgeDecorable, INodeDecorable
    {
        [LocalizedDisplayName("SecondLineColor")]
        [XmlElement(Type = typeof(XmlColor))]
        public Color SecondLineColor { get; set; } = Color.Aqua;
        [LocalizedDisplayName("ThirdLineColor")]
        [XmlElement(Type = typeof(XmlColor))]
        public Color ThirdLineColor { get; set; } = Color.LightGreen;
    }
}
