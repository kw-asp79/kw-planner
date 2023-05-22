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

namespace Client
{
    public partial class EventForm : Form
    {
        private List<Event> events;
        private UserControlDays userControlDays;
        private List<CheckBox> checkBoxes;
        private List<Label> labels;
        private int controlTop;

        public EventForm()
        {
            InitializeComponent();

            userControlDays = new UserControlDays();

            // UserControlDays_DateSelected 이벤트 핸들러 등록
            userControlDays.DateSelected += UserControlDays_DateSelected;

            events = new List<Event>();
            checkBoxes = new List<CheckBox>();
            labels = new List<Label>();

            // ComboBox에 시간 옵션 추가
            for (int i = 0; i < 24; i++)
            {
                cbbHour.Items.Add(i.ToString("00"+"시"));
            }

            controlTop = 10;//처음 위치 
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
            string time = cbbHour.SelectedItem.ToString();
            string schedule = tbSchedule.Text;

            // 이벤트 객체를 생성하여 리스트에 추가
            Event newEvent = new Event(time, schedule);
            events.Add(newEvent);

            // 이벤트를 표시를 위한 체크 박스와 라벨 생성
            CheckBox checkBox = new CheckBox();
            checkBox.Text = time + schedule;
            checkBox.Text = time + "    " + schedule;
            checkBox.CheckedChanged += CheckBox_CheckedChanged;
            checkBoxes.Add(checkBox);
            checkBox.Top = controlTop;
            checkBox.Font = new Font("Ink Free", 13, FontStyle.Regular);
            panel1.Controls.Add(checkBox);


            // CheckBox의 너비 조정
            checkBox.AutoSize = true;
            checkBox.MinimumSize = new Size(200, checkBox.Height);


            Label label = new Label();
            label.Text = time + "    " + schedule;
            labels.Add(label);
            label.Top = controlTop;
            label.Font = new Font("Ink Free", 13, FontStyle.Bold);


            // Label의 너비 조정
            label.AutoSize = true;
            label.MinimumSize = new Size(200, label.Height);


            controlTop += checkBox.Height + 10; // 다음 컨트롤의 위치를 조정
            cbbHour.SelectedIndex = -1;
            tbSchedule.Text = "";
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // 체크 박스의 체크 상태가 변경되었을 때 실행되는 이벤트 핸들러입니다.
            CheckBox checkBox = (CheckBox)sender;
            string eventText = checkBox.Text;
            bool isChecked = checkBox.Checked;

            // 체크 상태에 따라 이벤트 텍스트의 스타일을 변경합니다.
            if (isChecked)
            {
                checkBox.Font = new System.Drawing.Font(checkBox.Font, System.Drawing.FontStyle.Strikeout);
                checkBox.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                checkBox.Font = new System.Drawing.Font(checkBox.Font, System.Drawing.FontStyle.Regular);
                checkBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        public class Event
        {
            public string Time { get; set; }
            public string Schedule { get; set; }

            public Event(string time, string schedule)
            {
                Time = time;
                Schedule = schedule;
            }
        }

    }
}
