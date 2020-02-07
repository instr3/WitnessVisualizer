using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WitnessVisualizer
{
    class FormHelper
    {
        internal static void ChangeDescriptionHeight(PropertyGrid grid, int height)
        {
            if (grid == null) throw new ArgumentNullException("grid");

            foreach (Control control in grid.Controls)
                if (control.GetType().Name == "DocComment")
                {
                    FieldInfo fieldInfo = control.GetType().BaseType.GetField("userSized",
                      BindingFlags.Instance |
                      BindingFlags.NonPublic);
                    fieldInfo.SetValue(control, true);
                    control.Height = height;
                    return;
                }
        }
    }
}
