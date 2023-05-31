using EntityLibrary;
using PacketLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class fdList : Form
    {
        NetworkStream netstrm;
        mainForm mainform;
        User myUserInfo = mainForm.myUserInfo;

        Label[] labels = new Label[20];
        Label[] labels2 = new Label[20];
        Button[] btn_chat = new Button[20];
        Button[] btn_delete = new Button[20];
        Panel[] panel = new Panel[20];

        int labelWidth = 50;
        int labelHeight = 25;
        static int A = 1;

        static int cntlbl = mainForm.friends.Count;


        public fdList(NetworkStream netstrm)
        {
            InitializeComponent();
            this.netstrm = netstrm;
            list_load();

        }
        private void list_load()
        {
            for (int i = 1; i <= mainForm.friends.Count; i++)
            {
                labels2[i] = new Label();
                labels2[i].Location = new Point(310, 60 + 50 * i);
                labels2[i].Size = new Size(labelWidth + 15, labelHeight);
                labels2[i].Text = mainForm.friends[i - 1].id;
                labels2[i].Tag = i;


                labels[i] = new Label();
                labels[i].Location = new Point(labels2[i].Location.X + 65, labels2[i].Location.Y);
                labels[i].Size = new Size(labelWidth, labelHeight);
                labels[i].Text = mainForm.friends[i - 1].name;
                labels[i].Tag = i;

                btn_chat[i] = new Button();
                btn_chat[i].Location = new Point(labels2[i].Location.X + 115, labels2[i].Location.Y - 10);
                btn_chat[i].Size = new Size(labelWidth, labelHeight);
                btn_chat[i].Text = "채팅";
                btn_chat[i].Tag = i;

                btn_delete[i] = new Button();
                btn_delete[i].Location = new Point(labels2[i].Location.X + 165, labels2[i].Location.Y - 10);
                btn_delete[i].Size = new Size(labelWidth, labelHeight);
                btn_delete[i].Text = "삭제";
                btn_delete[i].Tag = i;


                btn_delete[i].Click += new EventHandler(btn_delete_Click);

                panel[i] = new Panel();
                panel[i].Location = new Point(labels2[i].Location.X, labels2[i].Location.Y + 15);
                panel[i].Size = new Size(215, 1);
                panel[i].BackColor = Color.Black;
                panel[i].Tag = i;

                this.Controls.Add(panel[i]);
                this.Controls.Add(labels2[i]);
                this.Controls.Add(labels[i]);
                this.Controls.Add(btn_chat[i]);
                this.Controls.Add(btn_delete[i]);
            }

        }

        private void btn_addfd_Click(object sender, EventArgs e)
        {
            fdAdd fdAdd = new fdAdd(this, this.netstrm);
            fdAdd.ShowDialog();
        }

        public void add_label(string id, string s)
        {
            if ((id != "") && (s != ""))
            {
                User friend = new User();
                friend.id = id;

                Packet packet = new Packet();

                packet.action = ActionType.saveFriendship;

                Dictionary<String, Object> fullData = new Dictionary<String, Object>();
                fullData.Add("user", myUserInfo);
                fullData.Add("friend", friend);

                packet.data = fullData;

                Packet.SendPacket(netstrm, packet);

                packet = Packet.ReceivePacket(netstrm);

                if (packet.action == ActionType.Success)
                {
                    cntlbl = mainForm.friends.Count;
                    A = cntlbl;

                    labels2[A] = new Label();
                    labels2[A].Location = new Point(310, 60 + 50 * A);
                    labels2[A].Size = new Size(labelWidth + 15, labelHeight);
                    labels2[A].Text = id;
                    labels2[A].Tag = A;


                    labels[A] = new Label();
                    labels[A].Location = new Point(labels2[A].Location.X + 65, labels2[A].Location.Y);
                    labels[A].Size = new Size(labelWidth, labelHeight);
                    labels[A].Text = s;
                    labels[A].Tag = A;

                    btn_chat[A] = new Button();
                    btn_chat[A].Location = new Point(labels2[A].Location.X + 115, labels2[A].Location.Y - 10);
                    btn_chat[A].Size = new Size(labelWidth, labelHeight);
                    btn_chat[A].Text = "채팅";
                    btn_chat[A].Tag = A;

                    btn_delete[A] = new Button();
                    btn_delete[A].Location = new Point(labels2[A].Location.X + 165, labels2[A].Location.Y - 10);
                    btn_delete[A].Size = new Size(labelWidth, labelHeight);
                    btn_delete[A].Text = "삭제";
                    btn_delete[A].Tag = A;


                    btn_delete[A].Click += new EventHandler(btn_delete_Click);

                    panel[A] = new Panel();
                    panel[A].Location = new Point(labels2[A].Location.X, labels2[A].Location.Y + 15);
                    panel[A].Size = new Size(215, 1);
                    panel[A].BackColor = Color.Black;
                    panel[A].Tag = A;

                    this.Controls.Add(panel[A]);
                    this.Controls.Add(labels2[A]);
                    this.Controls.Add(labels[A]);
                    this.Controls.Add(btn_chat[A]);
                    this.Controls.Add(btn_delete[A]);

                    cntlbl++;
                    A++;
                }
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int idx = (int)btn.Tag;
            A = mainForm.friends.Count + 1;
            // sql로 db에서 해당 친구 delete 문 필요 id 담아드렸어요
            User friend = new User();
            friend.id = mainForm.friends[idx - 1].id;

            Packet packet = new Packet();

            packet.action = ActionType.deleteFriendship;

            Dictionary<String, Object> fullData = new Dictionary<String, Object>();
            fullData.Add("user", myUserInfo);
            fullData.Add("friend", friend);

            packet.data = fullData;

            Packet.SendPacket(netstrm, packet);

            packet = Packet.ReceivePacket(netstrm);

            if (packet.action == ActionType.Success)
            {
                // 해당 index정보 삭제
                mainForm.friends.RemoveAt(idx - 1);


                if (idx < A - 1)
                {
                    labels[idx].Text = labels[A - 1].Text;
                    labels2[idx].Text = labels2[A - 1].Text;

                    this.Controls.Remove(labels2[A - 1]);
                    this.Controls.Remove(btn_delete[A - 1]);
                    this.Controls.Remove(labels[A - 1]);
                    this.Controls.Remove(btn_chat[A - 1]);
                    this.Controls.Remove(panel[A - 1]);

                }
                else
                {
                    this.Controls.Remove(labels2[idx]);
                    this.Controls.Remove(btn_delete[idx]);
                    this.Controls.Remove(labels[idx]);
                    this.Controls.Remove(btn_chat[idx]);
                    this.Controls.Remove(panel[idx]);
                }
                A--;
                cntlbl--;
            }

        }
    }
}
