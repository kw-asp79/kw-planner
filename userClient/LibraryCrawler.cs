﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Client
{
    internal class LibraryCrawler
    {
        List<Book> books = new List<Book>();


        public LibraryCrawler() { }



        // do all of things to do
        public void doWork()
        {





        }



        public void loginLibrary()
        {
            string id = "";
            string passwd = "";

            ChromeDriverService chromeDriverService;
            ChromeDriver chromeDriver;

            try
            {
                ChromeOptions options = new ChromeOptions();
                //options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");

                chromeDriverService = ChromeDriverService.CreateDefaultService();
                chromeDriver = new ChromeDriver(chromeDriverService, options);
                chromeDriver.Navigate().GoToUrl("https://kupis.kw.ac.kr/");

                chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                // send id and pwd data 
                var element = chromeDriver.FindElement(By.XPath("//*[@id=\"id\"]"));
                element.SendKeys(id);

                element = chromeDriver.FindElement(By.XPath("//*[@id=\"password\"]"));
                element.SendKeys(passwd);

                // automatically click login button 
                element = chromeDriver.FindElement(By.XPath("//*[@id=\"loginId\"]/div[2]/fieldset/input[3]"));
                element.Click();


                //*[@id="divContents"]/div[3]/div[3]/div[2]/ul/li[2]/span
                crawlUserDatas(chromeDriver);

                printBookDatas(books);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Error while login process..");
            }

        }


        // crawl user data from Library website
        public void crawlUserDatas(ChromeDriver chromeDriver)
        {

            try
            {
                // crawl number of books that I borrowed
                var numOfBooks = chromeDriver.FindElement(By.XPath("//*[@id=\"divContents\"]/div[3]/div[3]/div[2]/ul/li[2]/span"));
                Console.WriteLine(numOfBooks.Text.ToString());

                // crawl number of books that are overdue
                var numOfOverdue = chromeDriver.FindElement(By.XPath("//*[@id=\"divContents\"]/div[3]/div[3]/div[2]/ul/li[4]/span"));
                Console.WriteLine(numOfOverdue.Text.ToString());

                // crawl price that I have to pay for overdue
                var priceToPay = chromeDriver.FindElement(By.XPath("//*[@id=\"divContents\"]/div[3]/div[3]/div[2]/ul/li[6]/span"));
                Console.WriteLine(priceToPay.Text.ToString());

                int numBooks = Int32.Parse(numOfBooks.Text.ToString());

                Console.WriteLine("Books that I borrowed.. \n\n");
                // if user has borrowed some books
                if (numBooks != 0)
                {
                    // get books that user has borrowed
                    getBorrowedBooks(chromeDriver,numBooks);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Error while login process..");
            }

        }

 
        // get books that user has rent
        public void getBorrowedBooks(ChromeDriver chromeDriver,int numOfBooks)
        {
            var element = chromeDriver.FindElement(By.XPath("//*[@id=\"divContents\"]/div[3]/div[3]/div[1]/div/ul/li[1]/a/img"));
            element.Click();

            string[] bookInfo = {"title","author","loct","call_no","accession_no","loan_date","return_plan_date","renew_count" };

            // crawl book datas 
            for (int i=0; i<numOfBooks;i++) 
            {
                string cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.title > a";
                var bookTitle = chromeDriver.FindElement(By.CssSelector(cssSelector));
                Console.WriteLine("Book Title: " + bookTitle.Text.ToString());
                string sBookTitle = bookTitle.Text.ToString();

                cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.author";
                var bookAuthor = chromeDriver.FindElement(By.CssSelector(cssSelector));
                Console.WriteLine("Book Author: " + bookAuthor.Text.ToString());
                string sBookAuthor = bookAuthor.Text.ToString();

                cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.loct";
                var bookLocation = chromeDriver.FindElement(By.CssSelector(cssSelector));
                Console.WriteLine("Book Location: " + bookLocation.Text.ToString());
                string sBookLocation = bookLocation.Text.ToString();    


                cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.call_no";
                var bookCallNumber = chromeDriver.FindElement(By.CssSelector(cssSelector));
                Console.WriteLine("Book CallNumber: " + bookCallNumber.Text.ToString());
                string sBookCallNumber = bookCallNumber.Text.ToString();

                cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.accession_no";
                var bookISBN = chromeDriver.FindElement(By.CssSelector(cssSelector));
                Console.WriteLine("Book ISBN: " + bookISBN.Text.ToString());
                string sBookISBN = bookISBN.Text.ToString();


                cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.loan_date";
                var bookLoanDate = chromeDriver.FindElement(By.CssSelector(cssSelector));
                Console.WriteLine("Book LoanDate: " + bookLoanDate.Text.ToString());
                string sBookLoanDate = bookLoanDate.Text.ToString();


                cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.return_plan_date";
                var bookReturnDate = chromeDriver.FindElement(By.CssSelector(cssSelector));
                Console.WriteLine("Book Return Date: " + bookReturnDate.Text.ToString());
                string sBookReturnDate = bookReturnDate.Text.ToString();


                cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.renew_count";
                var bookRenewCount = chromeDriver.FindElement(By.CssSelector(cssSelector));
                Console.WriteLine("Book RenewCount: " + bookRenewCount.Text.ToString());
                string sBookRenewCount = bookRenewCount.Text.ToString();


                Book book = new Book(sBookTitle, sBookAuthor, sBookLocation, sBookCallNumber, sBookISBN, sBookLoanDate, sBookReturnDate, sBookRenewCount);
                books.Add(book);
            }




        }





        public void printBookDatas(List<Book> books)
        {
            foreach (var book in books)
                book.printBookDatas();        
        }




        // check corresponding element exists 
        private bool isElementExists(ChromeDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }







    }
}
