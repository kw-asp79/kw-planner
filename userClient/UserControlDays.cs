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
namespace Client
{
    public partial class UserControlDays : UserControl
    {
        private int day;
        private bool isLabelVisible = true;

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
        /*public void AddLabel(string schedule)
        {
            if (isLabelVisible)
            {
                label1.Text = schedule;
            }
        }*/

        // UserControlDays.cs

        public void SetLabelIndicator(bool showRedCircle)
        {
            if (showRedCircle)
            {
                PictureBox scheduleImage = new PictureBox();
                scheduleImage.Image = Image.FromFile("C:\\Users\\82109\\Desktop\\스케줄러\\kw-planner\\userClient\\Resources\\scheduleImage.png");
                scheduleImage.Size = new Size(30, 30); // 크기에 맞게 조절
                scheduleImage.Location = new Point(10, 40);
                scheduleImage.SizeMode = PictureBoxSizeMode.Zoom; // 가로와 세로의 비율이 유지된 상태에서 바뀐다
                scheduleImage.Name = "scheduleImage";

                // 이미지 라벨이 추가된 경우에는 추가하지 않는다
                if (Controls.Find("scheduleImage", true).Length == 0)
                {
                    Controls.Add(scheduleImage);
                }
            }
            else
            {
                // 이미지 라벨을 제거
                Control[] scheduleImage = Controls.Find("scheduleImage", true);
                if (scheduleImage.Length > 0)
                {
                    Controls.Remove(scheduleImage[0]);
                }
            }
        }

        public void ClearLabel()
        {
            label1.Text = string.Empty;
            SetLabelIndicator(false);
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
