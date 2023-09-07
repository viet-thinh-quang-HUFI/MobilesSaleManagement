using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilesSaleManagementApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Label lb = new Label();
            lb.Text = "Hello";
            Controls.Add(lb);
            Label lb1 = new Label();
            lb1.Text = "Hello";
            Controls.Add(lb1);
        }
    }
}
