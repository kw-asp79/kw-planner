using MySql.Data.MySqlClient;
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
using EntityLibrary;
using System.Diagnostics.Eventing.Reader;

namespace Client
{
    public partial class mainForm : Form
    {
        // 각 form 들을 멤버로 선언 => 추후 klas와 도서관 정보를 달력과 주고받기 위해 (다만 상황에 따라 변동 가능성 존재..)
        calendarForm calendarForm;
        KLASLoginForm klasLoginForm;
        KLASUIForm klasUIForm;
        libraryLoginForm libraryLoginForm;
        LibraryUIForm libraryUIForm;

        List<User> friends;
        List<Schedule> schedules;
        Dictionary<string, List<User>> groups;

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
        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            { 
                connection.Open();

                /*
                string Query = "INSERT INTO `schema`.`user` (`user_id`, `pwd`, `name`) VALUES ('13', '13', 'abcd');";

                MySqlCommand command = new MySqlCommand(Query, connection);

                MySqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                }
                */

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            
            // show calendar form  
            calendarForm = new calendarForm();
            calendarForm.showCalendar();
            calendarContainer.Controls.Add(calendarForm);


            // create KLAS UI Form 
            klasUIForm = new KLASUIForm();

            // create KLAS Login Form 
            klasLoginForm = new KLASLoginForm(klasUIForm);
            // add EventHandler
            klasLoginForm.allSuccess += klasAllSuccess;

            // create Library UI Form 
            libraryUIForm = new LibraryUIForm();

            // create Library Login Form
            libraryLoginForm = new libraryLoginForm(libraryUIForm);
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
            if(klasLoginForm.getLoginStatus())
                calendarContainer.Controls.Add(klasUIForm); // (after login) show klasUIForm
            else
                calendarContainer.Controls.Add(klasLoginForm); // else(not login status) show klasLoginForm
        }


        private void klasAllSuccess(object sender, EventArgs e)
        {
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

        private void lbyAllSuccess(object sender, EventArgs e)
        {
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
            fdList fdList = new fdList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            this.calendarContainer.Controls.Add(fdList);
            fdList.Show();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
        }
    }
}
