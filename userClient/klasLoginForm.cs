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

namespace Client
{
    public partial class klasLoginForm : UserControl
    {
        NetworkStream netstrm;

        public klasLoginForm(NetworkStream netstrm)
        {
            InitializeComponent();
            this.netstrm = netstrm;
        }

        private void klasLoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
