using Client;
using EntityLibrary;
using PacketLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class fdGroup_Form : Form
    {
        NetworkStream netstrm;
        User myUserInfo;

        Label[] labelGroupName = new Label[10];
        ListBox[] listBoxFriends = new ListBox[10];
        Button[] btn_share = new Button[10];
        Button[] btn_delete = new Button[10];
        Button[] btn_add = new Button[10];

        public static List<List<string>> listOfLists = new List<List<string>>();
        public static List<string> grp_name_list = new List<string>();

        fdList fdList;

        static int A = 1;
        static int B = 1;
        static int cntGrp = mainForm.groups.Count;
        static int T = 1;
        public fdGroup_Form(NetworkStream netstrm)
        {
            InitializeComponent();
            this.netstrm = netstrm;
            this.myUserInfo = mainForm.myUserInfo;
            grp_load();
        }
        private void grp_load()
        {
            for (int i = 0; i < mainForm.groups.Count; i++)
            {
                int v = i + 1;
                int k = v;
                if ((v >= 1) && (v <= 3)) T = 1;
                if ((v >= 4) && (v <= 6)) { T = 160; k = v - 3; }
                if ((v >= 7) && (v <= 9)) { T = 320; k = v - 6; }
                labelGroupName[v] = new Label();
                labelGroupName[v].Text = mainForm.groups.Keys.ElementAt(i);
                labelGroupName[v].AutoSize = true;
                labelGroupName[v].Location = new Point(100 + 270 * (k - 1), 120 + T);
                labelGroupName[v].Size = new Size(100, 100);
                labelGroupName[v].Font = new Font("Segoe Script", 12, FontStyle.Bold);
                labelGroupName[v].Tag = v;

                listBoxFriends[v] = new ListBox();
                listBoxFriends[v].Tag = v;
                listBoxFriends[v].DataSource = mainForm.groups.Values.ElementAt(i).Select(user => user.name).ToList();
                listOfLists.Add((List<string>)listBoxFriends[v].DataSource);
                listBoxFriends[v].Size = new Size(150, 78);
                listBoxFriends[v].Location = new Point { X = 100 + 270 * (k - 1), Y = 150 + T };

                btn_share[v] = new Button();
                btn_share[v].Tag = v;
                btn_share[v].Text = "일정공유";
                btn_share[v].Size = new Size(80, 20);
                btn_share[v].Location = new Point(172 + 270 * (k - 1), 230 + T);

                btn_add[v] = new Button();
                btn_add[v].Tag = v;
                btn_add[v].Text = "추가";
                btn_add[v].Size = new Size(40, 20);
                btn_add[v].Location = new Point(90 + 270 * (k - 1), 230 + T);

                btn_delete[v] = new Button();
                btn_delete[v].Tag = v;
                btn_delete[v].Text = "삭제";
                btn_delete[v].Size = new Size(40, 20);
                btn_delete[v].Location = new Point(132 + 270 * (k - 1), 230 + T);

                this.Controls.Add(btn_add[v]);
                this.Controls.Add(btn_delete[v]);
                this.Controls.Add(listBoxFriends[v]);
                this.Controls.Add(labelGroupName[v]);
                this.Controls.Add(btn_share[v]);
                listBoxFriends[v].SelectionMode = SelectionMode.MultiSimple;
                listBoxFriends[v].SelectedIndex = -1;

                btn_add[v].Click += new EventHandler(btn_add_Click);
                btn_delete[v].Click += new EventHandler(btn_delete_Click);
                btn_share[v].Click += new EventHandler(btn_share_Click);
            }
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
                B = A;
                if ((A >= 1) && (A <= 3)) T = 1;
                if ((A >= 4) && (A <= 6)) { T = 160; B = A - 3; }
                if ((A >= 7) && (A <= 9)) { T = 320; B = A - 6; }

                labelGroupName[A] = new Label();
                labelGroupName[A].Text = grpname;
                labelGroupName[A].AutoSize = true;
                labelGroupName[A].Location = new Point(100 + 270 * (B - 1), 120 + T);
                labelGroupName[A].Size = new Size(100, 100);
                labelGroupName[A].Font = new Font("Segoe Script", 12, FontStyle.Bold);
                labelGroupName[A].Tag = A;

                listBoxFriends[A] = new ListBox();
                listBoxFriends[A].Tag = A;
                listBoxFriends[A].DataSource = ts;
                listBoxFriends[A].Size = new Size(150, 78);
                listBoxFriends[A].Location = new Point { X = 100 + 270 * (B - 1), Y = 150 + T };

                listOfLists.Add(ts);

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
                btn_share[A].Click += new EventHandler(btn_share_Click);

                cntGrp++;
                A++;
            }
        }
        private void btn_share_Click(object sender, EventArgs e)
        {
            int idx = (int)((Button)sender).Tag;
            string key = labelGroupName[idx].Text;
            List<User> userlist = mainForm.groups[key];
            List<string> userIdList = userlist.Select(user => user.id).ToList();

            fdGroup_Form_schdShare fdGroup_Form_SchdShare = new fdGroup_Form_schdShare(this, this.netstrm, userIdList);
            fdGroup_Form_SchdShare.ShowDialog();
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            List<string> frd_all = new List<string>();
            int idx = (int)((Button)sender).Tag;
            frd_all = mainForm.friends.Select(user => user.name).ToList();
            //mainform.friends에 저장된 name들과 이미 추가된 친구들의 except만 목록으로 보여주기
            list = frd_all.Except((List<string>)listBoxFriends[idx].DataSource).ToList();


            if (list.Count != 0)
            {
                fdGroup_Form_fdlist fdGroup_form_Fdlist = new fdGroup_Form_fdlist(this, list, (List<string>)listBoxFriends[idx].DataSource, idx);
                fdGroup_form_Fdlist.ShowDialog();
            }
            else
            {
                MessageBox.Show("추가할 친구가 더 이상 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;

            }

        }
        public void update_list(List<string> list, int i)
        {
            listOfLists[i - 1] = null;
            listOfLists[i - 1] = list;
            listBoxFriends[i].DataSource = null;
            listBoxFriends[i].Items.Clear();
            listBoxFriends[i].DataSource = list;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            List<string> check_list = new List<string>();
            List<User> friends_list = new List<User>();
            int idx = (int)((Button)sender).Tag;
            ListBox.SelectedIndexCollection selectedIndices = listBoxFriends[idx].SelectedIndices;
            check_list = (List<string>)listBoxFriends[idx].DataSource;

            for (int i = 0; i < selectedIndices.Count; i++)
            {
                int selectedIndex = selectedIndices[i];
                string name = check_list[selectedIndex - i];
                string searchedId = mainForm.friends.FirstOrDefault(user => user.name == name)?.id;
                friends_list.Add(new User(searchedId, "", name));
                check_list.RemoveAt(selectedIndex - i);
                mainForm.groups.ElementAt(idx - 1).Value.RemoveAt(selectedIndex - i);
            }

            // 그룹에서 해당 친구들을 삭제
            string groupName = mainForm.groups.ElementAt(idx - 1).Key;

            Packet packet = new Packet();
            packet.action = ActionType.deleteUserGroup;

            Dictionary<string, Object> fullData = new Dictionary<string, object>();
            fullData.Add("groupName", groupName);
            fullData.Add("myUserInfo", myUserInfo);
            fullData.Add("friendsInGroup", friends_list);

            packet.data = fullData;

            Packet.SendPacket(netstrm, packet);
            packet = Packet.ReceivePacket(netstrm);

            // fullData 값을 다시 다른 값으로 채워야하므로 비워줌
            fullData.Clear();

            listBoxFriends[idx].DataSource = null;
            listBoxFriends[idx].Items.Clear();

            if (check_list.Count == 0)
            {
                // mainform.groups의 string A = labelGroupName[id].Text에 해당하는 그룹 삭제

                if (mainForm.groups.Count > 1)
                {
                    listBoxFriends[idx].DataSource = listBoxFriends[A - 1].DataSource;
                    mainForm.groups.Remove(labelGroupName[idx].Text);
                    labelGroupName[idx].Text = labelGroupName[A - 1].Text;
                    this.Controls.Remove(labelGroupName[A - 1]);
                    this.Controls.Remove(listBoxFriends[A - 1]);
                    this.Controls.Remove(btn_delete[A - 1]);
                    this.Controls.Remove(btn_share[A - 1]);
                    this.Controls.Remove(btn_add[A - 1]);

                    listOfLists[idx - 1] = null;
                    listOfLists[idx - 1] = listOfLists[A - 2];

                    listOfLists.RemoveAt(A - 2);

                    A--;
                    cntGrp--;
                }
                else
                {
                    mainForm.groups.Remove(labelGroupName[idx].Text);
                    this.Controls.Remove(labelGroupName[idx]);
                    this.Controls.Remove(listBoxFriends[idx]);
                    this.Controls.Remove(btn_delete[idx]);
                    this.Controls.Remove(btn_share[idx]);
                    this.Controls.Remove(btn_add[idx]);
                    listOfLists.RemoveAt(idx - 1);
                    A--;
                    cntGrp--;
                }

                packet.action = ActionType.deleteGroup;

                fullData.Add("group", new Group(groupName, myUserInfo.id));
                fullData.Add("user", myUserInfo);
                packet.data = fullData;

                Packet.SendPacket(netstrm, packet);

                packet = Packet.ReceivePacket(netstrm);

            }
            else
            {
                listBoxFriends[idx].DataSource = check_list;
                listOfLists[idx - 1] = null;
                listOfLists[idx - 1] = check_list;
            }

        }

    }
}