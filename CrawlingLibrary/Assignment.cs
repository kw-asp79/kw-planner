using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlingLibrary
{
    public class Assignment
    {
        private string title {  get; set; }

        // 내용은 빼는 걸 고려 
        private string description { get; set; }

        private string deadline { get; set; }

        private string state { get; set; }


        public Assignment(string title, string deadline, string state)
        {
            this.title = title;
            this.deadline = deadline;
            this.state = state;
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

        public string getState()
        {
            return state;
        }


        public void printAssignmentDate()
        {
            Console.WriteLine("title: " + this.title);

            Console.WriteLine("deadline: " + this.deadline);
            Console.WriteLine("state: " + this.state);
        }


    }
}
