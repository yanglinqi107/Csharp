using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Text = "单击";
            MessageBox.Show("啦啦啦啦啦啦啦啦绿", "标题");
            foreach (string s in listBox1.Items)
            {
                if (s == (string)comboBox1.SelectedItem)
                {
                    return;
                }
            }
            listBox1.Items.Add(comboBox1.Text);
        }

        private void button1_DoubleClick(object sender,MouseEventArgs e)
        {
            this.button1.Text = "双击";
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            this.button2.Text = "?";
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.label1.Text = "我是圣诞节欧思客反";
        }
    }
}
