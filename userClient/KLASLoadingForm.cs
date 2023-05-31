using Client;
using CrawlingLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class KLASLoadingForm : Form
    {
        KLASLoginForm klasLoginForm;
        KLASCrawler klasCrawler;


        public KLASLoadingForm()
        {
            InitializeComponent();
        }


        public KLASLoadingForm(KLASLoginForm kLoginForm, KLASCrawler kCrawler) { 
        
            InitializeComponent();

            this.klasLoginForm = kLoginForm;

            this.klasLoginForm.allSuccess += delegate (object sender, EventArgs e)
            {
                this.Close();
            };


            this.klasCrawler = kCrawler;

            this.klasCrawler.loginSuccessEvent += delegate (object sender, EventArgs e)
            {
                statusLbl.Text = "";

                crawlingLbl.Font = new Font(statusLbl.Font.FontFamily, 10, FontStyle.Regular);
                crawlingLbl.Text = "로그인 성공! KLAS 크롤링 작업이 진행 중입니다.. ";

            };

            this.klasCrawler.crawlingEvent += delegate (object sender, EventArgs e)
            {

                int lectureNum = this.klasCrawler.getLectureNum();
                if (lectureNum == 0)
                    this.crawlingPBar.Step = 100;
                else
                {
                    this.crawlingPBar.Step = 100 / lectureNum;
                }

                this.crawlingPBar.PerformStep();
            };

        }
    }
}
