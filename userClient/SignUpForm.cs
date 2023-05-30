using Client;
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
using EntityLibrary;
using PacketLibrary;

namespace WindowsFormsApp1
{
    public partial class SignUpForm : Form
    {

        NetworkStream netstrm;
        mainForm mainform;

        public SignUpForm(NetworkStream netstrm, mainForm mainform)
        {
            InitializeComponent();
            this.netstrm = netstrm;
            this.mainform = mainform;
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            string id = txt_id.Text;
            string pwd = txt_pwd.Text;
            string name = txt_name.Text;

            User user = new User(id, pwd, name);

            Packet packet = new Packet();
            packet.action = ActionType.signUp;
            packet.data = user;

            Packet.SendPacket(netstrm, packet);

            packet = Packet.ReceivePacket(netstrm);

            if(packet.action == ActionType.Success)
            {
                MessageBox.Show("회원가입을 성공했습니다.");
                this.Close();
            }
            else
            {
                MessageBox.Show("해당 아이디가 이미 존재합니다.");
            }
        }


    }
}
