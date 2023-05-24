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

namespace Client
{
    public partial class LibraryUIForm : UserControl
    {
      
        private string id;
        private string pwd;

        public LibraryCrawler libraryCrawler;

        public LibraryUIForm()
        {
            InitializeComponent();
        }


        public LibraryUIForm(string id, string pwd)
        {
            this.id = id;
            this.pwd = pwd;

            InitializeComponent();
        }


        public CrawlingStatus.Status doWork(string id, string pwd)
        {
            libraryCrawler = new LibraryCrawler();
            CrawlingStatus.Status status = libraryCrawler.doWork(id, pwd);
            if (status == CrawlingStatus.Status.LoginFailure) return status;

            return CrawlingStatus.Status.AllSuccess;
        }


        public void setUI()
        {
            showState();
            showBookState();

        }


        public void showState()
        {
            numOfBookLbl.Text = libraryCrawler.getNumOfBooks() + "권";

            overdueLbl.Text = libraryCrawler.getNumOfOverdue() + "권";

            priceToPayLbl.Text = libraryCrawler.getPriceToPay() + "원";
        }



        public void showBookState()
        {
            int numOfBooks = Int32.Parse(libraryCrawler.getNumOfBooks());
            List<Book> books = libraryCrawler.books;
            int index = 1;

           // bookStateTbx.Clear();

            foreach (Book book in books)
            {
                bookStateTbx.AppendText("No " + index + "#" + "\r\n");

                bookStateTbx.AppendText("이름: " + book.getBookTitle() + "\r\n");
                bookStateTbx.AppendText("저자: " + book.getBookAuthor() + "\r\n");
                bookStateTbx.AppendText("위치: " + book.getBookLocation() + "\r\n");
                bookStateTbx.AppendText("등록번호: " + book.getBookCallNumber() + "\r\n");
                bookStateTbx.AppendText("청구기호: " + book.getBookISBN() + "\r\n");
                bookStateTbx.AppendText("대출일: " + book.getBookBorrowedDay() + "\r\n");
                bookStateTbx.AppendText("반납일: " + book.getBookReturnDay() + "\r\n");
                bookStateTbx.AppendText("연장횟수: " + book.getBookRenewCount() + "\r\n");

                bookStateTbx.AppendText("\r\n\r\n");
                index++;
            }


        }

    }

}
