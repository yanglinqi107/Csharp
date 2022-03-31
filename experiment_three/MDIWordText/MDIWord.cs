using Demo.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIWordText
{
    public partial class MDIWord : Form
    {
        //public static String str = null;
        public static int childFormNumber = 0;
        private string fileName = null;
        public static System.Windows.Forms.StatusBarPanel curPosPanel;
        public static TabControlClose tabControl1;

        public MDIWord()
        {
            tabControl1 = new Demo.UC.TabControlClose();
            tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            tabControl1.ItemSize = new System.Drawing.Size(70, 24);
            tabControl1.Location = new System.Drawing.Point(0, 55);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(912, 475);
            tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabControl1.TabIndex = 6;

            curPosPanel = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)(curPosPanel)).BeginInit();

            InitializeComponent();
            

            this.newWindowToolStripMenuItem.Click += new System.EventHandler(ShowNewForm);
            this.newToolStripMenuItem.Click += new System.EventHandler(ShowNewForm);
            this.newToolStripButton.Click += new System.EventHandler(ShowNewForm);
        }

        private void MDIWord_Load(object sender,EventArgs e)
        {
            ShowNewForm(null, null);
            this.statusBar1.ShowPanels = true;

        }
        private static void ShowNewForm(object sender, EventArgs e)
        {
            TabPage tabPage = new TabPage();
            tabPage.Tag = childFormNumber;
            tabPage.Text = "new " + ++childFormNumber;
            tabPage.Name = tabPage.Text;
            //tabPage.Size = new System.Drawing.Size(10, 10);

            ChildForm page = new ChildForm();
            //page.MdiParent = this;
            page.Dock = System.Windows.Forms.DockStyle.Fill;
            page.Text = tabPage.Text;
            page.Name = page.Text;
            page.TopLevel = false;
            page.FormBorderStyle = FormBorderStyle.None;
            tabPage.Controls.Add(page);
            page.Show();
            MDIWord.tabControl1.TabPages.Add(tabPage);
            MDIWord.tabControl1.SelectedIndex = childFormNumber - 1;
            /*ChildForm childForm = new ChildForm();
            childForm.MdiParent = this;
            childForm.Text = "new " + childFormNumber;*/
            //this.LayoutMdi(MdiLayout.TileHorizontal);
            //this.LayoutMdi(MdiLayout.TileVertical);
            //this.LayoutMdi(MdiLayout.Cascade);
            //childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            fileName = openFileDialog.FileName;
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            if (childForm.RichTextBox_Length() != 0)
            {
                ShowNewForm(null, null);
                childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            }
            try
            {
                    childForm.OpenFile(fileName, RichTextBoxStreamType.RichText);
            }
            catch
            {
                childForm.OpenFile(fileName, RichTextBoxStreamType.PlainText);
            }
            tabControl1.TabPages[tabControl1.SelectedIndex].Text = fileName;
            /* if (openFileDialog.ShowDialog(this) == DialogResult.OK)
             {
                 string FileName = openFileDialog.FileName;
             }*/
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            childForm.IfSaveOldFile();
        }
        public static int IFSaveOldFile()
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            int ReturnValue = childForm.IfSaveOldFile();
            return ReturnValue;
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            tabControl1.TabPages[tabControl1.SelectedIndex].Text = childForm.SaveFile();
            /*String filename = this.tabControl1.TabPages[this.tabControl1.TabIndex].Text;
            if (childForm.textChange == true)
            {
                System.Windows.Forms.DialogResult dr = new DialogResult();
                dr = MessageBox.Show(this, "要保存当前更改吗？","保存更改吗？", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dr)
                {
                    case System.Windows.Forms.DialogResult.Yes: childForm.textChange = false; break;
                    case System.Windows.Forms.DialogResult.No:
                }
            }*/
            /*SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.FileName = this.tabControl1.TabPages[this.tabControl1.SelectedIndex].Text;
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;*/
          
            //childForm.SaveFile(saveFileDialog.FileName);
            //fileName = saveFileDialog.FileName;
            //this.tabControl1.TabPages[this.tabControl1.SelectedIndex].Text = saveFileDialog.FileName;
            /*if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }*/
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            childForm.richTextBox1_Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            childForm.richTextBox1_Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            childForm.richTextBox1_Paste();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
            statusBar1.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void saveToDatebaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            this.CutToolStripMenuItem_Click(sender, e);
        }
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            this.CopyToolStripMenuItem_Click(sender, e);
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            this.PasteToolStripMenuItem_Click(sender, e);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            childForm.richTextBox1_Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            childForm.richTextBox1_Redo();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            childForm.richTextBox1_Delete();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            childForm.richTextBox1_SelectAll();
        }
        private void formatColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ColorDialog colorDialog = new ColorDialog();
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            childForm.ChangeFormatColor();
        }

        private void typefaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            childForm.ChangeFormatFont();
        }

        private void FindChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFindReplace formFindReplace = new FormFindReplace(this);
            //formFindReplace.MdiParent = this;
            formFindReplace.Show();
        }

        public static int RichTextBox_Length()
        {
            ChildForm childForm = MDIWord.tabControl1.TabPages[MDIWord.tabControl1.SelectedIndex].Controls[0] as ChildForm;
            return childForm.RichTextBox_Length();
        }

        public int FindText(String text,int start)
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            int index = childForm.FindText(text,start);
            return index;
        }

        public void ReplaceText(String text)
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            childForm.ReplaceText(text);
        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            childForm.richTextBox1_Time();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            childForm.richTextBox1_Print();
        }

        public static void ShowNenForm(object sender, EventArgs e)
        {

            childFormNumber = 0;
            ShowNewForm(null, null);

        }

        public static bool GetTextChange()
        {
            ChildForm childForm = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChildForm;
            return childForm.textChange;
        }
    }
}
