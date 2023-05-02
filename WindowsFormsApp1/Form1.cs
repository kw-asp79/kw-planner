using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleCalendar
{
    public partial class Form1 : Form
    {
        private int month;
        private int year;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            ymLbl.Text = year.ToString() + " . " + month.ToString();

            displayDays(month, year);
        }



        private void displayDays(int month, int year)
        {
            // Get 1st day of current month and current year
            DateTime startOfMonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);
            int daysOfWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < daysOfWeek; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();
                dayContainer.Controls.Add(ucBlank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.days(i);
                dayContainer.Controls.Add(ucDays);
            }

        }

        // show next month of the calendar
        private void nextBtn_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();

            // if month exceeds 12, i.e, next year
            if (++month > 12)
            {
                month = 1;
                year++;
            }

            ymLbl.Text = year.ToString() + " . " + month.ToString();
            displayDays(month, year);
        }


        // show previous month of the calendar
        private void prevBtn_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();

            // if month less than 1, i.e, previous year
            if (--month < 1)
            {
                month = 12;
                year--;
            }

            ymLbl.Text = year.ToString() + " . " + month.ToString();
            displayDays(month, year);
        }
    }
}
