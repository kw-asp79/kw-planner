using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Book
    {
        private string bookTitle;
        private string bookAuthor;
        private string bookLocation;
        private string bookCallNumber;
        private string bookISBN;
        private string bookBorrowedDay;
        private string bookReturnDay;
        private string bookRenewTime;

        public Book(string bookTitle,string bookAuthor,string bookLocation,string bookCallNumber,string bookISBN,string bookBorrowedDay,string bookReturnDay, string bookRenewTime) 
        {
            this.bookTitle = bookTitle;
            this.bookAuthor = bookAuthor;
            this.bookLocation = bookLocation;
            this.bookCallNumber = bookCallNumber;
            this.bookISBN = bookISBN;
            this.bookBorrowedDay = bookBorrowedDay;
            this.bookReturnDay = bookReturnDay;
            this.bookRenewTime = bookRenewTime;

        }


        public void printBookDatas()
        {
            Console.WriteLine("Book Title: " + this.bookTitle + "\n");
            Console.WriteLine("Book Author: " + this.bookAuthor + "\n");
            Console.WriteLine("Book Location: " + this.bookLocation + "\n");
            Console.WriteLine("Book CallNumber: " + this.bookCallNumber + "\n");
            Console.WriteLine("Book ISBN: " + this.bookISBN + "\n");
            Console.WriteLine("Book Borrowed Day: " + this.bookBorrowedDay + "\n");
            Console.WriteLine("Book Return Day: " + this.bookReturnDay + "\n");
            Console.WriteLine("Book RenewTime: " + this.bookRenewTime + "\n");
        }





    }
}
