﻿using EntityLibrary;
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

        private static Boolean isProgramLogin = false;
        private static Boolean isKLASLogin = false;
        private static Boolean isLibraryLogin = false;

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
                setSchedules(calForm.userSchedules);

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

                DBScheduleSynchronize(args);

            };
        }
        public void addSchedule(Schedule updatedSchedule)
        {
            // 변경된 일정을 받아 즉시 반영
            // 예시:
            daySchedules.Add(updatedSchedule);
        }
        public void RemoveSchedule(string deleteTitle, string deleteContent)
        {
            // 패널 컨테이너에서 해당 스케줄의 라벨을 찾아 제거
            for (int i = 0; i < daySchedules.Count; i++)
            {
                Schedule schedule = daySchedules[i];
                if (schedule.title == deleteTitle && schedule.content == deleteContent)
                {
                    if (daySchedules[i].category == "CUSTOM")
                    {
                        customeLbl.BackColor = DefaultBackColor;
                        customeLbl.Text = "";
                    }
                    else if (daySchedules[i].category == "KLAS")
                    {
                        klasLbl.BackColor = DefaultBackColor;
                        klasLbl.Text = "";
                    }
                    else if (daySchedules[i].category == "LIBRARY")
                    {
                        libraryLbl.BackColor = DefaultBackColor;
                        libraryLbl.Text = "";
                    }
                    daySchedules.RemoveAt(i);
                    break;
                }
            }
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



        public void setSchedules(List<Schedule> schedules)
        {
            // 스케줄의 기간안에 들어가는 일정들을 추가. 
            foreach (Schedule schedule in schedules)
            {
                if (schedule.startTime.Date <= date && date <= schedule.endTime.Date)
                    daySchedules.Add(schedule);
            }


            // CUSTOM, KLAS, LIBRARY 스케줄에서 하나씩 대표 스케줄을 선정하여 UserControlDay class에 저장
            // 그 후 대표 스케줄 각각에 대해 AddLabel을 호출해준다.
            bool customFlag = false;
            bool klasFlag = false;
            bool libFlag = false;

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



        }


        public void DBScheduleSynchronize(LoginEventArgs args)
        {
            List<Schedule> schedules = args.getSchedules();

            setSchedules(schedules);
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

        private void RemoveLabelBySchedule(Schedule schedule)
        {
            // 라벨을 찾아 제거
            if (schedule.category == "CUSTOM")
            {
                customeLbl.BackColor = DefaultBackColor;
                customeLbl.Text = "";
            }
            else if (schedule.category == "KLAS")
            {
                klasLbl.BackColor = DefaultBackColor;
                klasLbl.Text = "";
            }
            else if (schedule.category == "LIBRARY")
            {
                libraryLbl.BackColor = DefaultBackColor;
                libraryLbl.Text = "";
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
