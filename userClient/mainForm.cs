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


namespace Client
{
    public partial class mainForm : Form
    {
        // 각 form 들을 멤버로 선언 => 추후 klas와 도서관 정보를 달력과 주고받기 위해 (다만 상황에 따라 변동 가능성 존재..)
        calendarForm calendarForm; 
        klasLoginForm klasLoginForm;
        libraryLoginForm libraryLoginForm;


        public mainForm()
        {
            InitializeComponent();
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
