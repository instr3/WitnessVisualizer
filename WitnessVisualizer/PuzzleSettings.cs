using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitnessVisualizer
{
    class PuzzleSettings
    {
        private string tempUnit;
        private int tempValue;

        [Category("Global Settings"),
        ReadOnly(false),
        DefaultValue("Celsius")]
        public string TemperatureUnit
        {
            get { return tempUnit; }
            set { tempUnit = value; }
        }

        [Category("Global Settings"),
        ReadOnly(false),
        DefaultValue(2)]
        public int TemperatureValue
        {
            get { return tempValue; }
            set { tempValue = value; }
        }
    }
}
