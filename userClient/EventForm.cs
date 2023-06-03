using EntityLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Client.UserControlDays;
using WindowsFormsApp1;
using static Client.EventForm;
using System.Collections;
using System.Net.Sockets;
using PacketLibrary;
using Google.Protobuf.WellKnownTypes;
using System.CodeDom;

//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Client
{
    public partial class EventForm : Form
    {

        UserControlDays UserControlDays;

        NetworkStream netstrm;
        mainForm mainform;
        User myUserInfo = mainForm.myUserInfo;

        CheckBox[] checkBox = new CheckBox[20];
        Button[] deletebtn = new Button[20];
        Label[] start = new Label[20];
        Label[] end = new Label[20];
        Label[] content = new Label[20];
        Label[] title = new Label[20];
        int labelWidth = 50;
        int labelHeight = 25;
        List<Schedule> daySchedules;
        int lbcount; // 클래스의 멤버 변수로 선언
        int k;
        public EventForm(UserControlDays form)
        {
            
            UserControlDays = form;
            daySchedules = form.getSchedules();
            InitializeComponent();

            schedule_load();
            lbcount = daySchedules.Count;
            k = lbcount+1 ;
            //int lbcount = daySchedules.Count;
        }

        
        //public delegate void DateSelectedHandler(int day, string dayOfWeek);
        //public event DateSelectedHandler DateSelected;

        private void schedule_load()
        {
            daySchedules = daySchedules.OrderBy(schedule => schedule.startTime).ToList();
            for (int i = 1; i <= daySchedules.Count; i++)
            {
                checkBox[i] = new CheckBox();
                checkBox[i].Location = new Point(0, -20+30*i);
                checkBox[i].Size = new Size(labelWidth, labelHeight);
                checkBox[i].Tag = i;
                checkBox[i].Checked = daySchedules[i - 1].isDone;

                start[i] = new Label();
                start[i].Location = new Point(checkBox[i].Location.X + 50, checkBox[i].Location.Y);
                start[i].Size = new Size(labelWidth *3, labelHeight+5);
                start[i].Font = new Font("Ink Free", 11, FontStyle.Regular);
                start[i].Text = daySchedules[i - 1].startTime.ToString("yyyy-MM-dd HH:mm");
                start[i].Tag = i;

                end[i] = new Label();
                end[i].Location = new Point(start[i].Location.X + 150, start[i].Location.Y);
                end[i].Size = new Size(labelWidth*3, labelHeight);
                end[i].Font = new Font("Ink Free", 11, FontStyle.Regular);
                end[i].Text = daySchedules[i - 1].endTime.ToString("yyyy-MM-dd HH:mm");
                end[i].Tag = i;

                title[i] = new Label();
                title[i].Location = new Point(end[i].Location.X + 150, end[i].Location.Y);
                title[i].Size = new Size(labelWidth*2, labelHeight);
                title[i].Font = new Font("Ink Free", 11, FontStyle.Regular);
                title[i].Text = daySchedules[i - 1].title;
                title[i].Tag = i;

                content[i] = new Label();
                content[i].Location = new Point(title[i].Location.X + 100, title[i].Location.Y);
                content[i].Size = new Size(labelWidth*5, labelHeight);
                content[i].Font = new Font("Ink Free", 11, FontStyle.Regular);
                content[i].Text = daySchedules[i - 1].content;
                content[i].Tag = i;

                deletebtn[i] = new Button();
                deletebtn[i].Location = new Point(content[i].Location.X+300,content[i].Location.Y);
                deletebtn[i].Size = new Size(labelWidth, labelHeight);
                deletebtn[i].Text = "삭제";
                deletebtn[i].Tag = i;


                checkBox[i].Click += new EventHandler(CheckBox_CheckedChanged);
                deletebtn[i].Click += new EventHandler(DeleteButton_Click);

                panel1.Controls.Add(deletebtn[i]);
                panel1.Controls.Add(checkBox[i]);
                panel1.Controls.Add(start[i]);
                panel1.Controls.Add(end[i]);
                panel1.Controls.Add(content[i]);
                panel1.Controls.Add(title[i]);

                if (daySchedules[i - 1].isDone)
                {
                    checkBox[i].Checked = true;
                    start[i].Font = new Font(start[i].Font, FontStyle.Strikeout);
                    end[i].Font = new Font(end[i].Font, FontStyle.Strikeout);
                    title[i].Font = new Font(title[i].Font, FontStyle.Strikeout);
                    content[i].Font = new Font(content[i].Font, FontStyle.Strikeout);
                }

            }

        }


        //int cntlbl = daySchedules.Count;

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day,
                dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, 0);

            DateTime endDateTime = new DateTime(dtpEndDate.Value.Year, dtpEndDate.Value.Month, dtpEndDate.Value.Day,
                dtpEndTime.Value.Hour, dtpEndTime.Value.Minute, 0);

            Schedule eventschedule = new Schedule();
            int A = mainForm.schedules.Count;
            eventschedule.id = A;
            eventschedule.startTime = startDateTime;
            eventschedule.endTime = endDateTime;
            eventschedule.category = "CUSTOM";
            eventschedule.title = tbTitle.Text;
            eventschedule.content = tbSchedule.Text;
            eventschedule.fromWho = "0";
            eventschedule.isDone = false;
            mainForm.schedules.Add(eventschedule);
            A++;

            checkBox[k] = new CheckBox();
            checkBox[k].Location = new Point(0, -20+30*k);
            checkBox[k].Size = new Size(labelWidth, labelHeight);
            checkBox[k].Tag = k;

            start[k] = new Label();
            start[k].Location = new Point(checkBox[k].Location.X + 50, checkBox[k].Location.Y);
            start[k].Size = new Size(labelWidth * 3, labelHeight + 5);
            start[k].Font = new Font("Ink Free", 11, FontStyle.Regular);
            start[k].Text = startDateTime.ToString("yyyy-MM-dd HH:mm");
            start[k].Tag = k;

            end[k] = new Label();
            end[k].Location = new Point(start[k].Location.X + 150, start[k].Location.Y);
            end[k].Size = new Size(labelWidth * 3, labelHeight);
            end[k].Font = new Font("Ink Free", 11, FontStyle.Regular);
            end[k].Text = endDateTime.ToString("yyyy-MM-dd HH:mm");
            end[k].Tag = k;

            title[k] = new Label();
            title[k].Location = new Point(end[k].Location.X + 150, end[k].Location.Y);
            title[k].Size = new Size(labelWidth*2, labelHeight);
            title[k].Font = new Font("Ink Free", 11, FontStyle.Regular);
            title[k].Text = tbTitle.Text;
            title[k].Tag = k;

            content[k] = new Label();
            content[k].Location = new Point(title[k].Location.X + 100, title[k].Location.Y);
            content[k].Size = new Size(labelWidth * 5, labelHeight);
            content[k].Font = new Font("Ink Free", 11, FontStyle.Regular);
            content[k].Text = tbSchedule.Text;
            content[k].Tag = k;

            deletebtn[k] = new Button();
            deletebtn[k].Location = new Point(content[k].Location.X + 300, content[k].Location.Y);
            deletebtn[k].Size = new Size(labelWidth, labelHeight);
            deletebtn[k].Text = "삭제";
            deletebtn[k].Tag = k;

            checkBox[k].Click += new EventHandler(CheckBox_CheckedChanged);
            deletebtn[k].Click += new EventHandler(DeleteButton_Click);

            panel1.Controls.Add(deletebtn[k]);
            panel1.Controls.Add(checkBox[k]);
            panel1.Controls.Add(start[k]);
            panel1.Controls.Add(end[k]);
            panel1.Controls.Add(content[k]);
            panel1.Controls.Add(title[k]);

            lbcount++;
            k++;

            daySchedules.Add(eventschedule); // daySchedules에 새로운 일정 추가
            daySchedules = daySchedules.OrderBy(schedule => schedule.startTime).ToList(); // startTime을 기준으로 일정 정렬

            ClearEventForm(); // 이벤트 폼 초기화
            RenderSchedules();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int index = (int)btn.Tag;

            string deleteTitle = title[index].Text;
            string deleteContent = content[index].Text;

            // mainForm의 schedules 리스트에서 해당하는 스케줄을 찾아 삭제
            for (int i = 0; i < mainForm.schedules.Count; i++)
            {
                Schedule schedule = mainForm.schedules[i];
                if (schedule.title == deleteTitle && schedule.content == deleteContent)
                {
                    mainForm.schedules.RemoveAt(i);
                    break;
                }
            }


            if (index < k - 1)
            {
                // 아래에 있는 스케줄들을 한 칸씩 위로 올림
                for (int i = index; i < k - 1; i++)
                {
                    start[i].Text = start[i + 1].Text;
                    end[i].Text = end[i + 1].Text;
                    title[i].Text = title[i + 1].Text;
                    content[i].Text = content[i + 1].Text;
                }
            }

            // 마지막 스케줄의 컨트롤들을 제거
            panel1.Controls.Remove(deletebtn[k - 1]);
            panel1.Controls.Remove(checkBox[k - 1]);
            panel1.Controls.Remove(start[k - 1]);
            panel1.Controls.Remove(end[k - 1]);
            panel1.Controls.Remove(content[k - 1]);
            panel1.Controls.Remove(title[k - 1]);

            // k 변수를 감소시킴
            k--;
        }

        private void ClearEventForm()
        {
            tbTitle.Text = "";
            tbSchedule.Text = "";
            // 나머지 입력 필드들을 초기화
        }
        private void RenderSchedules()
        {
            panel1.Controls.Clear(); // panel1의 모든 컨트롤 제거

            for (int i = 0; i < daySchedules.Count; i++)
            {
                // CheckBox 생성 및 설정
                CheckBox checkBox = new CheckBox();
                checkBox.Location = new Point(0, 10 + 30 * i);
                checkBox.Size = new Size(labelWidth, labelHeight);
                checkBox.Tag = i;
                checkBox.Click += new EventHandler(CheckBox_CheckedChanged);

                // Start 레이블 생성 및 설정
                Label startLabel = new Label();
                startLabel.Location = new Point(checkBox.Location.X + 50, checkBox.Location.Y);
                startLabel.Size = new Size(labelWidth * 3, labelHeight + 5);
                startLabel.Font = new Font("Ink Free", 11, FontStyle.Regular);
                startLabel.Text = daySchedules[i].startTime.ToString("yyyy-MM-dd HH:mm");
                startLabel.Tag = i;

                // End 레이블 생성 및 설정
                Label endLabel = new Label();
                endLabel.Location = new Point(startLabel.Location.X + 150, startLabel.Location.Y);
                endLabel.Size = new Size(labelWidth * 3, labelHeight);
                endLabel.Font = new Font("Ink Free", 11, FontStyle.Regular);
                endLabel.Text = daySchedules[i].endTime.ToString("yyyy-MM-dd HH:mm");
                endLabel.Tag = i;

                // Title 레이블 생성 및 설정
                Label titleLabel = new Label();
                titleLabel.Location = new Point(endLabel.Location.X + 150, endLabel.Location.Y);
                titleLabel.Size = new Size(labelWidth * 2, labelHeight);
                titleLabel.Font = new Font("Ink Free", 11, FontStyle.Regular);
                titleLabel.Text = daySchedules[i].title;
                titleLabel.Tag = i;

                // Content 레이블 생성 및 설정
                Label contentLabel = new Label();
                contentLabel.Location = new Point(titleLabel.Location.X + 100, titleLabel.Location.Y);
                contentLabel.Size = new Size(labelWidth * 5, labelHeight);
                contentLabel.Font = new Font("Ink Free", 11, FontStyle.Regular);
                contentLabel.Text = daySchedules[i].content;
                contentLabel.Tag = i;

                // Delete 버튼 생성 및 설정
                Button deleteButton = new Button();
                deleteButton.Location = new Point(contentLabel.Location.X + 300, contentLabel.Location.Y);
                deleteButton.Size = new Size(labelWidth, labelHeight);
                deleteButton.Text = "삭제";
                deleteButton.Tag = i;
                deleteButton.Click += new EventHandler(DeleteButton_Click);

                // 생성한 컨트롤들을 panel1에 추가
                panel1.Controls.Add(checkBox);
                panel1.Controls.Add(startLabel);
                panel1.Controls.Add(endLabel);
                panel1.Controls.Add(titleLabel);
                panel1.Controls.Add(contentLabel);
                panel1.Controls.Add(deleteButton);
            }
        }


        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            int index = (int)checkBox.Tag;
            string deleteTitle = title[index].Text;
            string deleteContent = content[index].Text;

            if (checkBox.Checked)
            {
                // 체크 표시 및 회색선 설정
                start[index].Font = new Font(start[index].Font, FontStyle.Strikeout);
                end[index].Font = new Font(end[index].Font, FontStyle.Strikeout);
                title[index].Font = new Font(title[index].Font, FontStyle.Strikeout);
                content[index].Font = new Font(content[index].Font, FontStyle.Strikeout);
                for (int i = 0; i < mainForm.schedules.Count; i++)
                {
                    Schedule schedule = mainForm.schedules[i];
                    if (schedule.title == deleteTitle && schedule.content == deleteContent)
                    {
                        schedule.isDone = true;
                        break;
                    }
                }
            }
            else
            {
                // 체크 표시 및 회색선 제거
                start[index].Font = new Font(start[index].Font, FontStyle.Regular);
                end[index].Font = new Font(end[index].Font, FontStyle.Regular);
                title[index].Font = new Font(title[index].Font, FontStyle.Regular);
                content[index].Font = new Font(content[index].Font, FontStyle.Regular);
                for (int i = 0; i < mainForm.schedules.Count; i++)
                {
                    Schedule schedule = mainForm.schedules[i];
                    if (schedule.title == deleteTitle && schedule.content == deleteContent)
                    {
                        schedule.isDone = false;
                        break;
                    }
                }
            }
        }


    }
}
