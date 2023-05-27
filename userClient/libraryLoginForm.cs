using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using CrawlingLibrary;
using EntityLibrary;

namespace Client
{
    public partial class libraryLoginForm : UserControl
    {

        NetworkStream netstrm;
        LibraryUIForm libraryUIForm;

        LibraryCrawler libraryCrawler;

        CrawlingStatus.Status status;

        public event EventHandler<EventArgs> allSuccess; // event of login and crawling success


        public bool loginStatus = false;

        public void setLoginStatus(bool status) { this.loginStatus = status; }
        public bool getLoginStatus() { return loginStatus; }

        public libraryLoginForm(LibraryUIForm libUIForm, LibraryCrawler libraryCrawler, NetworkStream netstrm)
        {
            InitializeComponent();

            this.netstrm = netstrm;
            this.libraryUIForm = libUIForm;
            this.libraryCrawler = libraryCrawler;
            this.libraryCrawler.loginSuccessEvent += crawlingMessage;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            crawlingAsync();
        }

        private async void crawlingAsync()
        {
            var libCrawlingTask = Task.Run(() =>
                libraryUIForm.doWork(idTbx.Text, pwdTbx.Text,this.libraryCrawler)
            );

            status = await libCrawlingTask;

            // login 결과에 따라 libraryUIForm을 보여줄지 login error를 띄우며 그대로 loginForm 유지할지.            
            if (status == CrawlingStatus.Status.LoginFailure)
            {
                MessageBox.Show("로그인 실패! ID와 비밀번호를 다시 확인해주세요..","Library Login");
            }
            else
            {
                loginStatus = true;
            }

            if (status == CrawlingStatus.Status.AllSuccess)
            {
                allSuccess.Invoke(this, new EventArgs());
            }
        }



        private void crawlingMessage(Object sender, EventArgs e)
        {
            MessageBox.Show("로그인 성공! 크롤링 작업이 진행됩니다!! .. ", "Library Crawling Process");
        }

    }
}
