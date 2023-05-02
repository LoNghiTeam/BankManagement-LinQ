using BankManagement.Service;
using BankManagement.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement
{
    public partial class FDangNhap : Form
    {
        TaiKhoanService tkService = new TaiKhoanService();

        public FDangNhap()
        {
            InitializeComponent();
        }

        private void icpbMK_MouseUp(object sender, MouseEventArgs e)
        {
            txtMK.UseSystemPasswordChar = true;
        }

        private void icpbMK_MouseDown(object sender, MouseEventArgs e)
        {
            txtMK.UseSystemPasswordChar = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
           txtTK.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tkService.CheckTenTKVaMK(txtTK.Text, txtMK.Text))
            {
                BankModelContainer db = new BankModelContainer();
                logging.Taikhoan = db.TaiKhoans.FirstOrDefault(t => t.TenTK == txtTK.Text);
                this.Hide();
                if (logging.Taikhoan.IsAdmin != 0)
                {
                    FHomeNV fHomeNV = new FHomeNV();
                    fHomeNV.ShowDialog();
                }
                else
                {
                    FHomeKH fHomeKH = new FHomeKH();
                    fHomeKH.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
            }
        }

        private void lblSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FDangKy signup = new FDangKy();
            signup.ShowDialog();
        }

        private void txtTK_Enter(object sender, EventArgs e)
        {
            HintTextNormal(txtTK);
        }
        private void txtTK_Leave(object sender, EventArgs e)
        {
            HintTextNormal(txtTK);
        }
        private void txtMK_Leave(object sender, EventArgs e)
        {
            HintTextPW(txtMK);
        }
        private void txtMK_Enter(object sender, EventArgs e)
        {
            HintTextPW(txtMK);
        }
        private void HintTextPW(TextBox tbx)
        {
            tbx.PasswordChar = '\0';
            if (tbx.Text == tbx.Tag.ToString())
            {
                tbx.Text = "";
                tbx.ForeColor = Color.Black;
                tbx.PasswordChar = '●';
            }
            else if (tbx.Text == "")
            {
                tbx.Text = tbx.Tag.ToString();
                tbx.ForeColor = Color.Silver;
                tbx.PasswordChar = '●';
            }
        }
        private void HintTextNormal(TextBox tbx)
        {
            if (tbx.Text == tbx.Tag.ToString())
            {
                tbx.Text = "";
                tbx.ForeColor = Color.Black;
            }
            else if (tbx.Text == "")
            {
                tbx.Text = tbx.Tag.ToString();
                tbx.ForeColor = Color.Silver;
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
