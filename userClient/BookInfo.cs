using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class BookInfo : UserControl
    {
        private string title;
        private string author;
        private string location;
        private string loanDay;
        private string returnDay;

        public BookInfo()
        {
            InitializeComponent();

        }

        public BookInfo(string title, string author, string location, string loanDay, string returnDay)
        {

            InitializeComponent();

            this.title = title;
            this.author = author;
            this.location = location;
            this.loanDay = loanDay;
            this.returnDay = returnDay;

            titleLbl.Font = new Font(FontFamily.GenericSansSerif,10,FontStyle.Italic);
            titleLbl.Text = "제목: " + this.title;


            authorLbl.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic);
            authorLbl.Text = "저자: " + this.author;


            locationLbl.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic);
            locationLbl.Text = "청구기호: " + this.location;


            loanDayLbl.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic);
            loanDayLbl.Text = "대출일: " + this.loanDay;


            returnDayLbl.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic);
            returnDayLbl.Text = "반납일: " + this.returnDay;
        }


        public void SetShape()
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, 200, 200);
                Region = new Region(path);
            }

        }



    }
}
