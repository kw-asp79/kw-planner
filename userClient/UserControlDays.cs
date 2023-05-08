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

namespace Client
{
    public partial class UserControlDays : UserControl
    {
        private int day;

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


        // when date Box clicked, show EventForm
        private void UserControlDays_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightSlateGray;
            ((UserControlDays)sender).BorderStyle = BorderStyle.Fixed3D;

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
