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
        KLASUIForm klasUIForm;

        public LoginForm(KLASUIForm klasUIForm)
        {
            InitializeComponent();
            this.klasUIForm = klasUIForm;
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            // id, pwd 잘 못 입력했을 때의 예외처리 필요
            
            klasUIForm.Show();

            
            Thread klasCrawlingThread = new Thread(() =>
                klasUIForm.doWork(idTbx.Text, pwdTbx.Text)
            );
            
            klasCrawlingThread.Start();

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
