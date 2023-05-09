using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApp1;
using System.Net.Sockets;
using EntityLibrary;
using PacketLibrary;

namespace Client
{
    public partial class mainForm : Form
    {
        // 각 form 들을 멤버로 선언 => 추후 klas와 도서관 정보를 달력과 주고받기 위해 (다만 상황에 따라 변동 가능성 존재..)
        calendarForm calendarForm; 
        klasLoginForm klasLoginForm;
        libraryLoginForm libraryLoginForm;

        private TcpClient server;
        private NetworkStream netstrm;


        public mainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // TCP 통신
            try
            {
                server = new TcpClient("127.0.0.1", 9050);
            }
            catch (SocketException ex)
            {
                MessageBox.Show("\"Unable to connect to server\"");
            }

            netstrm = server.GetStream();

            User user = new User("12346", "qqq", "seonghooni");

            Packet packet = new Packet();
            packet.action = ActionType.saveUser;
            packet.data = user;

            PacketInfo packetInfo = new PacketInfo();

            byte[] data = Packet.Serialize(packet, packetInfo);
            byte[] size = BitConverter.GetBytes(packetInfo.size); ;

            // packet의 size를 먼저 전송
            netstrm.Write(size, 0, 4);
            // 그 다음 packet을 전송
            netstrm.Write(data, 0, packetInfo.size);
            netstrm.Flush();

            netstrm.Close();
            server.Close();

            // show calendar form  
            calendarForm = new calendarForm();
            calendarForm.showCalendar();
            calendarContainer.Controls.Add(calendarForm);

        }



        // -----------------------------------    왼쪽 메뉴 버튼들 Event   --------------------------------------


        private void mainBtn_Click(object sender, EventArgs e)
        {
            calendarContainer.Controls.Clear();

            calendarContainer.Controls.Add(calendarForm);

        }

        private void klasBtn_Click(object sender, EventArgs e)
        {
            calendarContainer.Controls.Clear();

            klasLoginForm = new klasLoginForm();
            calendarContainer.Controls.Add(klasLoginForm);


            // after login once, don't need to show loginForm. Instead, shows user's klas data UI

        }

        private void lbyBtn_Click(object sender, EventArgs e)
        {
            calendarContainer.Controls.Clear();

            libraryLoginForm = new libraryLoginForm();
            calendarContainer.Controls.Add(libraryLoginForm);

            // after login once, don't need to show loginForm. Instead, shows user's library data UI

        }



        private void fndBtn_Click(object sender, EventArgs e)
        {
            calendarContainer.Controls.Clear();
            fdList fdList = new fdList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            this.calendarContainer.Controls.Add(fdList);
            fdList.Show();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
