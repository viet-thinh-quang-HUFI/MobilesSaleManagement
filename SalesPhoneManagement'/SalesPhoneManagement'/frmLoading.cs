﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPhoneManagement_
{
    public partial class frmLoading : Form
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 3;
            //534
            if (panel1.Width >= 534)
            {
                timer1.Stop();
                frmMain main = new frmMain();
                main.Show();
                this.Hide();
            }
        }
    }
}
