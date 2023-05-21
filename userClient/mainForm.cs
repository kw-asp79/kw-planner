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

namespace Client
{
    public partial class mainForm : Form
    {
        // 각 form 들을 멤버로 선언 => 추후 klas와 도서관 정보를 달력과 주고받기 위해 (다만 상황에 따라 변동 가능성 존재..)
        calendarForm calendarForm; 
        KLASUIForm klasUIForm;
        libraryLoginForm libraryLoginForm;

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

           // klasLoginForm = new klasLoginForm(this.calendarContainer);
            calendarContainer.Controls.Add(klasUIForm);
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
            LoginForm loginForm = new LoginForm(klasUIForm);
            loginForm.Show();
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
        }
    }
}
