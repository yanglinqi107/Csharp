using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Registration
{
    
    public partial class Main_interface : Form
    {

        public Main_interface()
        {
            InitializeComponent();
            /*this.Size = new Size(1500, 800);
            this.Text = "用户信息管理";*/
            //this.SetVisibleCore(true);
            //Application.Run(new Login());
           
        }

        private void Main_interface_Load(object sender,EventArgs e)
        {
            this.Location = new Point(100, 100);
            Login login = new Login();
            login.Show();
        }

        /* public static void login()
         {
             Application.Run(new Main_interface());
         }*/
    }

}
