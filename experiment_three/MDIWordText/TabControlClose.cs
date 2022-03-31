
using MDIWordText;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Demo.UC
{
    public class  TabControlClose: TabControl
    {
        private int IconWOrH = 15;
        private Image icon = null;
        //private MDIWord mainform;
        public TabControlClose()
            : base()
        {
            //mainform = new MDIWord();
            this.DrawMode = TabDrawMode.OwnerDrawFixed;

            icon = MDIWordText.Properties.Resources.close1;
            icon = icon.GetThumbnailImage(icon.Width - 10, icon.Height - 10, () => false, IntPtr.Zero);
            IconWOrH = icon.Width;
            IconWOrH = icon.Height;
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = GetTabRect(e.Index);
            if (e.Index == this.SelectedIndex)    //当前选中的Tab页，设置不同的样式以示选中
            {
                Brush selected_color = Brushes.White; //选中的项的背景色
                g.FillRectangle(selected_color, r); //改变选项卡标签的背景色 
                string title = this.TabPages[e.Index].Text;
                g.DrawString(title, this.Font, new SolidBrush(Color.Black), new PointF(r.X + 3, r.Y + 5));//PointF选项卡标题的位置 
                r.Offset(r.Width - IconWOrH - 3, 4);
                g.DrawImage(icon, new Point(r.X, r.Y));//选项卡上的图标的位置 fntTab = new System.Drawing.Font(e.Font, FontStyle.Bold);
            }
            else//非选中的
            {
                Brush selected_color = Brushes.DarkGray; //选中的项的背景色
                g.FillRectangle(selected_color, r); //改变选项卡标签的背景色 
                string title = this.TabPages[e.Index].Text + "  ";
                g.DrawString(title, this.Font, new SolidBrush(Color.Black), new PointF(r.X + 3, r.Y + 5));//PointF选项卡标题的位置 
                r.Offset(r.Width - IconWOrH - 3, 4);
                g.DrawImage(icon, new Point(r.X, r.Y));//选项卡上的图标的位置 
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
           // mainform = form;
            int ReturnValue = -1;
            Point point = e.Location;
            Rectangle r = GetTabRect(this.SelectedIndex);
            r.Offset(r.Width - IconWOrH - 3, 2);
            r.Width = IconWOrH;
            r.Height = IconWOrH;
            if (r.Contains(point)) 
            {
                if (MDIWord.RichTextBox_Length() != 0 && MDIWord.GetTextChange()) 
                {
                    ReturnValue = MDIWord.IFSaveOldFile();
                }
                if (ReturnValue != 2)
                {
                    if (this.TabCount == 1)
                    {
                        this.TabPages.RemoveAt(this.SelectedIndex);
                        MDIWord.childFormNumber--;
                        MDIWord.ShowNenForm(null, null);
                    }
                    else
                    {
                        this.TabPages.RemoveAt(this.SelectedIndex);
                        MDIWord.childFormNumber--;
                        this.SelectedIndex = MDIWord.childFormNumber - 1;
                    }
                }
            }
        }
    }
}
