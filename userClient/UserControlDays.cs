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
using WindowsFormsApp1;
using static Client.EventForm;
using EntityLibrary;

namespace Client
{
    public partial class UserControlDays : UserControl
    {
        DateTime date;

        private int day;
        private bool isLabelVisible = true;

        mainForm MainForm;
        calendarForm calendarForm;


        List<Schedule> daySchedules = new List<Schedule>();


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


        public UserControlDays(DateTime date,mainForm MainForm, calendarForm calForm)
        {
            InitializeComponent();

            this.date = date;
            
            this.calendarForm = calForm;

            this.MainForm = MainForm;
            this.MainForm.loginSuccessEvent += delegate (object sender, LoginEventArgs args)
            {
                showMainSchedule(args);
            };
        }

        public void SetDay(int day)
        {
            this.day = day;
            this.lbDay.Text = day.ToString();
            this.lbDay.ForeColor = Color.Black; // reset text color to black
        }

        public void showMainSchedule(LoginEventArgs args)
        {
            List<Schedule> schedules = args.getSchedules();

            // 스케줄의 기간안에 들어가는 일정들을 추가. 
            foreach (Schedule schedule in schedules)
            {
                if (schedule.startTime.Date <= date && date <= schedule.endTime.Date)
                    daySchedules.Add(schedule);
            }

            foreach (Schedule schedule in this.daySchedules)
            {
                AddLabel(schedule);
            }

        }


        public void AddLabel(Schedule schedule)
        {

            // 카테고리에 따라 레이블의 색상 설정
            Color labelColor = GetLabelColorByCategory(schedule.category);
            if (schedule.category == "CUSTOM")
            {
                customeLbl.BackColor = labelColor;
                customeLbl.Text = schedule.content;
            }
            else if (schedule.category == "KLAS")
            {
                klasLbl.BackColor = labelColor;
                klasLbl.Text = schedule.content;
            }
            else if (schedule.category == "LIBRARY")
            {
                libraryLbl.BackColor = labelColor;
                libraryLbl.Text = schedule.content;
            }

        }

        private Color GetLabelColorByCategory(string category)
        {
            // 카테고리에 따라 다른 색상 반환
            switch (category)
            {
                case "CUSTOM":
                    return Color.Yellow;
                case "KLAS":
                    return Color.LightGreen;
                case "LIBRARY":
                    return Color.SkyBlue;
                // 다른 카테고리에 대한 처리 추가
                default:
                    return Color.White;
            }
        }



     


        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        public event EventHandler<DateSelectedEventArgs> DateSelected;

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightSlateGray;
            ((UserControlDays)sender).BorderStyle = BorderStyle.Fixed3D;



        }

        private void UserControlDays_DoubleClick(object sender, EventArgs e)
        {
            EventForm todoEventForm = new EventForm(this);
            todoEventForm.ShowDialog();

        }

        private void UserControlDays_MouseEnter(object sender, EventArgs e)
        {
            ((UserControlDays)sender).BackColor = Color.LightSteelBlue;//마우스가 들어갔을 때 색 변화
            ((UserControlDays)sender).BorderStyle = BorderStyle.Fixed3D;//테두리 스타일
        }

        private void UserControlDays_MouseLeave(object sender, EventArgs e)
        {
            ((UserControlDays)sender).BackColor = Color.Gainsboro;
            ((UserControlDays)sender).BorderStyle = BorderStyle.None; 
        }


    }
}
