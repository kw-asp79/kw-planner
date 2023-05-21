using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlingLibrary
{
    public class OnlineLecture
    {
        private string title { get; set; }

        private string description { get; set; }

        private string deadline { get; set; }


        private string percentage { get; set; }



        public OnlineLecture(string title, string deadline, string percentage)
        {
            this.title = title;
            this.deadline = deadline;
            this.percentage = percentage;
        }

        public string getTitle()
        {
            return title;
        }

        public string getDescription()
        {
            return description;
        }

        public string getDeadline()
        {
            return deadline;
        }

        public string getPercentage()
        {
            return percentage;
        }



        public void printOnlineLectureDatas()
        {
            Console.WriteLine("title: " + this.title);
            Console.WriteLine("deadline: " + this.deadline);
            Console.WriteLine("percentage: " + this.percentage);
        }



    }
}
