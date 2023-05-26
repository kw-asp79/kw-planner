using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacketLibrary;
using EntityLibrary;
using WindowsFormsApp1;

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


        private void loginBtn_Click(object sender, EventArgs e)
        {
            User user = new User();

            // txtBox의 정보를 매핑
            user.id = txt_ID.Text;
            user.pwd = txt_pwd.Text;

            Packet sendPacket = new Packet();
            Packet receivedPacket;

            // 로그인 요청 패킷을 보냄
            sendPacket.action = ActionType.login;
            sendPacket.data = user;
            Packet.SendPacket(netstrm, sendPacket);

            // 로그인 응답 패킷을 받음
            receivedPacket = Packet.ReceivePacket(netstrm);

            // 로그인 성공 여부에 따라 다르게 동작해야함
            if (receivedPacket.action == ActionType.Success)
            {
                mainform.isLoginSuccess = true;
                mainform.myUserInfo = (User)receivedPacket.data;

                MessageBox.Show("로그인에 성공했습니다.");
                this.Close();
            }
            else if(receivedPacket.action == ActionType.Fail)
            {
                MessageBox.Show("로그인에 실패했습니다.");
                txt_ID.Text = "";
                txt_pwd.Text = "";
            }

        }

        private void btn_signup_click(object sender, EventArgs e)
        {
            SignUpForm form = new SignUpForm();
            form.ShowDialog();
        }


        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            // esc 누르면 폼 종료
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }

}
