using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIWordText
{
    public partial class TabControlPro : TabControl
    {
        public TabControlPro()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            //this.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.MainTab_DrawItem);
        }
    }
}
