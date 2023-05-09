using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class LibraryUIForm : Form
    {
        private string id;
        private string pwd;

        /*public LibraryUIForm()
        {
            InitializeComponent();
        }*/

        public LibraryUIForm(string id, string pwd)
        {
            InitializeComponent();

            this.id = id;
            this.pwd = pwd;
        }










    }
}
