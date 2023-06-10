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
using WindowsFormsApp1;

namespace Client
{

    public partial class KLASUIForm : UserControl
    {
        private string id;
        private string pwd;

        KLASCrawler klasCrawler;

        private Point[] noticePositions;

        private const int LEFT_NOTICE_XPOS = 100;
        private const int LEFT_NOTICE_YPOS = 240;

        private const int MID_NOTICE_XPOS = 380;
        private const int MID_NOTICE_YPOS = 55;

        private const int RIGHT_NOTICE_XPOS = 580;
        private const int RIGHT_NOTICE_YPOS = 280;

        NoticeInfo noticeInfo1 = new NoticeInfo();
        NoticeInfo noticeInfo2 = new NoticeInfo();
        NoticeInfo noticeInfo3 = new NoticeInfo();

        public KLASUIForm()
        {
            InitializeComponent();

            noticePositions = new Point[3];

            noticePositions[0] = new Point(MID_NOTICE_XPOS, MID_NOTICE_YPOS);
            noticePositions[1] = new Point(LEFT_NOTICE_XPOS,LEFT_NOTICE_YPOS);
            noticePositions[2] = new Point(RIGHT_NOTICE_XPOS,RIGHT_NOTICE_YPOS);

            noticeInfo1.Location = noticePositions[0];
            this.Controls.Add(noticeInfo1);
            noticeInfo2.Location = noticePositions[1];
            this.Controls.Add(noticeInfo2);
            noticeInfo3.Location = noticePositions[2];
            this.Controls.Add(noticeInfo3);
        }

        public CrawlingStatus.Status doWork(string id, string pwd,KLASCrawler klasCrawler)
        {
            this.id = id;
            this.pwd = pwd;

            this.klasCrawler = klasCrawler; 

            CrawlingStatus.Status status = klasCrawler.doWork(this.id, this.pwd);
            if (status == CrawlingStatus.Status.LoginFailure) return status;

            
            return CrawlingStatus.Status.AllSuccess;
        }


        public void setMainUI()
        {
            setUserName();

            // 만약 듣고 있는 강의가 최소 하나 이상이라면, 즉 휴학생이나 이런 조건의 학생이 아니라면
            if (klasCrawler.getLectureNum() > 0)
            {
                // 과목선택 ComboBox 과목 아이템 추가 
                List<Lecture> lectures = klasCrawler.lectures;
                foreach (Lecture lecture in lectures)
                    lectureListCBX.Items.Add(lecture.getName());

                lectureListCBX.Text = lectureListCBX.Items[0].ToString();
            }
            else
            {
                // 이번 학기에 듣는 강의가 없다면.. 
                lectureListCBX.Text = "아~ 이번 학기 안 다니시나봐요?";
                
            }
        }



        private void setUserName()
        {
            //lecNumTBX.Text = klasCrawler.getLectureNum().ToString();
            usernameLbl.Text = klasCrawler.getUsername();
        }


        // clear all TextBoxes : notice, onlinelecture, assignment, quiz, teamproject
        public void clearTBX()
        {
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
            noticeInfo1.textClear();
            noticeInfo2.textClear(); 
            noticeInfo3.textClear();

            if (notices.Count >= 3)
            {
                noticeInfo1.setNoticeInfo(notices[0].getTitle(), notices[0].getAuthor(), notices[0].getDate());
                noticeInfo2.setNoticeInfo(notices[1].getTitle(), notices[1].getAuthor(), notices[1].getDate());
                noticeInfo3.setNoticeInfo(notices[2].getTitle(), notices[2].getAuthor(), notices[2].getDate());
            }
            else if(notices.Count >= 2)
            {
                noticeInfo1.setNoticeInfo(notices[0].getTitle(), notices[0].getAuthor(), notices[0].getDate());
                noticeInfo2.setNoticeInfo(notices[1].getTitle(), notices[1].getAuthor(), notices[1].getDate());
                noticeInfo3.setNoNotice();
            }
            else if(notices.Count == 1)
            {
                noticeInfo1.setNoticeInfo(notices[0].getTitle(), notices[0].getAuthor(), notices[0].getDate());
                noticeInfo2.setNoNotice();
                noticeInfo3.setNoNotice();
            }
            else
            {
                noticeInfo1.setNoNotice();
                noticeInfo2.setNoNotice();
                noticeInfo3.setNoNotice();
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
                        olecTBX.AppendText("강의: " + onlineLecture.getTitle() + "\r\n");
                        olecTBX.AppendText("마감기한: " + onlineLecture.getDueDate() + "\r\n");
                        olecTBX.AppendText("학습률: " + onlineLecture.getPercentage() + "\r\n\r\n");
                    }
                    else
                        oLecDone++;
                }

                // 만약 온라인 강의를 전부 처리했다면
                if (onlineLectures.Count == oLecDone)
                    olecTBX.AppendText("게시된 온라인 강의를 전부 수강하였습니다 !! ");
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
                        quizTBX.AppendText("퀴즈: " + quiz.getTitle() + "\r\n");
                        quizTBX.AppendText("마감기한: " + quiz.getDueDate() + "\r\n\r\n");
                    }
                    else
                        numQuizDone++; 
                
                }

                if (quizs.Count == numQuizDone)
                    quizTBX.AppendText("출제된 퀴즈를 전부 응시하였습니다 !!");
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
                        amtTBX.AppendText("과제: " + assignment.getTitle() + "\r\n");
                        amtTBX.AppendText("마감기한: " + assignment.getDueDate() + "\r\n\r\n");
                    }
                    else
                        numAssignmentsDone++;
                }

                if (assignments.Count == numAssignmentsDone)
                    amtTBX.AppendText("출제된 과제를 전부 제출하였습니다 !!");
            }

        }


        public void setTeamProject(Lecture lecture)
        {
            List<TeamProject> teamProjects = lecture.getTeamProject();

            if (teamProjects.Count == 0)
            {
                tproTBX.AppendText("수업에서 출제된 팀 프로젝트가 없습니다. \r\n");
                
                //tproTBX.AppendText(lecture.getTime()[0] + "  " + lecture.getTime()[1]);
            }
            else
            {
                int numTeamsDone = 0;

                foreach (TeamProject teamProject in teamProjects)
                {
                    // 아직 제출하지 않은 팀프로젝트만 출력
                    if (string.Compare(teamProject.getState(), "제출") != 0)
                    {
                        tproTBX.AppendText("팀프로젝트: " + teamProject.getTitle() + "\r\n");
                        tproTBX.AppendText("마감기한: " + teamProject.getDueDate() + "\r\n\r\n");
                    }
                    else
                        numTeamsDone++;
                }

                if (teamProjects.Count == numTeamsDone)
                    tproTBX.AppendText("출제된 팀 프로젝트를 전부 제출하였습니다 !! ");
            }

        }

        private void klasUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }




    }
}
