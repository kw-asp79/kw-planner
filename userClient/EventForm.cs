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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Client
{
    public partial class EventForm : Form
    {
        UserControlDays UserControlDays;
        private CheckBox completionCheckBox;
        private Label startDateTimeLabel;
        private Label savedContentLabel;
        private Label endDateTimeLabel;
        private int controlTop;
        private int lcontrolTop;
        private List<Event> events;
        private List<CheckBox> checkBoxes; // 체크박스 리스트 추가



        public EventForm(UserControlDays form)
        {
            UserControlDays = form;
            InitializeComponent();
            controlTop = -140;
            lcontrolTop = -140;
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






        private void EventForm_Load(object sender, EventArgs e)
        {

        }

        private void cbHour(object sender, ControlEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day,
        dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, 0);

            DateTime endDateTime = new DateTime(dtpEndDate.Value.Year, dtpEndDate.Value.Month, dtpEndDate.Value.Day,
                dtpEndTime.Value.Hour, dtpEndTime.Value.Minute, 0);

            string schedule = tbSchedule.Text;

            Event newEvent = new Event(startDateTime, endDateTime, schedule);
            events.Add(newEvent);

            // 이벤트 정보를 표시하기 위한 컨트롤 생성
            CheckBox checkBox = new CheckBox();
            checkBox.Text = newEvent.GetEventString();
            checkBox.CheckedChanged += CheckBox_CheckedChanged;

            checkBoxes.Add(checkBox); // 체크박스를 checkBoxes 리스트에 추가
            checkBox.Top = controlTop;
            checkBox.Font = new Font("Ink Free", 13, FontStyle.Regular);
            panel1.Controls.Add(checkBox);

            // CheckBox의 너비 조정
            checkBox.AutoSize = true;
            checkBox.MinimumSize = new Size(200, checkBox.Height);

            controlTop += checkBox.Height + 10;

            Button deleteButton = new Button();
            deleteButton.Text = "삭제";
            deleteButton.Click += DeleteButton_Click;

            deleteButton.Top = controlTop;
            deleteButton.Left = checkBox.Left + 800 - deleteButton.Width;
            panel1.Controls.Add(deleteButton);
            controlTop += deleteButton.Height + 10;

            deleteButton.Tag = checkBox;


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

            // 체크박스와 삭제 버튼 제거
            panel1.Controls.Remove(associatedCheckBox);
            panel1.Controls.Remove(deleteButton);
            checkBoxes.Remove(associatedCheckBox);

            // 필요한 경우 레이아웃을 재조정할 수 있습니다.
            // ...

            UpdateLabelIndicator();
        }


        private void UpdateLabelIndicator()
        {
            bool allChecked = checkBoxes.All(cb => cb.Checked);
            bool hasSchedule = checkBoxes.Any();

            UserControlDays.SetLabelIndicator(hasSchedule && !allChecked);
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

            public Event(DateTime startDateTime, DateTime endDateTime, string schedule)
            {
                StartDateTime = startDateTime;
                EndDateTime = endDateTime;
                Schedule = schedule;
            }


            public string GetEventString()
            {
                string start = StartDateTime.ToString("yyyy-MM-dd HH:mm");
                string end = EndDateTime.ToString("yyyy-MM-dd HH:mm");
                return $"{start} - {end}: {Schedule}";
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


        private void EventForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
         
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
