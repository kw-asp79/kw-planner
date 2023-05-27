using Client;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLibrary;

namespace Client
{
    public partial class ToDoUIForm : UserControl
    {
        List<Schedule> libSchedules;
        List<Schedule> klasSchedules;

        public ToDoUIForm()
        {
            InitializeComponent();
        }


        public ToDoUIForm(List<Schedule> libschedules,List<Schedule> klasschedules)
        {
            InitializeComponent();
    
            this.libSchedules = libschedules;
            this.klasSchedules = klasschedules;
            setLibSchedules();
            setKLASSchedules();
        }

        public void setLibSchedules()
        {
            foreach(Schedule schedule in libSchedules)
            {
                textBox1.AppendText("No # \r\n");

                textBox1.AppendText("Category: " + schedule.category + "\r\n");
                textBox1.AppendText("title: " + schedule.title + "\r\n");
                textBox1.AppendText("content: " + schedule.content + "\r\n");
                textBox1.AppendText("starttime: " + schedule.startTime + "\r\n");
                textBox1.AppendText("endtime: " + schedule.endTime + "\r\n");

                textBox1.AppendText("\r\n\r\n");
            }

        }

        public void setKLASSchedules()
        {
            foreach(Schedule schedule in klasSchedules)
            {
                textBox2.AppendText("No # \r\n");

                textBox2.AppendText("Category: " + schedule.category+ "\r\n");

                textBox2.AppendText("title: " + schedule.title + "\r\n");
                textBox2.AppendText("content: " + schedule.content + "\r\n");
                textBox2.AppendText("starttime: " + schedule.startTime + "\r\n");
                textBox2.AppendText("endtime: " + schedule.endTime + "\r\n");

                textBox2.AppendText("\r\n\r\n");
            }

        }

    }
}
