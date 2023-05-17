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
    public partial class fdGroup_Add_Form : Form
    {
        fdGroup_Form fdGroupForm;
        public fdGroup_Add_Form(fdGroup_Form fdGroup_Form)
        {
            InitializeComponent();
            fdGroupForm = fdGroup_Form;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            List<string> list_frdid = new List<string>();
            List<string> list_frdname = new List<string>();

            list_frdid.Add(txt_frdid1.Text);
            list_frdid.Add(txt_frdid2.Text);
            list_frdid.Add(txt_frdid3.Text);
            
            list_frdname.Add(txt_frdname1.Text);
            list_frdname.Add(txt_frdname2.Text);
            list_frdname.Add(txt_frdname3.Text);
            
            fdGroupForm.add_Grouplist(this.txt_grpname.Text, list_frdname);
            
            txt_grpname.Clear();
            txt_frdid1.Clear();
            txt_frdid2.Clear();
            txt_frdid3.Clear();
            txt_frdname1.Clear();
            txt_frdname2.Clear();
            txt_frdname3.Clear();
        }
    }
}
