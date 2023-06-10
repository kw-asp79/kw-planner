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
using WindowsFormsApp1;

namespace Client
{
    public partial class LibraryUIForm : UserControl
    {
      
        private string id;
        private string pwd;

        public LibraryCrawler libraryCrawler;


        private const int BOOK_START_XPOS = 50;
        private const int BOOK_START_YPOS = 350;
        private const int INTERVAL = 300;

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


        public CrawlingStatus.Status doWork(string id, string pwd,LibraryCrawler libraryCrawler)
        {
            this.libraryCrawler = libraryCrawler;
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
            int i = 0;

            // bookStateTbx.Clear();

            if (books.Count == 0)
            {
                bookStateLbl.Font = new Font(FontFamily.GenericMonospace,20,FontStyle.Italic);
                bookStateLbl.Text = "현재 빌린 책이 없습니다!!";

            }
            else
            {
                foreach (Book book in books)
                {
                    BookInfo bookInfo = new BookInfo(book.getBookTitle(), book.getBookAuthor(), book.getBookCallNumber(),
                                                     book.getBookBorrowedDay(), book.getBookReturnDay());


                    bookInfo.Location = new Point(BOOK_START_XPOS + INTERVAL * (i % 4), BOOK_START_YPOS + INTERVAL * (i / 4));

                    this.Controls.Add(bookInfo);

                    i++;
                }
            }

        }

    }

}
