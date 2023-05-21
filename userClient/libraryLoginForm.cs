﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class libraryLoginForm : UserControl
    {
        public libraryLoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LibraryUIForm libraryUIForm = new LibraryUIForm(idTbx.Text.ToString(),pwdTbx.Text.ToString());
            // id, pwd 잘 못 입력했을 때의 예외처리 필요
            libraryUIForm.Show();

            Thread libraryCrawlingThread = new Thread(new ThreadStart(libraryUIForm.doWork));
            libraryCrawlingThread.Start();
            

            /*libraryUIForm.crawlLibraryData();
            libraryUIForm.showState();
            libraryUIForm.showBookState();*/            
        }


        private void pwdTbx_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
