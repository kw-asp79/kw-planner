using EntityLibrary;
using PacketLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management.Instrumentation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static Client.EventForm;
using EntityLibrary;

namespace Client
{
    public partial class UserControlDays : UserControl
    {
        DateTime date;

        private int day;
        private bool isLabelVisible = true;
        //private int clickedDay;

        public static Boolean isProgramLogin = false;
        public static Boolean isKLASLogin = false;
        public static Boolean isLibraryLogin = false;

        public enum Option
        {
            NEWSTATE,
            SAVESCHEDULE,
            DELETESCHEDULE
        }


        mainForm MainForm;
        calendarForm calendarForm;


        NetworkStream netstrm;

        List<Schedule> daySchedules = new List<Schedule>();

        Schedule customMainSchedule = new Schedule();
        Schedule klasMainSchedule = new Schedule();
        Schedule libraryMainSchedule = new Schedule();


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


        public UserControlDays(DateTime date,mainForm MainForm, calendarForm calForm)
        {
            InitializeComponent();
            this.netstrm = netstrm;


            this.date = date;
            
            this.calendarForm = calForm;

            this.MainForm = MainForm;

            if (isProgramLogin || isKLASLogin || isLibraryLogin)
                setSchedules(calendarForm.userSchedules,Option.NEWSTATE);

            this.MainForm.loginSuccessEvent += delegate (object sender, LoginEventArgs args)
            {
                switch (args.getType())
                {
                    case LoginEventArgs.TYPE.PROGRAM_LOGIN:
                        isProgramLogin = true;
                        break;

                    case LoginEventArgs.TYPE.KLAS_LOGIN:
                        isKLASLogin = true;
                        break;

                    case LoginEventArgs.TYPE.LIBRARY_LOGIN:
                        isLibraryLogin = true;
                        break;
                }

                DBScheduleSynchronize(args, Option.NEWSTATE);

            };

            EventForm.saveEvent += delegate (object sender, EventFormArgs args)
            {
                if (isProgramLogin)
                {
                    List<Schedule> updatedSchedules = args.getSchedules();
                    setSchedules(updatedSchedules, Option.SAVESCHEDULE);
                }
            };

            EventForm.deleteEvent += delegate (object sender, EventFormArgs args)
            {
                if (isProgramLogin)
                {
                    List<Schedule> updatedSchedules = args.getSchedules();
                    setSchedules(updatedSchedules, Option.DELETESCHEDULE);
                }
            };

            // 일정 공유를 요청한 쪽에서 달력에 즉시 보이도록 
            fdGroup_Form_schdShare.shareScheduleEvent += delegate (object sender, EventFormArgs args)
            {
                List<Schedule> sharedSchedules = args.getSchedules();
                setSchedules(sharedSchedules, Option.SAVESCHEDULE);
            };


            // 일정 공유를 수락한 쪽에서 달력에 즉시 보이도록
            calendar_Share_chk.AcceptShareScheduleEvent += delegate (object sender, EventFormArgs args)
            {
                List<Schedule> acceptedSchedules = args.getSchedules();
                setSchedules(acceptedSchedules, Option.SAVESCHEDULE);
            };

        }

        public List<Schedule> getSchedules()
        {
            return daySchedules;
        }

        public void SetDay(int day)
        {
            this.day = day;
            this.lbDay.Text = day.ToString();
            this.lbDay.ForeColor = Color.Black; // reset text color to black
        }



        // 로그인 시 그리고 처음 생성단계에서 스케줄을 세팅
        public void setSchedules(List<Schedule> schedules, Option option)
        {
            bool customFlag = false;
            bool klasFlag = false;
            bool libFlag = false;

            switch (option)
            {

                // 로그인 시 혹은 기존상황에서 달력에 렌더링되는 상황에서의 case
                case Option.NEWSTATE:
                // 새로운 스케줄이 추가되었을 때 새로운 스케줄만 추가되도록 
                case Option.SAVESCHEDULE:
                    foreach (Schedule schedule in schedules)
                    {

                        if (schedule.startTime.Date <= date && date <= schedule.endTime.Date)
                            if (!daySchedules.Contains(schedule))
                                daySchedules.Add(schedule);
                    }

                    foreach (Schedule schedule in daySchedules)
                    {
                        switch (schedule.category)
                        {
                            case "CUSTOM":
                                if (customFlag == false)
                                {
                                    customMainSchedule = schedule;
                                    AddLabel(customMainSchedule);
                                    customFlag = true;
                                }
                                break;

                            case "KLAS":
                                if (klasFlag == false)
                                {
                                    klasMainSchedule = schedule;
                                    AddLabel(klasMainSchedule);
                                    klasFlag = true;
                                }
                                break;

                            case "LIBRARY":
                                if (libFlag == false)
                                {
                                    libraryMainSchedule = schedule;
                                    AddLabel(libraryMainSchedule);
                                    libFlag = true;
                                }
                                break;

                        }

                    }
                    break;


                // 기존 스케줄이 삭제되었을 때 삭제된 부분이 똑같이 삭제되도록
                case Option.DELETESCHEDULE:
                    foreach (Schedule schedule in schedules)
                    {
                        foreach(Schedule dSchedule in daySchedules)
                        {
                            if (Schedule.scheduleCompare(schedule,dSchedule))
                            {
                                daySchedules.Remove(schedule);

                                // 스케줄에 해당하는 라벨을 찾아 제거
                                RemoveLabel(schedule);
                                break;
                            }
                        }
                    }
                    break;
            }
        }
    



        public void RemoveLabel(Schedule schedule)
        {
            if (schedule.category == "CUSTOM")
            {
                customeLbl.BackColor = DefaultBackColor;
                customeLbl.Text = "";
                customMainSchedule = null;

                // 다른 스케줄이 존재할 경우 해당 스케줄의 라벨을 표시
                var otherSchedule = daySchedules.FirstOrDefault(s => s.category == "CUSTOM" && s != schedule);
                if (otherSchedule != null)
                {
                    customMainSchedule = otherSchedule;
                    AddLabel(otherSchedule);
                }
                
                    
            }
            else if (schedule.category == "KLAS")
            {
                klasLbl.BackColor = DefaultBackColor;
                klasLbl.Text = "";
                klasMainSchedule = null;

                // 다른 스케줄이 존재할 경우 해당 스케줄의 라벨을 표시
                var otherSchedule = daySchedules.FirstOrDefault(s => s.category == "KLAS" && s != schedule);
                if (otherSchedule != null)
                {
                    klasMainSchedule = otherSchedule;
                    AddLabel(otherSchedule);
                }
            }
            else if (schedule.category == "LIBRARY")
            {
                libraryLbl.BackColor = DefaultBackColor;
                libraryLbl.Text = "";
                libraryMainSchedule = null;

                // 다른 스케줄이 존재할 경우 해당 스케줄의 라벨을 표시
                var otherSchedule = daySchedules.FirstOrDefault(s => s.category == "LIBRARY" && s != schedule);
                if (otherSchedule != null)
                {
                    libraryMainSchedule = otherSchedule;
                    AddLabel(otherSchedule);
                }
            }
        }




        public void DBScheduleSynchronize(LoginEventArgs args,Option option)
        {
            List<Schedule> schedules = args.getSchedules();

            setSchedules(schedules,option);
        }


        public void showMainSchedule()
        {
            if (!String.IsNullOrEmpty(customMainSchedule.content))
                AddLabel(customMainSchedule);

            if (!String.IsNullOrEmpty(klasMainSchedule.content))
                AddLabel(klasMainSchedule);

            if (!String.IsNullOrEmpty(libraryMainSchedule.content))
                AddLabel (libraryMainSchedule);
        }


        public void AddLabel(Schedule schedule)
        {

            // 카테고리에 따라 레이블의 색상 설정
            Color labelColor = GetLabelColorByCategory(schedule.category);
            if (schedule.category == "CUSTOM")
            {
                customeLbl.BackColor = labelColor;
                customeLbl.Text = schedule.content;
            }
            else if (schedule.category == "KLAS")
            {
                klasLbl.BackColor = labelColor;
                klasLbl.Text = schedule.content;
            }
            else if (schedule.category == "LIBRARY")
            {
                libraryLbl.BackColor = labelColor;
                libraryLbl.Text = schedule.content;
            }


        }

        private Color GetLabelColorByCategory(string category)
        {
            // 카테고리에 따라 다른 색상 반환
            switch (category)
            {

                case "CUSTOM":
                    return Color.Yellow;
                case "KLAS":
                    return Color.LightGreen;
                case "LIBRARY":
                    return Color.SkyBlue;

                // 다른 카테고리에 대한 처리 추가
                default:
                    return Color.White;
            }
        }


        private void UserControlDays_Click(object sender, EventArgs e)
        {
            EventForm todoEventForm = new EventForm(this);
            todoEventForm.dtpStartDate.Value = date;
            todoEventForm.dtpEndDate.Value = date;
            todoEventForm.ShowDialog();
        }

        private void UserControlDays_DoubleClick(object sender, EventArgs e)
        {
            EventForm todoEventForm = new EventForm(this);
            todoEventForm.ShowDialog();

        }

        private void UserControlDays_MouseEnter(object sender, EventArgs e)
        {
            ((UserControlDays)sender).BackColor = Color.LightSteelBlue;//마우스가 들어갔을 때 색 변화
            ((UserControlDays)sender).BorderStyle = BorderStyle.Fixed3D;//테두리 스타일
        }

        private void UserControlDays_MouseLeave(object sender, EventArgs e)
        {
            ((UserControlDays)sender).BackColor = Color.Gainsboro;
            ((UserControlDays)sender).BorderStyle = BorderStyle.None; 
        }

    }
}
