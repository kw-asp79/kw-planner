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
    public partial class libraryLoginForm : UserControl
    {
        NetworkStream netstrm;
        public libraryLoginForm(NetworkStream netstrm)
        {
            InitializeComponent();
            this.netstrm = netstrm;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LibraryUIForm libraryUIForm = new LibraryUIForm(idTbx.Text,pwdTbx.Text);
            libraryUIForm.Show();
        }
    }
}
