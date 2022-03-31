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
    public partial class FormFindReplace : Form
    {
        private int SearchIndex = 0;
        private MDIWord mainForm;
        private bool judge = true;
        public FormFindReplace(MDIWord form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void FormFindReplace_Load(object sender, EventArgs e)
        {     
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length!=0)
            {
                this.SearchIndex = mainForm.FindText(textBox1.Text,this.SearchIndex);
                if (this.SearchIndex == -1) 
                {
                    this.SearchIndex = 0;
                    judge = false;
                    return;
                }
                else
                {
                    this.SearchIndex += textBox1.Text.Length;
                }
            }
           /* if(SearchIndex>=mainForm.RichTextBox_Length())
            {
                MessageBox.Show("已到文本底部，再次查找将从文本开始处查找", "提示");
            }*/
           else
            {
                MessageBox.Show("查找字符串不能为空", "提示", MessageBoxButtons.OK);
                judge = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.ReplaceText(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchIndex = 0;
            judge = true;
            do
            {
                button1_Click(null, null);
                if (judge)
                    button2_Click(null, null);
            } while (judge);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchIndex = 0;
        }
    }
}
