using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class fdGroup_Form : Form
    {
        Label[] labelGroupName = new Label[10];
        ListBox[] listBoxFriends = new ListBox[10];
        Button[] btn_share = new Button[10];
        Button[] btn_delete = new Button[10];
        Button[] btn_add = new Button[10];
        public static List<string> grp_list = new List<string>();

        int A = 1;
        int cntGrp = 0;
        public fdGroup_Form()
        {
            InitializeComponent();
        }
        private void btn_addfd_Click(object sender, EventArgs e)
        {
            fdGroup_Add_Form fdGroup_Add_Form = new fdGroup_Add_Form(this);
            fdGroup_Add_Form.Show();
        }
        public void add_Grouplist(string grpname, List<string> ts)
        {
            
            if (grpname != "")
            {
                A = cntGrp + 1;

                labelGroupName[A] = new Label();
                labelGroupName[A].Text = grpname;
                labelGroupName[A].AutoSize = true;
                labelGroupName[A].Location = new Point(100 + 200 * (A - 1), 120);
                labelGroupName[A].Size = new Size(100, 100);
                labelGroupName[A].Font = new Font("Segoe Script", 12, FontStyle.Bold);
                labelGroupName[A].Tag = A;

                listBoxFriends[A] = new ListBox();
                listBoxFriends[A].Tag = A;
                listBoxFriends[A].DataSource = ts;
                listBoxFriends[A].Size = new Size(150, 78);
                listBoxFriends[A].Location = new Point { X = 100 + 200 * (A - 1), Y = 150 };

                btn_share[A] = new Button();
                btn_share[A].Tag = A;
                btn_share[A].Text = "일정공유";
                btn_share[A].Size = new Size(80, 20);
                btn_share[A].Location = new Point(172 + 200 * (A - 1), 230);

                btn_add[A] = new Button();
                btn_add[A].Tag = A;
                btn_add[A].Text = "추가";
                btn_add[A].Size = new Size(40, 20);
                btn_add[A].Location = new Point(90 + 200 * (A - 1), 230);

                btn_delete[A] = new Button();
                btn_delete[A].Tag = A;
                btn_delete[A].Text = "삭제";
                btn_delete[A].Size = new Size(40, 20);
                btn_delete[A].Location = new Point(132 + 200 * (A - 1), 230);

                this.Controls.Add(btn_add[A]);
                this.Controls.Add(btn_delete[A]);
                this.Controls.Add(listBoxFriends[A]);
                this.Controls.Add(labelGroupName[A]);
                this.Controls.Add(btn_share[A]);
                listBoxFriends[A].SelectionMode = SelectionMode.MultiSimple;
                listBoxFriends[A].SelectedIndex = -1;

                btn_delete[A].Click += new EventHandler(btn_delete_Click);

                cntGrp++;
                A++;
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            int idx =(int)((Button)sender).Tag ;
            ListBox.SelectedIndexCollection selectedIndices = listBoxFriends[idx].SelectedIndices;
            grp_list = (List<string>)listBoxFriends[idx].DataSource;
            for(int i = selectedIndices.Count -1; i>=0; i--)
            {
                int selectedIndex = selectedIndices[i];
                grp_list.RemoveAt(selectedIndex);
            }
            
            listBoxFriends[idx].DataSource = null;
            listBoxFriends[idx].Items.Clear();
            listBoxFriends[idx].DataSource = grp_list;
            if (grp_list.Count == 0)
            {

            }

        }
        
    }
}
