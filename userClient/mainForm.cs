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
using MySqlX.XDevAPI;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using CrawlingLibrary;


namespace Client
{
    public class LoginEventArgs : EventArgs
    {
        public List<Schedule> schedules;
        public enum TYPE
        {
            PROGRAM_LOGIN,
            KLAS_LOGIN,
            LIBRARY_LOGIN
        }

        TYPE type;

        public LoginEventArgs(List<Schedule> schedules,TYPE type)
        {
            this.schedules = schedules;
            this.type = type;
        }

        public List<Schedule> getSchedules()
        {
            return this.schedules;
        }


        public TYPE getType()
        {
            return type;
        }

    }


    public partial class mainForm : Form
    {
        // 각 form 들을 멤버로 선언 => 추후 klas와 도서관 정보를 달력과 주고받기 위해 (다만 상황에 따라 변동 가능성 존재..)
        calendarForm calendarForm;
        KLASLoginForm klasLoginForm;
        KLASUIForm klasUIForm;
        libraryLoginForm libraryLoginForm;
        LibraryUIForm libraryUIForm;

        public static TcpClient server;
        public static NetworkStream netstrm;

        public static List<User> friends = new List<User>();
        public static List<Schedule> schedules = new List<Schedule>();
        public static Dictionary<string, List<User>> groups = new Dictionary<string, List<User>>();

        public static User myUserInfo;
        public bool isLoginSuccess = false;

        KLASCrawler klasCrawler;
        LibraryCrawler libraryCrawler;

        // 프로그램 자체 로그인, KLAS 로그인, LIBRARY 로그인 통합 Event Handler
        public event EventHandler<LoginEventArgs> loginSuccessEvent;

        public mainForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(MainForm_Load);

        }

        public Control getCalendarContainer()
        {
            return this.calendarContainer;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Width = 1060;
            this.Height = 900;
        }

        public void requestMyData(NetworkStream netstrm)
        {
            MessageBox.Show("readAllData 실행");

            while (true)
            {
                if (isLoginSuccess)
                {
                    User user = myUserInfo;

                    Packet packet = new Packet();
                    packet.action = ActionType.readAllData;
                    packet.data = user;

                    Packet.SendPacket(netstrm, packet);

                    packet = Packet.ReceivePacket(netstrm);

                    List<Schedule> tempSchedules = new List<Schedule>();
                    if (packet.action == ActionType.Success)
                    {
                        Dictionary<string, Object> fullData = packet.data as Dictionary<string, object>;

                        friends = fullData["friends"] as List<User>;
                        tempSchedules = fullData["schedules"] as List<Schedule>;
                        groups = fullData["groups"] as Dictionary<string, List<User>>;
                        
                    }

                    foreach (Schedule schedule in tempSchedules)
                        schedules.Add(schedule);

                    string meesage = "";
                    foreach (Schedule schedule in schedules)
                    {
                        meesage += schedule.title + ", " + schedule.content + ", " + schedule.fromWho + "\n";
                    }
                    MessageBox.Show(meesage);

                    // Login eventHandler call! 
                    loginSuccessEvent.Invoke(this,new LoginEventArgs(schedules,LoginEventArgs.TYPE.PROGRAM_LOGIN));
                    
                    break;
                }
            }
        }

        public void waitShareProcess(NetworkStream netstrm)
        {
            /*
            while (true)
            {
                if (isLoginSuccess)
                {
                    Packet packet = new Packet();

                    packet = Packet.ReceivePacket(netstrm);

                    if(packet.action == ActionType.shareSchedule)
                    {
                        Schedule schedule = (Schedule)packet.data;
                        MessageBox.Show("Schedule title : " + schedule.title +", content : " + schedule.content);
                    }
                    
                }
            }
            */
        }

        private async void Form1_Load(object sender, EventArgs e)
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

            Task.Run(() => requestMyData(netstrm));
            //Task.Run(() => waitShareProcess(netstrm));

            //Task.Run(() => waitShareProcess(netstrm));

            // create KLAS Crawler
            klasCrawler = new KLASCrawler();
            // create Library Crawler
            libraryCrawler = new LibraryCrawler();

            // show calendar form  
            calendarForm = new calendarForm(this, klasCrawler,libraryCrawler);
            
            calendarForm.showCalendar();
            calendarContainer.Controls.Add(calendarForm);

           

            // create KLAS UI Form 
            klasUIForm = new KLASUIForm();

            // create KLAS Login Form 
            klasLoginForm = new KLASLoginForm(klasUIForm, klasCrawler);
            // add EventHandler
            klasLoginForm.allSuccess += klasAllSuccess;

            // create Library UI Form 
            libraryUIForm = new LibraryUIForm();

            // create Library Login Form
            libraryLoginForm = new libraryLoginForm(libraryUIForm, libraryCrawler, netstrm);
            // add EventHandler
            libraryLoginForm.allSuccess += lbyAllSuccess;

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

            // after login once, don't need to show loginForm. Instead, shows user's klas data UI
            if (klasLoginForm.getLoginStatus())
                calendarContainer.Controls.Add(klasUIForm); // (after login) show klasUIForm
            else
                calendarContainer.Controls.Add(klasLoginForm); // else(not login status) show klasLoginForm
        }


        private void klasAllSuccess(object sender, AllSuccessEventArgs args)
        {
            // KLAS 스케줄들을 메인 스케줄에 추가
            foreach(Schedule schedule in args.getSchedules())
                schedules.Add(schedule);
            loginSuccessEvent.Invoke(this, new LoginEventArgs(schedules, LoginEventArgs.TYPE.KLAS_LOGIN));

            klasUIForm.setMainUI();

            // 현재 화면이 klasLoginForm 일 때만 바로 출력하도록
            if (calendarContainer.Controls.Contains(klasLoginForm))
            {
                calendarContainer.Controls.Clear();
                calendarContainer.Controls.Add(klasUIForm);
            }
        }



        private void lbyBtn_Click(object sender, EventArgs e)
        {
            calendarContainer.Controls.Clear();

            // after login once, don't need to show loginForm. Instead, shows user's library data UI
            if (libraryLoginForm.getLoginStatus())
                calendarContainer.Controls.Add(libraryUIForm);
            else
                calendarContainer.Controls.Add(libraryLoginForm);

        }

        private void lbyAllSuccess(object sender, AllSuccessEventArgs args)
        {
            // LIBRARY 스케줄들을 메인 스케줄에 추가
            foreach (Schedule schedule in args.getSchedules())
                schedules.Add(schedule);
            loginSuccessEvent.Invoke(this, new LoginEventArgs(schedules, LoginEventArgs.TYPE.LIBRARY_LOGIN));

            libraryUIForm.setUI();

            // 현재 화면이 libraryLoginForm 일 때만 바로 출력하도록
            if (calendarContainer.Controls.Contains(libraryLoginForm))
            {
                calendarContainer.Controls.Clear();
                calendarContainer.Controls.Add(libraryUIForm);
            }
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
            SignUpForm signUpForm = new SignUpForm(netstrm, this);
            signUpForm.Show();
        }

        private void groupBtn_Click(object sender, EventArgs e)
        {
            calendarContainer.Controls.Clear();
            fdGroup_Form fdGroupForm = new fdGroup_Form(netstrm) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            this.calendarContainer.Controls.Add(fdGroupForm);
            fdGroupForm.Show();
        }

        private void todoBtn_Click(object sender, EventArgs e)
        {
            calendarContainer.Controls.Clear();

            ToDoUIForm todoUIForm = new ToDoUIForm(libraryCrawler.getLibrarySchedules(),klasCrawler.getKLASSchedules(),this);
            calendarContainer.Controls.Add(todoUIForm);
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Form_Close 이벤트 발생시 아래 코드를 추가해야함

            Packet packet = new Packet();
            packet.action = ActionType.ClientClosed;
            
            Packet.SendPacket(netstrm, packet);

            netstrm.Close();
            server.Close();
        }
    }
}
