using Client;
using EntityLibrary;
using PacketLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class fdGroup_Form_fdlist : Form
    {
        fdGroup_Form fdGroupForm;
        fdList fdList;
        User myUserInfo;
        NetworkStream netstrm;
        List<string> add_list = new List<string>();
        int k = 0;
        public fdGroup_Form_fdlist(fdGroup_Form fdGroup_Form, List<string> list, List<string> list1, int i)
        {

            InitializeComponent();
            fdGroupForm = fdGroup_Form;
            친구_list.DataSource = list;
            친구_list.Refresh();
            add_list = list1;
            친구_list.SelectionMode = SelectionMode.MultiSimple;
            친구_list.SelectedIndex = -1;
            k = i;
            myUserInfo = mainForm.myUserInfo;
            netstrm = mainForm.netstrm;
        }

        private void btn_add_add_Click(object sender, EventArgs e)
        {
            List<string> list_frdname = new List<string>();
            List<User> friends_list = new List<User>();

            foreach (var selectedname in 친구_list.SelectedItems)
            {
                list_frdname.Add(selectedname.ToString());
                string searchedId = mainForm.friends.FirstOrDefault(user => user.name == (string)selectedname)?.id;
                //기존 그룹에 새로운 친구 추가 
                mainForm.groups.ElementAt(k - 1).Value.Add(new User(searchedId, "", (string)selectedname));
                friends_list.Add(new User(searchedId, "", (string)selectedname));
            }

            string groupName = mainForm.groups.ElementAt(k - 1).Key;

            Packet packet = new Packet();
            packet.action = ActionType.saveUserGroup;

            Dictionary<string, Object> fullData = new Dictionary<string, object>();
            fullData.Add("groupName", groupName);
            fullData.Add("myUserInfo", myUserInfo);
            fullData.Add("friendsInGroup", friends_list);

            packet.data = fullData;

            Packet.SendPacket(netstrm, packet);

            packet = Packet.ReceivePacket(netstrm);

            add_list = add_list.Union(list_frdname).ToList();
            fdGroupForm.update_list(add_list, k);
            this.Close();
        }
    }
}
