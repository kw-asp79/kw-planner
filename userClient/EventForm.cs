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

//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Client
{
    public partial class EventForm : Form
    {

        UserControlDays UserControlDays;
        private Label startDateTimeLabel;
        private Label savedContentLabel;
        private Label endDateTimeLabel;
        private int controlTop;
        private List<Event> events;
        private List<CheckBox> checkBoxes; // 체크박스 리스트 추가

        NetworkStream netstrm;
        mainForm mainform;
        User myUserInfo = mainForm.myUserInfo;

        List<Schedule> daySchedules;

        public EventForm(UserControlDays form)
        {
            UserControlDays = form;
            daySchedules = form.getSchedules();

            InitializeComponent();
            controlTop = -140;
            events = new List<Event>();
            checkBoxes = new List<CheckBox>();


            // 시작 날짜와 시간을 나타내는 Label 생성
            startDateTimeLabel = new Label();
            startDateTimeLabel.Top = controlTop + 30;
            startDateTimeLabel.Font = new Font("Ink Free", 13, FontStyle.Regular);
            panel1.Controls.Add(startDateTimeLabel);

            // 저장된 내용을 나타내는 Label 생성
            savedContentLabel = new Label();
            savedContentLabel.Top = controlTop + 60;
            savedContentLabel.Font = new Font("Ink Free", 13, FontStyle.Regular);
            panel1.Controls.Add(savedContentLabel);

            // 끝나는 날짜와 시간을 나타내는 Label 생성
            endDateTimeLabel = new Label();
            endDateTimeLabel.Top = controlTop + 90;
            endDateTimeLabel.Font = new Font("Ink Free", 13, FontStyle.Regular);
            panel1.Controls.Add(endDateTimeLabel);

            controlTop += 150; // 다음 컨트롤의 위치를 조정


        }

        //public delegate void DateSelectedHandler(int day, string dayOfWeek);
        //public event DateSelectedHandler DateSelected;

        private void UserControlDays_DateSelected(object sender, UserControlDays.DateSelectedEventArgs e)
        {
            int day = e.SelectedDay;
            string dayOfWeek = e.SelectedDayOfWeek;

            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            string selectedDayOfWeek = culture.DateTimeFormat.GetDayName(DateTime.Now.AddDays(day - 1).DayOfWeek);

            lblSelectedDate.Text = day.ToString();
            lblSelectedDayOfWeek.Text = selectedDayOfWeek;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day,
                dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, 0);

            DateTime endDateTime = new DateTime(dtpEndDate.Value.Year, dtpEndDate.Value.Month, dtpEndDate.Value.Day,
                dtpEndTime.Value.Hour, dtpEndTime.Value.Minute, 0);
            
            string title = tbTitle.Text;
            string schedule = tbSchedule.Text;
            string category = "schedule";

            Event newEvent = new Event(category, title, startDateTime, endDateTime, schedule);
            events.Add(newEvent);


            // 스케줄을 시작하는 시간 순서로 정렬
            events = events.OrderBy(ev => ev.StartDateTime).ToList();

            // 기존 컨트롤들 제거
            panel1.Controls.Clear();
            checkBoxes.Clear();
            controlTop = 0;

            // 정렬된 스케줄에 맞게 컨트롤들 추가
            foreach (Event ev in events)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = ev.GetEventString();
                checkBox.CheckedChanged += CheckBox_CheckedChanged;

                checkBoxes.Add(checkBox);
                checkBox.Top = controlTop;
                checkBox.Font = new Font("Ink Free", 13, FontStyle.Regular);
                panel1.Controls.Add(checkBox);

                checkBox.AutoSize = true;
                checkBox.MinimumSize = new Size(200, checkBox.Height);

                controlTop += checkBox.Height + 10;

                Button deleteButton = new Button();
                deleteButton.Text = "삭제";
                deleteButton.Click += DeleteButton_Click;

                deleteButton.Top = checkBox.Top;
                deleteButton.Left = checkBox.Left + checkBox.Width + 10;
                panel1.Controls.Add(deleteButton);

                deleteButton.Tag = checkBox;
            }

            Schedule eventschedule = new Schedule();
            int A = mainForm.schedules.Count;
            eventschedule.id = A;
            eventschedule.startTime = startDateTime.Date;
            eventschedule.endTime = endDateTime.Date;
            eventschedule.category = "schedule";
            eventschedule.title = title;
            eventschedule.content = schedule;
            mainForm.schedules.Add(eventschedule);
            A++;
            UpdateLabelIndicator();
        }



        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            CheckBox associatedCheckBox = (CheckBox)deleteButton.Tag;

            // 스케줄 삭제
            string eventString = associatedCheckBox.Text;
            Event eventToDelete = events.FirstOrDefault(ev => ev.GetEventString() == eventString);
            if (eventToDelete != null)
            {
                events.Remove(eventToDelete);
            }
            // mainForm에서도 스케줄 삭제
            Schedule scheduleToDelete = mainForm.schedules.FirstOrDefault(sch => sch.title == eventString && sch.content == eventToDelete.Schedule);
            if (scheduleToDelete != null)
            {
                mainForm.schedules.Remove(scheduleToDelete);
            }

            // 삭제할 체크박스의 인덱스
            int removedIndex = panel1.Controls.IndexOf(associatedCheckBox);

            // 체크박스와 삭제 버튼 제거
            panel1.Controls.Remove(associatedCheckBox);
            panel1.Controls.Remove(deleteButton);
            checkBoxes.Remove(associatedCheckBox);

            // 삭제한 스케줄의 인덱스부터 아래에 있는 데이터들을 한 줄씩 위로 이동시킴
            for (int i = removedIndex; i < panel1.Controls.Count; i++)
            {
                Control control = panel1.Controls[i];
                if (control is CheckBox checkBox)
                {
                    Button associatedDeleteButton = (Button)panel1.Controls[i + 1];
                    checkBox.Top -= checkBox.Height + 10;
                    associatedDeleteButton.Top = checkBox.Top;
                }
            }

            UpdateLabelIndicator();
        }


        private void UpdateLabelIndicator()
        {
            bool allChecked = checkBoxes.All(cb => cb.Checked);
            bool hasSchedule = checkBoxes.Any();

           // UserControlDays.SetLabelIndicator(hasSchedule && !allChecked);

        }



        private void ClearInputFields()
        {
            tbSchedule.Text = "";
            dtpStartDate.Value = DateTime.Now;
            dtpStartTime.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            dtpEndTime.Value = DateTime.Now;
        }


        public class Event
        {
            public DateTime StartDateTime { get; set; }
            public DateTime EndDateTime { get; set; }
            public string Schedule { get; set; }
            public string Title { get; set; }

            public Event(string category, string title, DateTime startDateTime, DateTime endDateTime, string schedule)
            {
                StartDateTime = startDateTime;
                EndDateTime = endDateTime;
                Schedule = schedule;
                Title = title;
            }
            public string GetEventString()
            {
                string start = StartDateTime.ToString("yyyy-MM-dd HH:mm");
                string end = EndDateTime.ToString("yyyy-MM-dd HH:mm");
                return $"[{Title}]  {start} - {end}: {Schedule}";
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                checkBox.Font = new Font(checkBox.Font, FontStyle.Strikeout);
                checkBox.ForeColor = Color.Gray;
            }
            else
            {
                checkBox.Font = new Font(checkBox.Font, FontStyle.Regular);
                checkBox.ForeColor = Color.Black;
            }
            UpdateLabelIndicator();
        }

    }
}
