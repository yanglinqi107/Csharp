using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIWordText
{
    public partial class ChildForm : Form
    {
        public bool textChange = false;
        public ChildForm()
        {
            InitializeComponent();
        }

        public void richTextBox1_Cut()
        {
            this.richTextBox1.Cut();
        }

        public void richTextBox1_Copy()
        {
            this.richTextBox1.Copy();
        }

        public void richTextBox1_Paste()
        {
            this.richTextBox1.Paste();
        }

        public void richTextBox1_Undo()
        {
            this.richTextBox1.Undo();
        }
        public void richTextBox1_Redo()
        {
            this.richTextBox1.Redo();
        }

        public void richTextBox1_Delete()
        {
            this.richTextBox1.SelectedText = "";
        }

        public void richTextBox1_SelectAll()
        {
            this.richTextBox1.SelectAll();
        }

        public void richTextBox1_Time()
        {
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string time = null;
            time = currentTime.ToString("F");
            this.richTextBox1.Text += time;
        }

        public void richTextBox1_Print()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            PageSetupDialog ps = new PageSetupDialog();
            ps.Document = pd;
            ps.ShowDialog();
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void pd_PrintPage(object sender,PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, e.MarginBounds, new StringFormat());
        }

        public void OpenFile(string path, RichTextBoxStreamType fileType)
        {
            this.richTextBox1.LoadFile(path, fileType);
        }

        public String SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.FileName = this.Text;
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result != DialogResult.OK)
                return null;
            this.richTextBox1.SaveFile(saveFileDialog.FileName, System.Windows.Forms.RichTextBoxStreamType.PlainText);
            //this.richTextBox1.SaveFile(saveFileDialog.FileName);
            textChange = false;
            return saveFileDialog.FileName;
        }
        public int IfSaveOldFile()
        {
            int ReturnValue = 2;
            if (textChange)
            {
                System.Windows.Forms.DialogResult dr;
                dr = MessageBox.Show(this, "要保存当前更改吗？", "保存更改吗？",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dr)
                {
                    case System.Windows.Forms.DialogResult.Yes://单击了yes按钮，保存修改
                        SaveFile();
                        ReturnValue = 0;
                        break;
                    case System.Windows.Forms.DialogResult.No://单击了no按钮，不保存
                        ReturnValue = 1;
                        break;
                    case System.Windows.Forms.DialogResult.Cancel://单击了Cancel按钮
                        ReturnValue = 2;
                        break;
                }
            }
            else
            {
                SaveFile();
            }
            return ReturnValue;
        }
    
        public void ChangeFormatColor()
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            this.richTextBox1.SelectionColor = colorDialog.Color;
        }

        public void ChangeFormatFont()
        {
            FontDialog fontDialog = new FontDialog();
            DialogResult result = fontDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            this.richTextBox1.SelectionFont = fontDialog.Font;
        }

        public int FindText(String text,int start)
        {
            int index = this.richTextBox1.Find(text, start, RichTextBoxFinds.None);
            if (index < 0) 
            {
                if (start >= 0) 
                {
                    MessageBox.Show("已到文本底部，再次查找将从文本开始处查找", "提示");
                    return -1;
                }
                MessageBox.Show("查找不到", "提示");
                return -1;
            }
            this.richTextBox1.SelectionStart = index;
            this.richTextBox1.SelectionLength = text.Length;
            this.richTextBox1.Focus();
            return index;
        }

        public int RichTextBox_Length()
        {
            return richTextBox1.TextLength;
        }

        public void ReplaceText(String text)
        {
            richTextBox1.SelectedText = text;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            textChange = true;
            int pos = this.richTextBox1.SelectionStart;
            string text = this.richTextBox1.Text;
            int col = 0, row = 0;
            for (int p = 0; p < pos; p++) 
            {
                if (text[p] == '\n') 
                {
                    row++;
                    col = 0;
                    if (p + 1 < text.Length && text[p + 1] == 'r')
                        p++;
                }
                else
                {
                    col++;
                }
            }
            row++;
            col++;

            this.statusBar1.ShowPanels = true;
            this.curPosPanel.Text = "行" + row + "   列" + col;
            this.Ranks();
            //MDIWord.curPosPanel.Text = this.curPosPanel.Text;
            //this.statusBar1.Text = fileName;
        }
        private void Ranks()
        {
            /*  得到光标行第一个字符的索引，
             *  即从第1个字符开始到光标行的第1个字符索引*/
            int index = richTextBox1.GetFirstCharIndexOfCurrentLine();
            /*得到光标行的行号,第1行从0开始计算，习惯上我们是从1开始计算，所以+1。 */
            int line = richTextBox1.GetLineFromCharIndex(index) + 1;
            /*  SelectionStart得到光标所在位置的索引
             *  再减去
             *  当前行第一个字符的索引
             *  = 光标所在的列数(从0开始)  */
            int column = richTextBox1.SelectionStart - index + 1;
            //MessageBox.Show(" " + index + " " + column);
            MDIWord.curPosPanel.Text = string.Format("{0}行  {1}列", line.ToString(), column.ToString());
        }
        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.Ranks();  //按上、下、左、右时显示
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Ranks();  //点击鼠标时显示
        }
    }
}
