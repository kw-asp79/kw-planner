using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApp1;


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
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;

            MySqlConnection connection = new MySqlConnection(connectionString);


            try
            { 
                connection.Open();

                /*
                string Query = "INSERT INTO `schema`.`user` (`user_id`, `pwd`, `name`) VALUES ('13', '13', 'abcd');";

                MySqlCommand command = new MySqlCommand(Query, connection);

                MySqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                }
                */

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            ymLbl.Text = year.ToString() + " . " + month.ToString();
            
            displayDays(month, year);
        }

        private bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday;
        }

        // Helper method to check if a given date is a holiday
        public static bool IsHoliday(int year, int month, int day)
        {
            // check for weekends
            DateTime date = new DateTime(year, month, day);
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            // check for public holidays
            List<DateTime> publicHolidays = new List<DateTime>();
            publicHolidays.Add(new DateTime(year, 1, 1)); // New Year's Day
            publicHolidays.Add(new DateTime(year, 3, 1)); // Independence Movement Day
            publicHolidays.Add(new DateTime(year, 5, 5)); // Children's Day
            publicHolidays.Add(new DateTime(year, 6, 6)); // Memorial Day
            publicHolidays.Add(new DateTime(year, 8, 15)); // Liberation Day
            publicHolidays.Add(new DateTime(year, 10, 3)); // National Foundation Day
            publicHolidays.Add(new DateTime(year, 10, 9)); // Hangul Day
            publicHolidays.Add(new DateTime(year, 12, 25)); // Christmas Day

            foreach (DateTime holiday in publicHolidays)
            {
                if (holiday.Year == year && holiday.Month == month && holiday.Day == day)
                {
                    return true;
                }
            }

            return false;
        }


        private void displayDays(int month, int year)
        {

            // Get 1st day of current month and current year
            DateTime startOfMonth = new DateTime(year, month, 1);
            DateTime previousMonth = startOfMonth.AddMonths(-1);//저번달의 데이터를 불러오기 위함 

            int days = DateTime.DaysInMonth(year, month);
            int daysOfWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d")) + 1;
            int daysInPreviousMonth = DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month); //int 형으로 저번달의 연도와 월을 불러온다.


            for (int i = daysInPreviousMonth - daysOfWeek + 2; i <= daysInPreviousMonth; i++) 
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.SetDay(i);
                ucDays.lbDay.ForeColor = Color.WhiteSmoke; // set text color to gray for previous month days
                dayContainer.Controls.Add(ucDays);
            }
            /*for (int i = 1; i < daysOfWeek; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();

                dayContainer.Controls.Add(ucBlank);
                
            }*/

            for (int i = 1; i <= days; i++)
            {
                DateTime date = new DateTime(startOfMonth.Year, startOfMonth.Month, i);
                UserControlDays ucDays = new UserControlDays();
                ucDays.SetDay(i);
                if (IsWeekend(date) || IsHoliday(startOfMonth.Year, startOfMonth.Month, i))
                {
                    ucDays.lbDay.ForeColor = Color.Red;
                }
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

        private void dayContainer_Paint(object sender, PaintEventArgs e)
        {

        }


        private void nextBtn_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    dayContainer.Controls.Clear();

                    // if month exceeds 12, i.e, next year
                    if (++month > 12)
                    {
                        month = 1;
                        year++;
                    }

                    ymLbl.Text = year.ToString() + " . " + month.ToString();
                    displayDays(month, year);
                    break;
            }
        }

        private void dayContainer_Click(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void fndBtn_Click(object sender, EventArgs e)
        {
            fdList fdlist = new fdList();
            fdlist.Show();
        }
    }
}
