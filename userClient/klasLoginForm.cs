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
    public partial class klasLoginForm : UserControl
    {
        Control calendarContainer;

        public klasLoginForm()
        {
            InitializeComponent();
        }

        public klasLoginForm(Control Container)
        {
            InitializeComponent();

            calendarContainer = Container;
        }



        private void loginBtn_Click(object sender, EventArgs e)
        {

            // id, pwd 잘 못 입력했을 때의 예외처리 필요
            /*klasUIForm klasUIForm = new klasUIForm(idTbx.Text,pwdTbx.Text);
            klasUIForm.Show();
            

            Thread klasCrawlingThread = new Thread(new ThreadStart(klasUIForm.doWork));
            klasCrawlingThread.Start();*/
            
        }
    }
}
