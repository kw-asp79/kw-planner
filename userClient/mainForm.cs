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
<<<<<<< HEAD
 
=======
using System.Net.Sockets;
using EntityLibrary;
using PacketLibrary;
using MySqlX.XDevAPI;
using System.Collections;

>>>>>>> 74af103a8f75a5e1cad16276e6b3369293000fb6
namespace Client
{
    public partial class mainForm : Form
    {
        // 각 form 들을 멤버로 선언 => 추후 klas와 도서관 정보를 달력과 주고받기 위해 (다만 상황에 따라 변동 가능성 존재..)
        calendarForm calendarForm;
        klasLoginForm klasLoginForm;
        libraryLoginForm libraryLoginForm;

        private static TcpClient server;
        private static NetworkStream netstrm;

        List<User> friends;
        List<Schedule> schedules;
        Dictionary<string, List<User>> groups;

        public User myUserInfo;
        public bool isLoginSuccess = false;

        public void requestMyData(NetworkStream netstrm)
        {
            MessageBox.Show("readAllData 실행");

            while(true)
            {
                if (isLoginSuccess)
                {
                    MessageBox.Show("isLoginSuccess = true!!");

                    User user = myUserInfo;

                    Packet packet = new Packet();
                    packet.action = ActionType.readAllData;
                    packet.data = user;

                    Packet.SendPacket(netstrm, packet);

                    packet = Packet.ReceivePacket(netstrm);

                    if (packet.action == ActionType.Response)
                    {
                        MessageBox.Show("receive response well !");
                        // 전역변수에 대입해주는 코드 짜야함

                        Dictionary<string, Object> fullData = packet.data as Dictionary<string, object>;

                        friends = fullData["friends"] as List<User>;
                        schedules = fullData["schedules"] as List<Schedule>;
                        groups = fullData["groups"] as Dictionary<string, List<User>>;
                    }

                    break;
                }
            }
            
        }

        //async Task asyncSend(NetworkStream netstrm, Packet packet)
        //{
        //    if (server.Connected)
        //    {
        //        Packet sendPacket = packet;
        //        PacketInfo packetInfo = new PacketInfo();

        //        byte[] data = Packet.Serialize(sendPacket, packetInfo);
        //        byte[] size = BitConverter.GetBytes(packetInfo.size); ;

        //        // packet의 size를 먼저 전송
        //        netstrm.Write(size, 0, 4);
        //        // 그 다음 packet을 전송
        //        netstrm.Write(data, 0, packetInfo.size);
        //        netstrm.Flush();
        //        MessageBox.Show("successfully send!");
        //    }
        //}

        //async Task asyncRecieve(NetworkStream netstrm)
        //{
        //    if (server.Connected)
        //    {
        //        PacketInfo packetInfo = new PacketInfo();

        //        byte[] size = new byte[4];

        //        int recv = netstrm.Read(size, 0, 4);
        //        packetInfo.size = BitConverter.ToInt32(size, 0);

        //        byte[] data = new byte[packetInfo.size];

        //        recv = netstrm.Read(data, 0, packetInfo.size);

        //        Packet receivedPacket = Packet.Desserialize(data, packetInfo);
        //    }
        //}


        public mainForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(MainForm_Load);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Width = 1060;
            this.Height = 900;
        }
<<<<<<< HEAD
        private void Form1_Load(object sender, EventArgs e)
=======

        private async void Form1_Load(object sender, EventArgs e)
>>>>>>> 74af103a8f75a5e1cad16276e6b3369293000fb6
        {

            // TCP 통신
            try
            {
                server = new TcpClient("127.0.0.1", 9050);
            }
<<<<<<< HEAD
            
=======
            catch (SocketException ex)
            {
                MessageBox.Show("\"Unable to connect to server\"");
            }

            netstrm = server.GetStream();

            Task.Run(() => requestMyData(netstrm));


>>>>>>> 74af103a8f75a5e1cad16276e6b3369293000fb6
            // show calendar form  
            calendarForm = new calendarForm();
            calendarForm.showCalendar();
            calendarContainer.Controls.Add(calendarForm);

            // Form_Close 이벤트 발생시 아래 코드를 추가해야함
            //netstrm.Close();
            //server.Close();

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

            klasLoginForm = new klasLoginForm(netstrm);

            calendarContainer.Controls.Add(klasLoginForm);
            // after login once, don't need to show loginForm. Instead, shows user's klas data UI
        }
        private void lbyBtn_Click(object sender, EventArgs e)
        {
            calendarContainer.Controls.Clear();

            libraryLoginForm = new libraryLoginForm(netstrm);
            calendarContainer.Controls.Add(libraryLoginForm);

            // after login once, don't need to show loginForm. Instead, shows user's library data UI

        }
        private void fndBtn_Click(object sender, EventArgs e)
        {
            calendarContainer.Controls.Clear();
            fdList fdList = new fdList(netstrm) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            this.calendarContainer.Controls.Add(fdList);
            fdList.Show();
        }
        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(netstrm, this);
            
            loginForm.Show();
        }
        private void signupBtn_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
        }

        private void menuContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
      