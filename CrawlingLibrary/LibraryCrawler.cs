using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;
using CrawlingLibrary;

namespace Client
{
    public class LibraryCrawler
    {
        private string userName = "";
        private string numOfBooks = "";
        private string numOfOverdue = "";
        private string priceToPay = "";

        public List<Book> books = new List<Book>();

        private static ChromeDriverService chromeDriverService;
        private static ChromeDriver chromeDriver;

        public event EventHandler<EventArgs> loginSuccessEvent;

        public LibraryCrawler() { }

        public string getUserName() { return userName; }

        public string getNumOfBooks() { return numOfBooks; }

        public string getNumOfOverdue() {  return numOfOverdue; }

        public string getPriceToPay() {  return priceToPay; }

        public ChromeDriver GetChromeDriver() { return chromeDriver; }  


        public void initDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            //options.AddArgument("--disable-gpu");

            // network error issue: failed to resolve address for stun.services.mozilla.com error code: -105
            //options.AddArgument("--dns-prefetch-disable");
            options.AddArgument("--dns-server=8.8.8.8");
            options.AddArgument("log-level=2");

            chromeDriverService = ChromeDriverService.CreateDefaultService();
            // hide chromeDriver.exe 
            chromeDriverService.HideCommandPromptWindow = true;

            chromeDriver = new ChromeDriver(chromeDriverService, options);

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }



        // do all of things to do
        public CrawlingStatus.Status doWork(string id, string passwd)
        {
            initDriver();

            // divide result cases

            // 1. login success & crawl success 

            // 2. login success & crawl failed 

            // 3. login failed 


            CrawlingStatus.Status loginStatus = loginLibrary(id, passwd);

            // if error while login, return login failed status 
            if (loginStatus == CrawlingStatus.Status.LoginFailure)
            {
                endService();
                return loginStatus;
            }
            else // 로그인 성공이면 로그인 폼에서 크롤링 작업을 시작한다는 메시지를 띄우도록
                loginSuccessEvent.Invoke(this, new EventArgs());


            //*[@id="divContents"]/div[3]/div[3]/div[2]/ul/li[2]/span
            CrawlingStatus.Status crawlingStatus = crawlUserDatas();

            endService();

            return CrawlingStatus.Status.AllSuccess;
        }



        public CrawlingStatus.Status loginLibrary(string id, string passwd)
        {
            
            try
            {
                chromeDriver.Navigate().GoToUrl("https://kupis.kw.ac.kr/");
                Thread.Sleep(300);

                // send id and pwd data 
                var element = chromeDriver.FindElement(By.XPath("//*[@id=\"id\"]"));
                element.SendKeys(id);

                element = chromeDriver.FindElement(By.XPath("//*[@id=\"password\"]"));
                element.SendKeys(passwd);

                // automatically click login button 
                element = chromeDriver.FindElement(By.XPath("//*[@id=\"loginId\"]/div[2]/fieldset/input[3]"));
                element.Click();
                // Need to synchronize crawling moment and accessing web page! // 웹 페이지 접근 전에 데이터에 접근하는 에러 방지를 위해 
                Thread.Sleep(300);


                // if login failed, move to kupis.kw.ac.kr/login page
                if (isElementExists(chromeDriver,By.XPath("//*[@id=\"login\"]/fieldset/div[2]/ul/li/a/img")) == true)
                    return CrawlingStatus.Status.LoginFailure;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message + "Error while login process..");
                return CrawlingStatus.Status.LoginFailure;
            }

            return CrawlingStatus.Status.LoginSuccess;
        }


        // crawl user data from Library website
        private CrawlingStatus.Status crawlUserDatas()
        {

            try
            {
                // crawl number of books that I borrowed
                var numOfBooks = chromeDriver.FindElement(By.XPath("//*[@id=\"divContents\"]/div[3]/div[3]/div[2]/ul/li[2]/span"));
                this.numOfBooks = numOfBooks.Text.ToString();
                //Console.WriteLine(numOfBooks.Text.ToString());

                // crawl number of books that are overdue
                var numOfOverdue = chromeDriver.FindElement(By.XPath("//*[@id=\"divContents\"]/div[3]/div[3]/div[2]/ul/li[4]/span"));
                this.numOfOverdue = numOfOverdue.Text.ToString();
                //Console.WriteLine(numOfOverdue.Text.ToString());

                // crawl price that I have to pay for overdue
                var priceToPay = chromeDriver.FindElement(By.XPath("//*[@id=\"divContents\"]/div[3]/div[3]/div[2]/ul/li[6]/span"));
                this.priceToPay = priceToPay.Text.ToString();
                //Console.WriteLine(priceToPay.Text.ToString());

                int numBooks = Int32.Parse(numOfBooks.Text.ToString());

                // if user has borrowed some books
                if (numBooks != 0)
                {
                    // get books that user has borrowed
                   CrawlingStatus.Status detailCrawlingStatus = getBorrowedBooks(numBooks);
                   if (detailCrawlingStatus == CrawlingStatus.Status.CrawlingError) return CrawlingStatus.Status.CrawlingError;
                }

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message + "Error while login process..");
                return CrawlingStatus.Status.CrawlingError;
            }

            return CrawlingStatus.Status.CrawlingSuccess;
        }

 
        // "대출현황 조회/연장" page로 이동 and get books that user has rent
        private CrawlingStatus.Status getBorrowedBooks(int numOfBooks)
        {

            try
            {
                // "대출현황 조회/연장" page로 이동
                var element = chromeDriver.FindElement(By.XPath("//*[@id=\"divContents\"]/div[3]/div[3]/div[1]/div/ul/li[1]/a/img"));
                element.Click();

                // 마찬가지로 페이지 이동과 데이터를 가져오는 시점 일치를 위해 
                Thread.Sleep(300);

                string[] bookInfo = { "title", "author", "loct", "call_no", "accession_no", "loan_date", "return_plan_date", "renew_count" };

                // crawl book datas 
                for (int i = 0; i < numOfBooks; i++)
                {
                    string cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.title > a";
                    var bookTitle = chromeDriver.FindElement(By.CssSelector(cssSelector));
                    //Console.WriteLine("Book Title: " + bookTitle.Text.ToString());
                    string sBookTitle = bookTitle.Text.ToString();

                    cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.author";
                    var bookAuthor = chromeDriver.FindElement(By.CssSelector(cssSelector));
                    //Console.WriteLine("Book Author: " + bookAuthor.Text.ToString());
                    string sBookAuthor = bookAuthor.Text.ToString();

                    cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.loct";
                    var bookLocation = chromeDriver.FindElement(By.CssSelector(cssSelector));
                    //Console.WriteLine("Book Location: " + bookLocation.Text.ToString());
                    string sBookLocation = bookLocation.Text.ToString();


                    cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.call_no";
                    var bookCallNumber = chromeDriver.FindElement(By.CssSelector(cssSelector));
                    //Console.WriteLine("Book CallNumber: " + bookCallNumber.Text.ToString());
                    string sBookCallNumber = bookCallNumber.Text.ToString();

                    cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.accession_no";
                    var bookISBN = chromeDriver.FindElement(By.CssSelector(cssSelector));
                    //Console.WriteLine("Book ISBN: " + bookISBN.Text.ToString());
                    string sBookISBN = bookISBN.Text.ToString();


                    cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.loan_date";
                    var bookLoanDate = chromeDriver.FindElement(By.CssSelector(cssSelector));
                    //Console.WriteLine("Book LoanDate: " + bookLoanDate.Text.ToString());
                    string sBookLoanDate = bookLoanDate.Text.ToString();


                    cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.return_plan_date";
                    var bookReturnDate = chromeDriver.FindElement(By.CssSelector(cssSelector));
                    //Console.WriteLine("Book Return Date: " + bookReturnDate.Text.ToString());
                    string sBookReturnDate = bookReturnDate.Text.ToString();


                    cssSelector = "#divList > table > tbody > tr:nth-child(" + (i + 1) + ") > td.renew_count";
                    var bookRenewCount = chromeDriver.FindElement(By.CssSelector(cssSelector));
                    //Console.WriteLine("Book RenewCount: " + bookRenewCount.Text.ToString());
                    string sBookRenewCount = bookRenewCount.Text.ToString();


                    Book book = new Book(sBookTitle, sBookAuthor, sBookLocation, sBookCallNumber, sBookISBN, sBookLoanDate, sBookReturnDate, sBookRenewCount);
                    books.Add(book);
                }

            }
            catch(Exception e)
            {
                //Console.WriteLine("Error while crawling getBorrowedBooks()");
                return CrawlingStatus.Status.CrawlingError;
            }

            return CrawlingStatus.Status.CrawlingSuccess;
        }


        private void printBookDatas(List<Book> books)
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


        public void endService()
        {
            chromeDriver.Quit();
        }



    }
}
