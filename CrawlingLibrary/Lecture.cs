using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlingLibrary
{
     public class Lecture
    {
        private string Name;
        private string professorName;
        private string[] Time;
        private string[] Room;

        // assignments, quizes, notices, online lectures and team project
        private List<Notice> Notices;

        private List<Assignment> Assignments;

        private List<Quiz> Quizs;

        private List<OnlineLecture> OnlineLectures;

        private List<TeamProject> TeamProjects;



        public Lecture(string lectureName, string professorName, string[] lectureTime, string[] lectureRoom)
        {
            this.Name = lectureName;
            this.professorName = professorName;
            this.Time = lectureTime;
            this.Room = lectureRoom;

            Notices = new List<Notice>();
            Assignments = new List<Assignment>();   
            Quizs = new List<Quiz>();
            OnlineLectures = new List<OnlineLecture>();
            TeamProjects = new List<TeamProject>();
        }

        public string getName()
        {
            return Name;
        }

        public string getProfessorName()
        {
            return professorName;
        }

        public string[] getTime()
        {
            return Time;
        }
       

        public void setNotice(List<Notice> notices)
        {
            this.Notices = notices;
        }

        public List<Notice> getNotice()
        {
            return this.Notices;
        }


        public void setAssignment(List<Assignment> assignments)
        {
            this.Assignments = assignments;
        }

        public List<Assignment> getAssignment()
        {
            return Assignments;
        }

        public void setQuiz(List<Quiz> quizs)
        {
            this.Quizs = quizs;
        }

        public List<Quiz> getQuiz()
        {
            return Quizs;
        }

        public void setOnlineLecture(List<OnlineLecture> onlineLectures)
        {
            this.OnlineLectures = onlineLectures;
        }

        public List<OnlineLecture> getOnlineLecture()
        {
            return this.OnlineLectures;
        }

        public void setTeamProject(List<TeamProject> teamProjects)
        {
            this.TeamProjects = teamProjects;
        }


        public List<TeamProject> getTeamProject()
        {
            return this.TeamProjects;
        }


        public void printLectureDatas()
        {
            Console.WriteLine("Lecture Name : {0}", Name);
            Console.WriteLine("Professor Name : {0}", professorName);

            Console.WriteLine("Lecture Time : {0}, {1}", Time[0], Time[1]);
            Console.WriteLine("Lecture Room : {0}", Room);

        }



    }
}
