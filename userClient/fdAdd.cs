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

namespace Client
{
    public partial class fdAdd : Form
    {
        fdList fdList;
        NetworkStream netstrm;
        public fdAdd(fdList form, NetworkStream netstrm)
        {
            InitializeComponent();
            fdList = form;
            this.netstrm = netstrm;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

            fdList.bool_tf = true;
            fdList.add_label(this.txt_id.Text,this.txt_SearchedName.Text);
            txt_id.Clear();
        }

        private void fdAdd_Load(object sender, EventArgs e)
        {

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.id = txt_id.Text;

            Packet packet = new Packet();
            packet.action = ActionType.readUser;
            packet.data = user;

            Packet.SendPacket(netstrm, packet);

            packet = Packet.ReceivePacket(netstrm);

            if(packet.action == ActionType.Fail)
            {
                txt_SearchedName.Text = "(해당 사용자 정보가 없습니다)";
                user.name = "";
            }else if(packet.action == ActionType.Success)
            {
                user = (User)packet.data;
                txt_SearchedName.Text = user.name;
            }
        }
    }
}