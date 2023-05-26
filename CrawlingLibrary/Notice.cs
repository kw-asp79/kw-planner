using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlingLibrary
{
    public class Notice
    {
        private string title { get; set; }

        // 내용은 빼는 걸 고려
        private string description { get; set; }
        private string author { get; set; }
        private string date { get; set; }

        private string viewCount { get; set; }


        public Notice(string title, string description,string author, string date, string viewCount) 
        {
            this.title = title;
            this.description = description;
            this.author = author;
            this.date = date;
            this.viewCount = viewCount;
        }


        public string getTitle()
        {
            return title;
        }

        public string getDescription() { return description; }

        public string getAuthor()
        {
          return author;
        }

        public string getDate()
        {
            return date;
        }

        public string getViewCount()
        {
            return viewCount;
        }



        public void printNotice()
        {
            Console.WriteLine("title: " + this.title);
            Console.WriteLine("내용: " + this.description);
            Console.WriteLine("author: " + this.author);
            Console.WriteLine("date: " + this.date);
            Console.WriteLine("ViewCount: " + this.viewCount);
        }








    }
}
