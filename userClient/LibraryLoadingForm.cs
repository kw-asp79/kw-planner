using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrawlingLibrary;

namespace Client
{
    public partial class LibraryLoadingForm : Form
    {
        libraryLoginForm libLoginForm;
        LibraryCrawler libraryCrawler;

        public LibraryLoadingForm()
        {
            InitializeComponent();
        }

        public LibraryLoadingForm(libraryLoginForm lLoginForm, LibraryCrawler libCrawler)
        {
            InitializeComponent();

            this.libLoginForm = lLoginForm;

            this.libLoginForm.allSuccess += delegate (object sender, EventArgs e)
            {
                this.Close();
            };


            this.libraryCrawler = libCrawler;
            
            this.libraryCrawler.loginSuccessEvent += delegate (object sender, EventArgs e)
            {
                statusLbl.Font = new Font(statusLbl.Font.FontFamily,10,FontStyle.Regular);
                statusLbl.Text = "로그인 성공! 크롤링 작업이 진행 중입니다.. ";
                
            };

            this.libraryCrawler.crawlingEvent += delegate (object sender, EventArgs e)
            {
                
                int bookNum = Int32.Parse(this.libraryCrawler.getNumOfBooks());
                if (bookNum == 0)
                    this.crawlingPBar.Step = 100;
                else
                {
                    this.crawlingPBar.Step = 100 / bookNum;
                }

                this.crawlingPBar.PerformStep();
            };

        }




    }
}
