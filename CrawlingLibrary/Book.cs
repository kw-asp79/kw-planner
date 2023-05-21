using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlingLibrary
{
    public class Book
    {
        private string title;
        private string author;
        private string location;
        private string callNumber;
        private string ISBN;
        private string borrowedDay;
        private string returnDay;
        private string renewCount;

        public Book(string bookTitle,string bookAuthor,string bookLocation,string bookCallNumber,string bookISBN,string bookBorrowedDay,string bookReturnDay, string bookRenewCount) 
        {
            this.title = bookTitle;
            this.author = bookAuthor;
            this.location = bookLocation;
            this.callNumber = bookCallNumber;
            this.ISBN = bookISBN;
            this.borrowedDay = bookBorrowedDay;
            this.returnDay = bookReturnDay;
            this.renewCount = bookRenewCount;

        }

        public string getBookTitle()
        {
            return title;
        }

        public string getBookAuthor()
        {
            return author;
        }

        public string getBookLocation()
        {
            return location;
        }

        public string getBookCallNumber()
        {
            return callNumber;
        }

        public string getBookISBN()
        {
            return ISBN;
        }

        public string getBookBorrowedDay()
        {
            return borrowedDay;
        }

        public string getBookReturnDay()
        {
            return returnDay;
        }

        public String getBookRenewCount()
        {
            return renewCount;
        }


        public void printBookDatas()
        {
            Console.WriteLine("Book Title: " + this.title + "\n");
            Console.WriteLine("Book Author: " + this.author + "\n");
            Console.WriteLine("Book Location: " + this.location + "\n");
            Console.WriteLine("Book CallNumber: " + this.callNumber + "\n");
            Console.WriteLine("Book ISBN: " + this.ISBN + "\n");
            Console.WriteLine("Book Borrowed Day: " + this.borrowedDay + "\n");
            Console.WriteLine("Book Return Day: " + this.returnDay + "\n");
            Console.WriteLine("Book RenewTime: " + this.renewCount + "\n");
        }




    }
}
