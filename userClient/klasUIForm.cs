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

namespace Client
{

    public partial class KLASUIForm : UserControl
    {
        private string id;
        private string pwd;

        KLASCrawler klasCrawler;



        public KLASUIForm()
        {
            InitializeComponent();

            klasCrawler = new KLASCrawler();

        }

        public CrawlingStatus.Status doWork(string id, string pwd)
        {
            this.id = id;
            this.pwd = pwd;

            CrawlingStatus.Status status = klasCrawler.doWork(this.id, this.pwd);
            if (status == CrawlingStatus.Status.LoginFailure) return status;

            
            return CrawlingStatus.Status.AllSuccess;
        }


        public void setMainUI()
        {
            setUserName();

            // 과목선택 ComboBox 과목 아이템 추가 
            List<Lecture> lectures = klasCrawler.lectures;
            foreach (Lecture lecture in lectures)
                lectureListCBX.Items.Add(lecture.getName());

            lectureListCBX.Text = lectureListCBX.Items[0].ToString();

        }



        private void setUserName()
        {
            //lecNumTBX.Text = klasCrawler.getLectureNum().ToString();
            usernameLbl.Text = klasCrawler.getUsername();
        }


        // clear all TextBoxes : notice, onlinelecture, assignment, quiz, teamproject
        public void clearTBX()
        {
            noticeTBX.Clear();
            olecTBX.Clear();
            amtTBX.Clear();
            quizTBX.Clear();
            tproTBX.Clear();
        }

        private void lectureListCBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 우선 각 텍스트박스 지우기 
            clearTBX();

            if (lectureListCBX.SelectedIndex >= 0)
            {
                List<Lecture> lectures = klasCrawler.lectures;
                string targetLectureName = lectureListCBX.SelectedItem.ToString();
                Lecture targetLecture = lectures.FirstOrDefault(lecture => lecture.getName() == targetLectureName);

                setNotice(targetLecture);
                setOnlineLecture(targetLecture);
                setAssignment(targetLecture);
                setQuiz(targetLecture);
                setTeamProject(targetLecture);
            }

        }


        public void setNotice(Lecture lecture)
        {
            List<Notice> notices = lecture.getNotice();

            if (notices.Count == 0)
                noticeTBX.AppendText("공지가 없습니다. ");
            else
            {
                foreach (Notice notice in notices)
                {
                    noticeTBX.AppendText("No #" + "\r\n");
                    noticeTBX.AppendText("Title: " + notice.getTitle() + "\r\n");
                    noticeTBX.AppendText("Author: " + notice.getAuthor() + "\r\n");
                    noticeTBX.AppendText("Date: " + notice.getDate() + "\r\n");
                    noticeTBX.AppendText("ViewCount: " + notice.getViewCount() + "\r\n");
                }
            }

        }


        public void setOnlineLecture(Lecture lecture)
        {
            List<OnlineLecture> onlineLectures = lecture.getOnlineLecture();

            if (onlineLectures.Count == 0)
                olecTBX.AppendText("수업에서 게시된 온라인 강의가 없습니다.");
            else
            {
                int oLecDone = 0;

                foreach (OnlineLecture onlineLecture in onlineLectures)
                {   
                    // 아직 다 듣지 않은 온라인 강의만 출력
                    if (onlineLecture.getPercentage().Contains("100%") != true)
                    {
                        olecTBX.AppendText("No #" + "\r\n");
                        olecTBX.AppendText("Title: " + onlineLecture.getTitle() + "\r\n");
                        olecTBX.AppendText("Deadline: " + onlineLecture.getDeadline() + "\r\n");
                        olecTBX.AppendText("Percentage: " + onlineLecture.getPercentage() + "\r\n");
                    }
                    else
                        oLecDone++;
                }

                // 만약 온라인 강의를 전부 처리했다면
                if (onlineLectures.Count == oLecDone)
                    olecTBX.AppendText("수강해야할 온라인 강의가 없습니다.. ");
            }

        }


        public void setQuiz(Lecture lecture)
        {
            List<Quiz> quizs = lecture.getQuiz();

            if (quizs.Count == 0)
                quizTBX.AppendText("수업에서 출제된 퀴즈가 없습니다. ");
            else
            {
                int numQuizDone = 0;

                foreach (Quiz quiz in quizs)
                {   
                    // 아직 진행하지 않은 퀴즈만 출력
                    if (string.Compare(quiz.getState(), "응시") != 0)
                    {
                        quizTBX.AppendText("No #" + "\r\n");
                        quizTBX.AppendText("Title: " + quiz.getTitle() + "\r\n");
                        quizTBX.AppendText("Deadline: " + quiz.getDeadline() + "\r\n");
                        quizTBX.AppendText("State: " + quiz.getState() + "\r\n");
                    }
                    else
                        numQuizDone++; 
                
                }

                if (quizs.Count == numQuizDone)
                    quizTBX.AppendText("진행해야할 퀴즈가 없습니다..");
            }
        }


        public void setAssignment(Lecture lecture)
        {
            List<Assignment> assignments = lecture.getAssignment();

            if (assignments.Count == 0)
                amtTBX.AppendText("수업에서 출제된 과제가 없습니다. ");
            else
            {
                int numAssignmentsDone = 0;

                foreach (Assignment assignment in assignments)
                {
                    // 아직 제출하지 않은 과제만 출력
                    if (string.Compare(assignment.getState(), "제출") != 0)
                    {
                        amtTBX.AppendText("No #" + "\r\n");
                        amtTBX.AppendText("Title: " + assignment.getTitle() + "\r\n");
                        amtTBX.AppendText("Deadline: " + assignment.getDeadline() + "\r\n");
                        amtTBX.AppendText("State: " + assignment.getState() + "\r\n");
                    }
                    else
                        numAssignmentsDone++;
                }

                if (assignments.Count == numAssignmentsDone)
                    amtTBX.AppendText("진행해야할 과제가 없습니다.. ");
            }

        }


        public void setTeamProject(Lecture lecture)
        {
            List<TeamProject> teamProjects = lecture.getTeamProject();

            if (teamProjects.Count == 0)
                tproTBX.AppendText("수업에서 출제된 팀 프로젝트가 없습니다. ");
            else
            {
                int numTeamsDone = 0;

                foreach (TeamProject teamProject in teamProjects)
                {

                    if (string.Compare(teamProject.getState(), "제출") != 0)
                    {
                        tproTBX.AppendText("No #" + "\r\n");
                        tproTBX.AppendText("Title: " + teamProject.getTitle() + "\r\n");
                        tproTBX.AppendText("Deadline: " + teamProject.getDeadline() + "\r\n");
                        tproTBX.AppendText("State: " + teamProject.getState() + "\r\n");
                    }
                    else
                        numTeamsDone++;
                }

                if (teamProjects.Count == numTeamsDone)
                    tproTBX.AppendText("진행해야할 팀 프로젝트가 없습니다.. ");
            }

        }

        private void klasUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }




    }
}
