using Client;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacketLibrary;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
    public partial class fdGroup_Add_Form : Form
    {
        fdGroup_Form fdGroupForm;
        mainForm mainform;
        User myUserInfo;
        NetworkStream netstrm;

        public fdGroup_Add_Form(fdGroup_Form fdGroup_Form)
        {
            InitializeComponent();
            fdGroupForm = fdGroup_Form;
            listBoxconfig();
            myUserInfo = mainForm.myUserInfo;
            netstrm = mainForm.netstrm;
        }

        private void listBoxconfig()
        {
            //friends에 있는 user.name정보만 list에 담아 보여주기
            List<string> nameList = mainForm.friends.Select(user => user.name).ToList();
            친구목록.DataSource = nameList;
            친구목록.SelectionMode = SelectionMode.MultiSimple;
            친구목록.SelectedIndex = -1;

        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            List<string> list_frdname = new List<string>();
            List<User> userList = new List<User>();
            Group group = new Group();

            foreach (var selectedname in 친구목록.SelectedItems)
            {
                list_frdname.Add(selectedname.ToString());
                string searchedId = mainForm.friends.FirstOrDefault(user => user.name == (string)selectedname)?.id;
                User user1 = new User(searchedId, "", (string)selectedname);
                userList.Add(user1);
            }
            group.name = this.txt_grpname.Text;

            Packet packet = new Packet();

            Dictionary<string, Object> fullData = new Dictionary<string, object>();
            
            // group 생성
            packet.action = ActionType.saveGroup;

            fullData.Add("group", group);
            fullData.Add("user", myUserInfo);
            packet.data = fullData;

            Packet.SendPacket(netstrm, packet);
            packet = Packet.ReceivePacket(netstrm);

            fullData.Clear();

            // group에 친구들 추가
            packet.action = ActionType.saveUserGroup;
            
            fullData.Add("groupName", group.name);
            fullData.Add("myUserInfo", myUserInfo);
            fullData.Add("friendsInGroup", userList);
            packet.data = fullData;

            Packet.SendPacket(netstrm, packet);
            packet = Packet.ReceivePacket(netstrm);


            fdGroupForm.add_Grouplist(this.txt_grpname.Text, list_frdname);
            mainForm.groups.Add(this.txt_grpname.Text, userList);

            친구목록.SelectedIndex = -1;
            txt_grpname.Clear();
            
        }
    }
}
