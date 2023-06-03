using Client;
using CrawlingLibrary;
using EntityLibrary;
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

namespace Client
{
    public class AllSuccessEventArgs : EventArgs
    {
        public List<Schedule> schedules;
        public AllSuccessEventArgs(List<Schedule> schedules)
        {
            this.schedules = schedules;
        }

        public List<Schedule> getSchedules()
        {
            return this.schedules;
        }

    }


    public partial class KLASLoginForm : UserControl
    {
        KLASUIForm klasUIForm;

        KLASCrawler klasCrawler;

        CrawlingStatus.Status status;

        public event EventHandler<AllSuccessEventArgs> allSuccess;

        public bool loginStatus = false;

        public void setLoginStatus(bool status) { this.loginStatus = status; }
        public bool getLoginStatus() { return loginStatus;}

        public KLASLoginForm(KLASUIForm klasUIForm,KLASCrawler kLasCrawler)
        {
            InitializeComponent();

            this.klasUIForm = klasUIForm;
            this.klasCrawler = kLasCrawler;
            this.klasCrawler.loginSuccessEvent += crawlingMessage;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            crawlingAsync();
        }

        private async void crawlingAsync()
        {
            var klasCrawlingTask = Task.Run(() =>
                klasUIForm.doWork(idTbx.Text, pwdTbx.Text,this.klasCrawler)
            );

            status = await klasCrawlingTask;

            // login 결과에 따라 libraryUIForm을 보여줄지 login error를 띄우며 그대로 loginForm 유지할지.    
            if (status == CrawlingStatus.Status.LoginFailure)
            {
                MessageBox.Show("로그인 실패! ID와 비밀번호를 다시 확인해주세요..", "KLAS Login");
            }
            else
            {
                loginStatus = true;
            }

            if (status == CrawlingStatus.Status.AllSuccess)
            {
                allSuccess.Invoke(this, new AllSuccessEventArgs(this.klasCrawler.getKLASSchedules()));
            }

        }


        private void crawlingMessage(Object sender, EventArgs e)
        {
            MessageBox.Show("로그인 성공! 크롤링 작업이 진행됩니다!!.. ", "KLAS Crawling Process");
        }



    }
}
