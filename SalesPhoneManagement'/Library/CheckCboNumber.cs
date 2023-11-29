using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public class CheckCboNumber : ComboBox
    {
        public CheckCboNumber()
        {
            this.KeyPress += CheckCboNumber_KeyPress;
        }
        private void CheckCboNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số!!!");
            }
            else
            {
                ComboBox comboBox = (ComboBox)sender;
                int num;
                if (!int.TryParse(comboBox.Text, out num) || num < 1 || num > 9999)
                {
                    MessageBox.Show("Vui lòng nhập số từ 1 đến 9999!!!");
                    comboBox.Text = "";
                }
            }
        }
    }
}
