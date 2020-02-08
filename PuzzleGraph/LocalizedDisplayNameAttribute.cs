using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGraph
{
    class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        private readonly string resourceName;
        public LocalizedDisplayNameAttribute(string resourceName) : base()
        {
            this.resourceName = resourceName;
        }

        public override string DisplayName
        {
            get
            {
                return Resources.Lang.ResourceManager.GetString(this.resourceName) ?? "";
            }
        }
    }
}
