using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Client
{
    public partial class LoginForm : Form
    { 
        
        public LoginForm()
        {
            InitializeComponent();
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            


        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            SignUpForm form = new SignUpForm();
            form.ShowDialog();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            // esc 누르면 폼 종료
            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

       
    }
}
