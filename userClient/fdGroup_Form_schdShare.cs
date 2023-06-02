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
    public partial class fdGroup_Form_schdShare : Form
    {
        NetworkStream netstrm;
        fdGroup_Form fdGroup_Form;
        List<string> list = new List<string>();
        public fdGroup_Form_schdShare(fdGroup_Form form, NetworkStream netstrm, List<string> list_id)
        {
            InitializeComponent();
            fdGroup_Form = form;
            this.netstrm = netstrm;
            list = list_id;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            //User들 id list에 담겨있어요. 
            //this.tbx_content.Text;
            //this.tbx_Schedule.Text;
        }
    }
}
