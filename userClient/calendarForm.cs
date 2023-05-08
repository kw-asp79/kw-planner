﻿using SampleCalendar;
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
using System.Net.Sockets;

namespace SampleCalendar
{
    public partial class calendarForm : UserControl
    {

        private int month;
        private int year;

        private TcpClient server;
        private NetworkStream ns;

        List<Dictionary<DateTime, string>> publicHolidays = new List<Dictionary<DateTime, string>>();

        public calendarForm()
        {
            InitializeComponent();
        }


        public void showCalendar()
        {
            // TCP 통신
            try 
            {
                server = new TcpClient("127.0.0.1", 9050);
            }
            catch(SocketException ex) 
            {
                MessageBox.Show("\"Unable to connect to server\"");
            }

            ns = server.GetStream();

            ns.Close();
            server.Close();

            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            ymLbl.Text = year.ToString() + " . " + month.ToString();

            displayDays(month, year);
        }


        private bool IsSunday(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday;
        }

        // Helper method to check if a given date is a holiday
        public bool IsHoliday(int year, int month, int day)
        {
            // check for weekends
            DateTime date = new DateTime(year, month, day);
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            // check for public holidays
            publicHolidays.Add(new Dictionary<DateTime, string> { { new DateTime(year, 1, 1), "신년" } }); // New Year's Day
            publicHolidays.Add(new Dictionary<DateTime, string> { { new DateTime(year, 3, 1), "삼일절" } }); // Independence Movement Day
            publicHolidays.Add(new Dictionary<DateTime, string> { { new DateTime(year, 5, 5), "어린이날" } }); // Children's Day
            publicHolidays.Add(new Dictionary<DateTime, string> { { new DateTime(year, 6, 6), "현충일" } }); // Memorial Day
            publicHolidays.Add(new Dictionary<DateTime, string> { { new DateTime(year, 8, 15), "광복절" } }); // Liberation Day
            publicHolidays.Add(new Dictionary<DateTime, string> { { new DateTime(year, 10, 3), "개천절" } }); // National Foundation Day
            publicHolidays.Add(new Dictionary<DateTime, string> { { new DateTime(year, 10, 9), "한글날" } }); // Hangul Day
            publicHolidays.Add(new Dictionary<DateTime, string> { { new DateTime(year, 12, 25), "성탄절" } }); // Christmas Day

            foreach (Dictionary<DateTime, string> holiday in publicHolidays)
            {
                if (holiday.ContainsKey(new DateTime(year, month, day)))
                {
                    return true;
                }
            }

            return false;
        }


        private string getHolidayName(DateTime date)
        {
            string name = "";

            foreach (Dictionary<DateTime, string> holiday in publicHolidays)
            {
                if (holiday.ContainsKey(date))
                    return holiday[date];
            }

            return name;
        }


        private void displayDays(int month, int year)
        {

            // Get 1st day of current month and current year
            DateTime startOfMonth = new DateTime(year, month, 1);
            DateTime previousMonth = startOfMonth.AddMonths(-1);//저번달의 데이터를 불러오기 위함 

            int days = DateTime.DaysInMonth(year, month);
            int daysOfWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d")) + 1;
            int daysInPreviousMonth = DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month); //int 형으로 저번달의 연도와 월을 불러온다.


            // show previous month days
            for (int i = daysInPreviousMonth - daysOfWeek + 2; i <= daysInPreviousMonth; i++)
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.SetDay(i);
                ucDays.lbDay.ForeColor = Color.WhiteSmoke; // set text color to gray for previous month days
                dayContainer.Controls.Add(ucDays);
            }

            // show current month days
            for (int i = 1; i <= days; i++)
            {
                DateTime date = new DateTime(startOfMonth.Year, startOfMonth.Month, i);
                UserControlDays ucDays = new UserControlDays();
                ucDays.SetDay(i);
                if (IsSunday(date) || IsHoliday(startOfMonth.Year, startOfMonth.Month, i))
                {
                    ucDays.lbDay.ForeColor = Color.Red; // set text color to red if holidays or Sunday
                    if (IsHoliday(startOfMonth.Year, startOfMonth.Month, i))
                    {
                        ucDays.dayLbl.Text = getHolidayName(new DateTime(startOfMonth.Year, startOfMonth.Month, i));
                        ucDays.dayLbl.ForeColor = Color.Red;

                    }
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



    }
}