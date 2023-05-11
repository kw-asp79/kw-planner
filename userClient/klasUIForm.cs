using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class klasUIForm : Form
    {
        private string id;
        private string pwd;

        public klasUIForm()
        {
            InitializeComponent();
        }


        public klasUIForm(string id, string pwd)
        {
            this.id = id;
            this.pwd = pwd;

            InitializeComponent();
        }





    }
}
