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

        NetworkStream netstrm = mainForm.netstrm;
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
        
        List<Schedule> daySchedules; // userControlDays 통해 받은 스케줄들
       
        int lbcount; // 클래스의 멤버 변수로 선언
        
        public static event EventHandler<EventFormArgs> saveEvent;
        public static event EventHandler<EventFormArgs> deleteEvent;

        public EventForm(UserControlDays form)
        {

            UserControlDays = form;
            daySchedules = form.getSchedules();
            InitializeComponent();

            schedule_load();
            lbcount = daySchedules.Count;
        }
        //public delegate void DateSelectedHandler(int day, string dayOfWeek);
        //public event DateSelectedHandler DateSelected;

        private void schedule_load()
        {
            daySchedules = daySchedules.OrderBy(schedule => schedule.startTime).ToList();
            for (int i = 0; i < daySchedules.Count; i++)
            {
                checkBox[i] = new CheckBox();
                checkBox[i].Location = new Point(0, -20 + 30 * (i+1));
                checkBox[i].Size = new Size(labelWidth, labelHeight);
                checkBox[i].Tag = i;
                checkBox[i].Checked = daySchedules[i].isDone;

                start[i] = new Label();
                start[i].Location = new Point(checkBox[i].Location.X + 50, checkBox[i].Location.Y);
                start[i].Size = new Size(labelWidth * 3, labelHeight + 5);
                start[i].Font = new Font("Ink Free", 11, FontStyle.Regular);
                start[i].Text = daySchedules[i].startTime.ToString("yyyy-MM-dd HH:mm");
                start[i].Tag = i;

                end[i] = new Label();
                end[i].Location = new Point(start[i].Location.X + 150, start[i].Location.Y);
                end[i].Size = new Size(labelWidth * 3, labelHeight);
                end[i].Font = new Font("Ink Free", 11, FontStyle.Regular);
                end[i].Text = daySchedules[i].endTime.ToString("yyyy-MM-dd HH:mm");
                end[i].Tag = i;

                title[i] = new Label();
                title[i].Location = new Point(end[i].Location.X + 150, end[i].Location.Y);
                title[i].Size = new Size(labelWidth * 2, labelHeight);
                title[i].Font = new Font("Ink Free", 11, FontStyle.Regular);
                title[i].Text = daySchedules[i].title;
                title[i].Tag = i;

                content[i] = new Label();
                content[i].Location = new Point(title[i].Location.X + 100, title[i].Location.Y);
                content[i].Size = new Size(labelWidth * 5, labelHeight);
                content[i].Font = new Font("Ink Free", 11, FontStyle.Regular);
                content[i].Text = daySchedules[i].content;
                content[i].Tag = i;

                deletebtn[i] = new Button();
                deletebtn[i].Location = new Point(content[i].Location.X + 300, content[i].Location.Y);
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

                if (daySchedules[i].isDone)
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
                
            // 새로운 스케줄을 mainForm에 추가
            Schedule eventschedule = new Schedule();
            eventschedule.startTime = startDateTime;
            eventschedule.endTime = endDateTime;
            eventschedule.category = "CUSTOM";
            eventschedule.title = tbTitle.Text;
            eventschedule.content = tbContent.Text;
            eventschedule.fromWho = "";
            eventschedule.isDone = false;
            mainForm.schedules.Add(eventschedule);

            Dictionary<string, Object> fullData = new Dictionary<string, object>();
            fullData.Add("schedule", eventschedule);
            fullData.Add("user", myUserInfo);

            Packet packet = new Packet();
            packet.action = ActionType.saveSchedule;
            packet.data = fullData;

            Packet.SendPacket(netstrm, packet);
            packet = Packet.ReceivePacket(netstrm);

            daySchedules.Add(eventschedule);

            checkBox[lbcount] = new CheckBox();
            checkBox[lbcount].Location = new Point(0, -20 + 30 * (lbcount+1));
            checkBox[lbcount].Size = new Size(labelWidth, labelHeight);
            checkBox[lbcount].Tag = lbcount;

            start[lbcount] = new Label();
            start[lbcount].Location = new Point(checkBox[lbcount].Location.X + 50, checkBox[lbcount].Location.Y);
            start[lbcount].Size = new Size(labelWidth * 3, labelHeight + 5);
            start[lbcount].Font = new Font("Ink Free", 11, FontStyle.Regular);
            start[lbcount].Text = startDateTime.ToString("yyyy-MM-dd HH:mm");
            start[lbcount].Tag = lbcount;

            end[lbcount] = new Label();
            end[lbcount].Location = new Point(start[lbcount].Location.X + 150, start[lbcount].Location.Y);
            end[lbcount].Size = new Size(labelWidth * 3, labelHeight);
            end[lbcount].Font = new Font("Ink Free", 11, FontStyle.Regular);
            end[lbcount].Text = endDateTime.ToString("yyyy-MM-dd HH:mm");
            end[lbcount].Tag = lbcount;

            title[lbcount] = new Label();
            title[lbcount].Location = new Point(end[lbcount].Location.X + 150, end[lbcount].Location.Y);
            title[lbcount].Size = new Size(labelWidth * 2, labelHeight);
            title[lbcount].Font = new Font("Ink Free", 11, FontStyle.Regular);
            title[lbcount].Text = tbTitle.Text;
            title[lbcount].Tag = lbcount;

            content[lbcount] = new Label();
            content[lbcount].Location = new Point(title[lbcount].Location.X + 100, title[lbcount].Location.Y);
            content[lbcount].Size = new Size(labelWidth * 5, labelHeight);
            content[lbcount].Font = new Font("Ink Free", 11, FontStyle.Regular);
            content[lbcount].Text = tbContent.Text;
            content[lbcount].Tag = lbcount;

            deletebtn[lbcount] = new Button();
            deletebtn[lbcount].Location = new Point(content[lbcount].Location.X + 300, content[lbcount].Location.Y);
            deletebtn[lbcount].Size = new Size(labelWidth, labelHeight);
            deletebtn[lbcount].Text = "삭제";
            deletebtn[lbcount].Tag = lbcount;

            checkBox[lbcount].Click += new EventHandler(CheckBox_CheckedChanged);
            deletebtn[lbcount].Click += new EventHandler(DeleteButton_Click);

            panel1.Controls.Add(deletebtn[lbcount]);
            panel1.Controls.Add(checkBox[lbcount]);
            panel1.Controls.Add(start[lbcount]);
            panel1.Controls.Add(end[lbcount]);
            panel1.Controls.Add(content[lbcount]);
            panel1.Controls.Add(title[lbcount]);

            lbcount++;
 
            List<Schedule> schedules = new List<Schedule>();
            schedules.Add(eventschedule); // Schedules에 새로운 일정 추가
            //daySchedules = daySchedules.OrderBy(schedule => schedule.startTime).ToList(); // startTime을 기준으로 일정 정렬

            // save 클릭시 EventHandler call
            saveEvent.Invoke(this, new EventFormArgs(schedules));
        }



        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int deleteIndex = (int)btn.Tag;

            string deleteTitle = title[deleteIndex].Text;
            string deleteContent = content[deleteIndex].Text;
            DateTime startTime = DateTime.Parse(start[deleteIndex].Text);
            DateTime endTime = DateTime.Parse(end[deleteIndex].Text);

            Schedule deleteSchedule = new Schedule();
            // mainForm의 schedules 리스트에서 해당하는 스케줄을 찾아 삭제
            foreach(Schedule schedule in mainForm.schedules)
            {
                if (Schedule.scheduleCompare(daySchedules[deleteIndex],schedule))
                {
                    mainForm.schedules.Remove(schedule);
                    daySchedules.Remove(schedule);
                    deleteSchedule = schedule;

                    // 서버에 스케쥴 삭제를 요청
                    Dictionary<string, Object> fullData = new Dictionary<string, object>();
                    fullData.Add("user", mainForm.myUserInfo);
                    fullData.Add("schedule", schedule);

                    Packet packet = new Packet();
                    packet.action = ActionType.deleteSchedule;
                    packet.data = fullData;

                    Packet.SendPacket(netstrm, packet);
                    packet = Packet.ReceivePacket(netstrm);

                    break;
                }
            }


            if (deleteIndex < lbcount - 1)
            {
                // 아래에 있는 스케줄들을 한 칸씩 위로 올림
                for (int i = deleteIndex; i < lbcount - 1; i++)
                {
                    start[i].Text = start[i + 1].Text;
                    end[i].Text = end[i + 1].Text;
                    title[i].Text = title[i + 1].Text;
                    content[i].Text = content[i + 1].Text;
                }
            }

            // 마지막 스케줄의 컨트롤들을 제거
            panel1.Controls.Remove(deletebtn[lbcount -1]);
            panel1.Controls.Remove(checkBox[lbcount -1]);
            panel1.Controls.Remove(start[lbcount - 1]);
            panel1.Controls.Remove(end[lbcount - 1]);
            panel1.Controls.Remove(content[lbcount - 1]);
            panel1.Controls.Remove(title[lbcount - 1]);

            // lbCount를 감소시킴
            lbcount--;

            // 삭제할 스케줄을 전송
            List<Schedule> schedules = new List<Schedule>();
            schedules.Add(deleteSchedule);

            deleteEvent.Invoke(this, new EventFormArgs(schedules));
        }




        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            int index = (int)checkBox.Tag;

            // 체크될 스케줄의 요소들
            string deleteStartTime = start[index].Text;
            string deleteEndTime = end[index].Text;
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
                    if (schedule.startTime.ToString("yyyy-MM-dd HH:mm") == deleteStartTime &&
                        schedule.endTime.ToString("yyyy-MM-dd HH:mm") == deleteEndTime &&
                        schedule.title == deleteTitle && schedule.content == deleteContent)
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
                    if (schedule.startTime.ToString("yyyy-MM-dd HH:mm") == deleteStartTime &&
                        schedule.endTime.ToString("yyyy-MM-dd HH:mm") == deleteEndTime &&
                        schedule.title == deleteTitle && schedule.content == deleteContent)
                    {
                        schedule.isDone = false;
                        break;
                    }
                }
            }
        }


    }

    public class EventFormArgs : EventArgs
    {
        public List<Schedule> schedules;


        public EventFormArgs(List<Schedule> schedules)
        {
            this.schedules = schedules;
        }

        public List<Schedule> getSchedules()
        {
            return this.schedules;
        }

    }
}