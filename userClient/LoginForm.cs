using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class LoginForm : Form
    {
        NetworkStream netstrm;
        public mainForm mainform;

        public LoginForm(NetworkStream netstrm, mainForm mainform)
        {
            InitializeComponent();
            this.netstrm = netstrm;
            this.mainform = mainform;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //mainform.myUserInfo.id = "11111";
            //mainform.myUserInfo.pwd = "qqqqq";
            //mainform.myUserInfo.name = "Lee";

            mainform.isLoginSuccess = true;

            this.Close();
        }
    }
}
