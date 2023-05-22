using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
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




        public UserControlDays()
        {
            InitializeComponent();


        }

        public void SetDay(int day)
        {
            this.day = day;
            this.lbDay.Text = day.ToString();
            this.lbDay.ForeColor = Color.Black; // reset text color to black
        }


        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        public event EventHandler<DateSelectedEventArgs> DateSelected;

        // when date Box clicked, show EventForm
        private void UserControlDays_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightSlateGray;
            ((UserControlDays)sender).BorderStyle = BorderStyle.Fixed3D;

            EventForm eventForm = new EventForm();
            DialogResult result = eventForm.ShowDialog();

            // 스케줄을 저장하는 로직을 추가하세요.
            if (result == DialogResult.OK)
            {
                int selectedDay = this.day;
                string selectedDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.AddDays(selectedDay - 1).DayOfWeek);
                DateSelected?.Invoke(this, new DateSelectedEventArgs(selectedDay, selectedDayOfWeek));
            }


        }

        private void UserControlDays_DoubleClick(object sender, EventArgs e)
        {
            EventForm todoEventForm = new EventForm();
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


    }
}
