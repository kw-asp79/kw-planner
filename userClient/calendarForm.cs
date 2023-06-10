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
using CrawlingLibrary;

using EntityLibrary;
using WindowsFormsApp1;
using PacketLibrary;
using System.Net.Sockets;

namespace Client
{
    public partial class calendarForm : UserControl
    {
        NetworkStream netstrm;
        private static int month;
        private static int year;
        DateTime starttime;
        DateTime endtime;

        mainForm MainForm;

        KLASCrawler klasCrawler;
        LibraryCrawler libraryCrawler;

        List<Dictionary<DateTime, string>> publicHolidays = new List<Dictionary<DateTime, string>>();


        public List<Schedule> userSchedules; // User의 모든 스케줄을 여기에 저장.
        public List<Schedule> requestSchedules;// category가 REQUEST인 schedules를 저장

        public calendarForm(mainForm mForm, KLASCrawler kLasCrawler, LibraryCrawler liBraryCrawler)

        {
            InitializeComponent();
        
            this.klasCrawler = kLasCrawler;
            this.libraryCrawler = liBraryCrawler;

            this.MainForm = mForm;
            this.MainForm.loginSuccessEvent += delegate (object sender, LoginEventArgs args)
            {
                userSchedules = args.getSchedules(); 
                
                if(args.getType() == LoginEventArgs.TYPE.PROGRAM_LOGIN)
                    this.MainForm.isLoginSuccess = true;
            };

            EventForm.saveEvent += delegate (object sender, EventFormArgs args)
            {
                // EventForm에서 바뀐 최신 일정 리스트를 전달
                List<Schedule> updatedSchedules = args.getSchedules();

                if (this.MainForm.isLoginSuccess == true)
                {
                    // 일정에서 바뀐 부분만 추가하도록 
                    foreach (Schedule schedule in updatedSchedules)
                    {
                        userSchedules.Add(schedule);
                    }

                }
                else
                {
                    MessageBox.Show("일정을 달력에 저장하려면 먼저 로그인을 해주세요!!");
                }

            };


            EventForm.deleteEvent += delegate (object sender, EventFormArgs args)
            {
                List<Schedule> updatedSchedules = args.getSchedules();
                foreach (Schedule schedule in updatedSchedules)
                {
                    foreach (Schedule calSchedule in userSchedules)
                    {
                        if (Schedule.scheduleCompare(schedule,calSchedule))
                        {
                            userSchedules.Remove(schedule);
                            break;
                        }
                    }

                }

            };


            // mainForm에 있는 schedules 중에서 category가 Request 인 데이터를 불러옴
            this.netstrm = mainForm.netstrm;
            this.requestSchedules = new List<Schedule>();
        }





        public void showCalendar()
        {
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



            // klas, library, 개인적인 스케줄 을 해당 날짜에 대해서 겹치는 부분이 있다면 그 날은 일정이 최소 하나는 있다는 뜻 
            // 그러면 day Box에 해당하는 것을 표시해준다. 
            
            // show previous month days
            for (int i = daysInPreviousMonth - daysOfWeek + 2; i <= daysInPreviousMonth; i++)
            {

                DateTime date = new DateTime(startOfMonth.Year, startOfMonth.Month - 1 == 0 ? 12 : startOfMonth.Month-1, i) ;

                UserControlDays ucDays = new UserControlDays(date,MainForm,this);
                
                ucDays.SetDay(i);
                ucDays.lbDay.ForeColor = Color.WhiteSmoke; // set text color to gray for previous month days

                ucDays.showMainSchedule();

                dayContainer.Controls.Add(ucDays);
            }

            // show current month days
            for (int i = 1; i <= days; i++)
            {
                DateTime date = new DateTime(startOfMonth.Year, startOfMonth.Month, i);

                UserControlDays ucDays = new UserControlDays(date,MainForm,this);

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

                ucDays.showMainSchedule();


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

           // MessageBox.Show(klasCrawler.lectures.Count.ToString());
           // MessageBox.Show(libraryCrawler.books.Count.ToString());
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

        private void calendarContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_share_Click(object sender, EventArgs e)
        {
            //this.requestSchedules = mainForm.schedules.Where(schedule => schedule.category == "REQUEST").ToList();

            // 유저정보 불러옴
            User user = mainForm.myUserInfo;

            // 클라이언트가 켜져있는동안 데이터베이스에 새롭게 추가된 Request Schedule 데이터 정보를 불러오기 위한 작업
            Packet packet = new Packet();
            packet.action = ActionType.viewRequestSchedules;

            Dictionary<string, Object> fullData = new Dictionary<string, object>();
            fullData.Add("user", user);
            packet.data = fullData;

            Packet.SendPacket(netstrm, packet);
            packet = Packet.ReceivePacket(netstrm);

            List<Schedule> requestSchedulesInDB = packet.data as List<Schedule>;

            requestSchedules.AddRange(requestSchedulesInDB);

            if (requestSchedules.Count == 0)
            {
                string message = string.Format("공유된 일정이 없습니다");
                MessageBox.Show(message);
                return;
            }
            else
            {
                string message = string.Format("수락하실 일정을 체크한 후 수락 버튼을 눌러주세요");
                MessageBox.Show(message);
                calendar_Share_chk calendar_Share_Chk = new calendar_Share_chk(this);
                calendar_Share_Chk.ShowDialog();
            }
            
        }
    }
}
