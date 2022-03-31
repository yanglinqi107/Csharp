using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Login_Registration
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender,EventArgs e)
        {
            this.Location = new Point(700, 200);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User();

            if (textBox1.Text == "")
            {
                MessageBox.Show("用户名不能为空!", "提示");
                return;
            }
            else if(user.IsUserExit(textBox1.Text))
            {
                MessageBox.Show("用户名已存在！", "提示");
                return;
            }
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("两次密码输入不一致！", "提示");
                return;
            }
            else if (radioButton1.TabStop == false && radioButton2.Checked == false)
            {
                MessageBox.Show("请选择你的性别！", "提示");
                return;
            }
            else if (comboBox1.SelectedIndex == -1)  
            {
                MessageBox.Show("请选择你的专业！", "提示");
                return;
            }
            else
            {
                string sex = "";
                foreach (RadioButton rb in groupBox1.Controls)
                {
                    bool state = rb.Checked;
                    sex = rb.Text;
                }
                string str;
                str = String.Format("注册成功！用户名：{0}，密码：{1}，性别：{2}，专业：{3}", textBox1.Text, textBox2.Text, sex, comboBox1.Text);
                MessageBox.Show(str, "TRUE");

                user.name = this.textBox1.Text;
                user.password = this.textBox2.Text;
                user.gender = sex;
                user.major = this.comboBox1.Text;

                user.SaveUser();

                this.Close();
                //this.SetVisibleCore(false);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.comboBox1.SelectedIndex = -1;
            //this.comboBox1.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.SetVisibleCore(false);
            Login login = new Login();
            login.Show();
        }

    }
}
