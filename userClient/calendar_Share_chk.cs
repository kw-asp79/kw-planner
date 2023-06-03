using Client;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class calendar_Share_chk : Form
    {
        calendarForm calendarForm;
        mainForm mainForm;
        CheckBox[] checkBox = new CheckBox [20];
        Label[] startDate = new Label[20];
        Label[] endDate = new Label[20];
        Label[] grp_name = new Label[20];
        Label[] content = new Label[20];
        Label[] title = new Label[20];

        Button Button = new Button ();

        List<Schedule> requestSchedules = new List<Schedule>();
        public calendar_Share_chk(calendarForm form )
        {
            InitializeComponent();
            this.calendarForm = form;
            requestlist_load();
        }

        private void requestlist_load()
        {
            requestSchedules = mainForm.schedules.Where(schedule => schedule.category == "REQUEST").ToList();
            
            int t = 0;
            for (int i = 1; i <= requestSchedules.Count; i++) 
            {
                var schedule = requestSchedules[i-1];

                checkBox[i] = new CheckBox();
                checkBox[i].Checked = false;
                checkBox[i].Location = new Point(40,80+40*(i-1));
                checkBox[i].Size = new Size(25, 25);
                checkBox[i].Tag = i;

                startDate[i] = new Label();
                startDate[i].Location = new Point(checkBox[i].Location.X+40, checkBox[i].Location.Y+5);
                startDate[i].Size = new Size(145, 18);
                startDate[i].Font= new Font("궁서", 10, FontStyle.Bold);
                startDate[i].Text = schedule.startTime.ToString("yyyy-MM-dd HH:mm");  
                startDate[i].Tag = i;

                endDate[i] = new Label();
                endDate[i].Location = new Point(startDate[i].Location.X + 150, startDate[i].Location.Y);
                endDate[i].Size = new Size(145, 18);
                endDate[i].Font = new Font("궁서", 10, FontStyle.Bold);
                endDate[i].Text = schedule.endTime.ToString("yyyy-MM-dd HH:mm");
                endDate[i].Tag = i;

                grp_name[i] = new Label();
                grp_name[i].Location = new Point(endDate[i].Location.X + 150, endDate[i].Location.Y);
                grp_name[i].Size = new Size(40, 20);
                grp_name[i].Font = new Font("궁서", 10, FontStyle.Bold);
                grp_name[i].Text = schedule.fromWho;
                grp_name[i].Tag = i;

                title[i] = new Label();
                title[i].Location = new Point(grp_name[i].Location.X + 70, grp_name[i].Location.Y);
                title[i].Size = new Size(100,20);
                title[i].Font = new Font("궁서", 10, FontStyle.Bold);
                title[i].Text = schedule.title;
                title[i].Tag =i;

                content[i] = new Label();
                content[i].Location = new Point(title[i].Location.X + 110, title[i].Location.Y);
                content[i].Size = new Size(400, 20);
                content[i].Font = new Font("돋움", 10, FontStyle.Bold);
                content[i].Text = schedule.content;
                content[i].Tag =i;

                panel1.Controls.Add(checkBox[i]);
                panel1.Controls.Add(startDate[i]);
                panel1.Controls.Add(endDate[i]);
                panel1.Controls.Add(grp_name[i]);
                panel1.Controls.Add(title[i]);
                panel1.Controls.Add(content[i]);
                t = i;
                
            }
            
            Button btn = new Button();
            btn.Location = new Point(title[t].Location.X + 210, title[t].Location.Y+50);
            btn.Text = "수락";
            btn.Size = new Size(100, 20);
            
            panel1.Controls.Add(btn);
            btn.Click += new EventHandler(btn_Click);
        }
        private void btn_Click(object sender, EventArgs e)
        {
            //체크된 일정들 담겨요
            List<Schedule> selectedSchedules = new List<Schedule>();
            // 내 정보
            User user = new User();
            user = mainForm.myUserInfo;

            for (int i = 1; i <= requestSchedules.Count; i++)
            {
                if (checkBox[i].Checked)
                {
                    var schedule = requestSchedules[i - 1];
                    selectedSchedules.Add(schedule);
                    string co = schedule.content;
                    var index = mainForm.schedules.FindIndex(s => s.content == co);
                    
                    if (index != -1)
                    {
                        mainForm.schedules[index].category = "CUSTOM";
                    }
                }
            }
            MessageBox.Show(string.Format("선택한 일정이 내 일정으로 등록되었습니다."));
            this.Close();
        }
    }
    

}
