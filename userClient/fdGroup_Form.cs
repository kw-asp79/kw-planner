using Client;
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
        public static List<List<string>> listOfLists = new List<List<string>>();    
        public static List<string> grp_name_list = new List<string>();

        fdList fdList;

        static int A = 1;
        static int B = 1;
        static int cntGrp = 0;
        static int T = 1;
        public fdGroup_Form()
        {
            InitializeComponent();
            grp_load();
        }
        private void grp_load()
        {
            //for(int i=0; i<grp_name_list.Count; i++)
            //{
                
            //    add_Grouplist(grp_name_list[i], listOfLists[i]);
            //}
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
                grp_name_list.Add(grpname);
                listOfLists.Add(ts);
                A = cntGrp + 1;
                B = A;
                if ((A >= 1) && (A <= 3)) T = 1;
                if ((A >= 4) && (A <= 6)) { T = 160;B = A - 3; }
                if ((A >= 7) && (A <= 9)) { T = 320; B = A - 6; }

                labelGroupName[A] = new Label();
                labelGroupName[A].Text = grpname;
                labelGroupName[A].AutoSize = true;
                labelGroupName[A].Location = new Point(100 + 270 * (B - 1), 120+T);
                labelGroupName[A].Size = new Size(100, 100);
                labelGroupName[A].Font = new Font("Segoe Script", 12, FontStyle.Bold);
                labelGroupName[A].Tag = A;

                listBoxFriends[A] = new ListBox();
                listBoxFriends[A].Tag = A;
                listBoxFriends[A].DataSource = ts;
                listBoxFriends[A].Size = new Size(150, 78);
                listBoxFriends[A].Location = new Point { X = 100 + 270 * (B - 1), Y = 150 + T };

                btn_share[A] = new Button();
                btn_share[A].Tag = A;
                btn_share[A].Text = "일정공유";
                btn_share[A].Size = new Size(80, 20);
                btn_share[A].Location = new Point(172 + 270 * (B - 1), 230 + T);

                btn_add[A] = new Button();
                btn_add[A].Tag = A;
                btn_add[A].Text = "추가";
                btn_add[A].Size = new Size(40, 20);
                btn_add[A].Location = new Point(90 + 270 * (B - 1), 230 + T);

                btn_delete[A] = new Button();
                btn_delete[A].Tag = A;
                btn_delete[A].Text = "삭제";
                btn_delete[A].Size = new Size(40, 20);
                btn_delete[A].Location = new Point(132 + 270 * (B - 1), 230 + T);

                this.Controls.Add(btn_add[A]);
                this.Controls.Add(btn_delete[A]);
                this.Controls.Add(listBoxFriends[A]);
                this.Controls.Add(labelGroupName[A]);
                this.Controls.Add(btn_share[A]);
                listBoxFriends[A].SelectionMode = SelectionMode.MultiSimple;
                listBoxFriends[A].SelectedIndex = -1;

                btn_add[A].Click += new EventHandler(btn_add_Click);
                btn_delete[A].Click += new EventHandler(btn_delete_Click);

                cntGrp++;
                A++;
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            int idx = (int)((Button)sender).Tag;
            list = fdList.frd_list.Except((List<string>)listBoxFriends[idx].DataSource).ToList();
            fdGroup_Form_fdlist fdGroup_Form_Fdlist = new fdGroup_Form_fdlist(this,list, (List<string>)listBoxFriends[idx].DataSource,idx);
            fdGroup_Form_Fdlist.Show();
        }
        public void update_list(List<string> list,int i)
        {
            listOfLists[i-1].Clear();
            listOfLists[i-1]= list;
            listBoxFriends[i].DataSource = null;
            listBoxFriends[i].Items.Clear();
            listBoxFriends[i].DataSource = list;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            List<string> check_list = new List<string>();
            int idx = (int)((Button)sender).Tag;
            ListBox.SelectedIndexCollection selectedIndices = listBoxFriends[idx].SelectedIndices;
            check_list = (List<string>)listBoxFriends[idx].DataSource;
            for(int i=0; i<selectedIndices.Count; i++)
            {
                int selectedIndex = selectedIndices[i];
                check_list.RemoveAt(selectedIndex - i);
            }
            listBoxFriends[idx].DataSource = null;
            listBoxFriends[idx].Items.Clear();
            
            if(check_list.Count == 0)
            {
                listBoxFriends[idx].DataSource = listBoxFriends[A - 1].DataSource;
                labelGroupName[idx].Text = labelGroupName[A - 1].Text;
                this.Controls.Remove(labelGroupName[A - 1]);
                this.Controls.Remove(listBoxFriends[A - 1]);
                this.Controls.Remove(btn_delete[A - 1]);
                this.Controls.Remove(btn_share[A - 1]);
                this.Controls.Remove(btn_add[A - 1]);

                A--;
                cntGrp--;
            }
            else
            {
                listBoxFriends[idx].DataSource = check_list;
            }
            //if (grp_list.Count == 0)
            //{
            //    int last_grp = A - 1;
            //    listOfLists[idx - 1].Clear();
            //    listOfLists[idx-1] = listOfLists[last_grp-1];
            //    listOfLists[last_grp - 1].Clear();

            //    labelGroupName[idx].Text = labelGroupName[last_grp].Text;
            //    grp_list = (List<string>)listBoxFriends[last_grp].DataSource;

            //    this.Controls.Remove(labelGroupName[last_grp]);
            //    this.Controls.Remove(listBoxFriends[last_grp]);
            //    this.Controls.Remove(btn_delete[last_grp]);
            //    this.Controls.Remove(btn_share[last_grp]);
            //    this.Controls.Remove(btn_add[last_grp]);

            //    cntGrp--;
            //}
            //listBoxFriends[idx].DataSource = null;
            //listBoxFriends[idx].Items.Clear();

            //listBoxFriends[idx].DataSource = grp_list;
            //listOfLists[idx - 1].Clear();
            //listOfLists[idx - 1] = grp_list;
        }

    }
}
