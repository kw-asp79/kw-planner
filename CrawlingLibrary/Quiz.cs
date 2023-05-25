using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlingLibrary
{
    public class Quiz
    {

        private string title { get; set; }

        private string deadline { get; set; }

        private string dueDate { get; set; }
        private string state { get; set; }


        public Quiz(string title, string deadline, string state)
        {
            this.title = title;
            this.deadline = deadline;
            this.dueDate = this.deadline.Split('~')[1].Split(' ')[1];
            this.state = state;
        }


        public string getTitle()
        {
            return title;
        }

        public string getDeadline()
        {
            return deadline;
        }

        public string getDueDate()
        {
            return dueDate;
        }

        public string getState()
        {
            return state;
        }



        public void printQuizData()
        {
            Console.WriteLine("title: " + this.title);
            Console.WriteLine("deadline: " + this.deadline);
            Console.WriteLine("state: " + this.state);

        }

    }
}
