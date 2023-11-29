using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public class CheckNumber :TextBox
    {
        public CheckNumber()
        {
            this.KeyPress += CheckNumber_KeyPress;
        }
        private void CheckNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')  // Kiểm tra nếu người dùng nhấn phím Backspace để xóa ký tự
            {
                e.Handled = false;  // Cho phép xóa ký tự
                return;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số!!!");
            }
            else
            {
                string newText = (sender as TextBox).Text + e.KeyChar;
                int num;
                if (!int.TryParse(newText, out num) || num < 1 || num > 9999)
                {
                    e.Handled = true;
                    MessageBox.Show("Vui lòng nhập số từ 1 đến 9999!!!");
                }
            }
        }
    }
}
