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

        LibraryLoadingForm libraryLoadingForm;

        LibraryCrawler libraryCrawler;

        CrawlingStatus.Status status;

        public event EventHandler<AllSuccessEventArgs> allSuccess; // event of login and crawling success


        public bool loginStatus = false;

        public void setLoginStatus(bool status) { this.loginStatus = status; }
        public bool getLoginStatus() { return loginStatus; }

        public libraryLoginForm(LibraryUIForm libUIForm, LibraryCrawler libraryCrawler, NetworkStream netstrm)
        {
            InitializeComponent();

            this.netstrm = netstrm;
            this.status = CrawlingStatus.Status.BeforeLogin;
            this.libraryUIForm = libUIForm;
            this.libraryCrawler = libraryCrawler;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (status == CrawlingStatus.Status.BeforeLogin)
            {
                status = CrawlingStatus.Status.LoginProcess;

                libraryLoadingForm = new LibraryLoadingForm(this, libraryCrawler);
                libraryLoadingForm.Show();

                crawlingAsync();

            }
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
                libraryLoadingForm.Close();
                MessageBox.Show("로그인 실패! ID와 비밀번호를 다시 확인해주세요..","Library Login");
                status = CrawlingStatus.Status.BeforeLogin;
            }
            else
            {
                loginStatus = true;
            }

            if (status == CrawlingStatus.Status.AllSuccess)
            {
                allSuccess.Invoke(this, new AllSuccessEventArgs(this.libraryCrawler.getLibrarySchedules()));
            }
        }


    }
}
