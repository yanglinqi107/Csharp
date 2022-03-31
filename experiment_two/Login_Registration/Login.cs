using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Login_Registration
{
    public partial class Login : Form
    {
        //private Container components = null;
        private System.Windows.Forms.Label label1;
        private Label label2;
        private TextBox textbox1;
        private TextBox textbox2;
        private Button button1;
        public Login()
        {
            InitializeComponent();
            //this.SetVisibleCore(true);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Location = new Point(400, 400);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Register register = new Register();
            register.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User user = new User();
            int back = user.IsUserExit(textbox1.Text, textbox2.Text);
            if (back == 2)
            {
                MessageBox.Show("用户名不存在，请先注册！", "提示");
                return;
            }
            else if (back == 1) 
            {
                MessageBox.Show("密码错误！", "提示");
                return;
            }
            else
            {
                MessageBox.Show("登录成功！", "TRUE");
                //this.SetVisibleCore(false);
                this.Close();
            }
        }

        /*protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(components!=null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }*/

        /* private override void InitializeComponent()
         {
             this.label1 = new Label();
             this.label2 = new Label();
             this.label1.Name = "用户名";
             this.label2.Name = "密码";
         }*/
    }
}
