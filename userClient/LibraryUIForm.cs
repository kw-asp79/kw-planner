using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using CrawlingLibrary;

namespace Client
{
    public partial class LibraryUIForm : Form
    {
        private string id;
        private string pwd;

        private LibraryCrawler libraryCrawler;

       
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


        public void doWork()
        {
            crawlLibraryData();
            showState();
            showBookState();
        }


        public void crawlLibraryData()
        {
            libraryCrawler = new LibraryCrawler();

            libraryCrawler.doWork(id, pwd);

            //Thread libraryCrawlingThread = new Thread(new ThreadStart(libraryCrawler.loginLibrary));
            //libraryCrawlingThread.Start();

        }



        public void showState()
        {
            stateTbx.Text = "대출: " + libraryCrawler.getNumOfBooks() + "\r\n";
            stateTbx.AppendText("연체: " + libraryCrawler.getNumOfOverdue() + "\r\n");
            stateTbx.AppendText("미납 연체료: " +  libraryCrawler.getPriceToPay() + "\r\n");
        }



        public void showBookState()
        {
            int numOfBooks = Int32.Parse(libraryCrawler.getNumOfBooks());
            List<Book> books = libraryCrawler.books;
            int index = 1;

            foreach (Book book in books) {
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

        private void LibraryUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
