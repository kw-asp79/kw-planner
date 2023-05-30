using EntityLibrary;
using PacketLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management.Instrumentation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static Client.EventForm;
namespace Client
{
    public partial class UserControlDays : UserControl
    {
        private int day;
        private bool isLabelVisible = true;
        //private int clickedDay;


        // 이벤트 핸들러에 전달할 인자를 담은 클래스 정의
        public class DateSelectedEventArgs : EventArgs
        {
            public int SelectedDay { get; }
            public string SelectedDayOfWeek { get; }

            public DateSelectedEventArgs(int selectedDay, string selectedDayOfWeek)
            {
                SelectedDay = selectedDay;
                SelectedDayOfWeek = selectedDayOfWeek;
            }
        }

        NetworkStream netstrm;
        mainForm mainform;
        User myUserInfo = mainForm.myUserInfo;

        private void list_load()
        {
            foreach (Schedule schedule in mainForm.schedules)
            {
                DateTime startDate = schedule.startTime;
                DateTime endDate = schedule.endTime;

                int year = DateTime.Now.Year; // 현재 연도 가져오기
                int month = DateTime.Now.Month; // 현재 월 가져오기
                int day = DateTime.Now.Day; // 현재 일 가져오기

                // 현재 패널과 스케줄의 시작일과 종료일이 일치하는지 확인
                if (startDate.Year == year && startDate.Month == month && startDate.Day <= day && day <= endDate.Day)
                {
                    // 스케줄 정보를 패널에 추가
                    AddLabel(schedule.content, schedule.category);
                }
            }
        }



        public UserControlDays(NetworkStream netstrm)
        {
            InitializeComponent();
            this.netstrm = netstrm;

        }

        public void SetDay(int day)
        {
            this.day = day;
            this.lbDay.Text = day.ToString();
            this.lbDay.ForeColor = Color.Black; // reset text color to black
        }
        public void AddLabel(string schedule, string category)
        {

                // 카테고리에 따라 레이블의 색상 설정
                Color labelColor = GetLabelColorByCategory(category);
                if(category== "schedule")
                {
                    label1.BackColor = labelColor;
                    label1.Text = schedule;
                    label1.Visible = true;
                }
                else if(category== "klas")
                {
                    label2.BackColor = labelColor;
                    label2.Text = schedule;
                    label2.Visible = true;
                }
                else if(category== "library")
                { 
                    label3.BackColor = labelColor;
                    label3.Text = schedule;
                    label3.Visible = true;
                }
            
        }

        private Color GetLabelColorByCategory(string category)
        {
            // 카테고리에 따라 다른 색상 반환
            switch (category)
            {
                case "schedule":
                    return Color.Yellow;
                case "klas":
                    return Color.Green;
                case "library":
                    return Color.Blue;
                // 다른 카테고리에 대한 처리 추가
                default:
                    return Color.White;
            }
        }


        // UserControlDays.cs

        public void ClearLabel()
        {
            label1.Text = string.Empty;
            label1.Visible = false;
            label2.Text = string.Empty;
            label2.Visible = false;
            label3.Text = string.Empty;
            label3.Visible = false;
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            UserControlDays clickedPanel = (UserControlDays)sender;
            int selectedDay = clickedPanel.day; // 현재 패널의 날짜 가져오기
            string selectedDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.AddDays(selectedDay - 1).DayOfWeek);
            EventForm todoEventForm = new EventForm(this);
            todoEventForm.dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, selectedDay);
            todoEventForm.dtpEndDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, selectedDay);
            todoEventForm.ShowDialog();
            Schedule matchingSchedule = mainForm.schedules.FirstOrDefault(schedule => schedule.startTime.Date == todoEventForm.dtpStartDate.Value.Date || schedule.endTime.Date == todoEventForm.dtpEndDate.Value.Date);
            if (matchingSchedule != null)
            {
                // 스케줄 정보를 패널에 추가
                clickedPanel.AddLabel(matchingSchedule.content, matchingSchedule.category);
            }
        }

        private void UserControlDays_DoubleClick(object sender, EventArgs e)
        {
            EventForm todoEventForm = new EventForm(this);
            todoEventForm.ShowDialog();

        }

        private void UserControlDays_MouseEnter(object sender, EventArgs e)
        {
            ((UserControlDays)sender).BackColor = Color.Gray;//마우스가 들어갔을 때 색 변화
            ((UserControlDays)sender).BorderStyle = BorderStyle.Fixed3D;//테두리 스타일
        }

        private void UserControlDays_MouseLeave(object sender, EventArgs e)
        {
            ((UserControlDays)sender).BackColor = Color.Gainsboro;
            ((UserControlDays)sender).BorderStyle = BorderStyle.None; 
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
        }
    }
}
