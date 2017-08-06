using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Clipper_CRM_Software
{
    public partial class Login : Form
    {       
        public Login()
        {
           
            InitializeComponent();
            lbLoginError.Hide();
        }        

       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text=="user1" &&txtPassword.Text=="123")
            {
                lbLoginError.Hide();
               
                ManagerPanel managerPanel = new ManagerPanel();
                try
                {
                    managerPanel.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

               
            }
            else
            {
                lbLoginError.Text = "Invalid User Credentials";
                lbLoginError.ForeColor = Color.Red;
                lbLoginError.Show();

            }
        }
    }
}
