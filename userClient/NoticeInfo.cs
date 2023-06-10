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
    public partial class NoticeInfo : UserControl
    {
        private string title;
        private string author;
        private string date;


        public NoticeInfo()
        {
            InitializeComponent();
            SetShape();

            noLbl.Text = "공지가 없습니다..";
        }


        public NoticeInfo(string title, string author, string date)
        {
            InitializeComponent();
            SetShape();

            this.title = title;
            titleLbl.Text = title;

            this.author = author;
            authorLbl.Text = "작성자:  " + author;

            this.date = date;
            dateLbl.Text = "등록일자:  " + date;
        }

        public void setNoticeInfo(string  title, string author, string date)
        {
            this.title = title;
            titleLbl.Text = title;

            this.author = author;
            authorLbl.Text = "작성자:  " + author;

            this.date = date;
            dateLbl.Text = "등록일자:  " + date;
        }


        public void setNoNotice()
        {
            noLbl.Text = "공지가 없습니다..";
        }



        public void textClear()
        {
            titleLbl.Text = "";
            authorLbl.Text = "";
            dateLbl.Text = "";
            noLbl.Text = "";
        }


        private void SetShape()
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, 200, 200);
                Region = new Region(path);
            }


        }
    }
}
