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
    public partial class UserControlDays : UserControl
    {
        public UserControlDays()
        {
            InitializeComponent();
        }


        public void days(int numDay)
        {
            lbDay.Text = numDay.ToString();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }
    }
}
