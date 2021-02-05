using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGraph
{
    public class TransformableDecorator : Decorator
    {
        [LocalizedDisplayName("DeltaX")]
        public double DeltaX { get; set; } = 0.0;
        [LocalizedDisplayName("DeltaY")]
        public double DeltaY { get; set; } = 0.0;
        [LocalizedDisplayName("Angle")]
        public double Angle { get; set; } = 0.0;
        [LocalizedDisplayName("ExtraScale")]
        public double ExtraScale { get; set; } = 1.0;
    }
}
