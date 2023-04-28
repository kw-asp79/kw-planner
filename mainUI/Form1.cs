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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            displayDays();
        }



        private void displayDays()
        {
            DateTime now = DateTime.Now;

            // Get 1st day of current month and current year
            DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);

            int days = DateTime.DaysInMonth(now.Year, now.Month);
            int daysOfWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d"))+1;

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


    }
}
