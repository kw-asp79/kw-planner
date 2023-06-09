﻿using Client;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacketLibrary;
using static Client.EventForm;
using System.Diagnostics;

namespace Client
{
    public partial class fdGroup_Form_schdShare : Form
    {
        NetworkStream netstrm;
        fdGroup_Form fdGroup_Form;
        List<string> list = new List<string>();
        string group_name;
        string user_id;

        public static event EventHandler<EventFormArgs> shareScheduleEvent;

        public fdGroup_Form_schdShare(fdGroup_Form form, NetworkStream netstrm, List<string> list_id,string grp_name)
        {
            InitializeComponent();
            fdGroup_Form = form;
            this.netstrm = netstrm;
            list = list_id;
            group_name = grp_name;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day,
               dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, 0);
            string formatteddtpStartTime = startDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime endDateTime = new DateTime(dtpEndDate.Value.Year, dtpEndDate.Value.Month, dtpEndDate.Value.Day,
                dtpEndTime.Value.Hour, dtpEndTime.Value.Minute, 0);
            string formatteddtpEndTime = startDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            string title = tbx_Title.Text;
            string content = tbx_Content.Text;
            string category = "CUSTOM";
            user_id = mainForm.myUserInfo.id;
            Schedule eventschedule = new Schedule();
            int A = mainForm.schedules.Count +1;
            eventschedule.id = A;
            eventschedule.startTime = startDateTime;
            eventschedule.endTime = endDateTime;
            eventschedule.category = category;
            eventschedule.title = title;
            eventschedule.content = content;
            eventschedule.fromWho = user_id;
            eventschedule.isDone = false;

            mainForm.schedules.Add(eventschedule);
            calendarForm.userSchedules.Add(eventschedule);

            Group group = new Group(group_name, user_id);

            Dictionary<string, Object> fullData = new Dictionary<string, object>();
            fullData.Add("group", group);
            fullData.Add("schedule", eventschedule);

            Packet packet = new Packet();
            packet.action = ActionType.shareSchedule;
            packet.data = fullData;

            Packet.SendPacket(netstrm, packet);
            packet = Packet.ReceivePacket(netstrm);
            
            MessageBox.Show(string.Format("그룹원들에게 일정이 공유되었습니다."));

            List<Schedule> eventSchedules = new List<Schedule>();
            eventSchedules.Add(eventschedule);
            shareScheduleEvent.Invoke(this, new EventFormArgs(eventSchedules));

            this.Close();
            //User들 id/ list에 담겨있어요. 
            //Group name /group_name에 있어요
            //내 id user_id에 있어요 
        }
    }
}
