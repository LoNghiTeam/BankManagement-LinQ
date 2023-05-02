using BankManagement.Service;
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
    public partial class FDangKy : Form
    {
        TaiKhoanService tkService = new TaiKhoanService();
        public FDangKy()
        {
            InitializeComponent();
        }
        //TextBoxEvent
        #region Các sự kiện enter và leave của textbox
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
        private void txtRepeatMK_Enter(object sender, EventArgs e)
        {
            HintTextPW(txtRepeatMK);
        }
        private void txtRepeatMK_Leave(object sender, EventArgs e)
        {
            HintTextPW(txtRepeatMK);
        }
        private void txtTen_Enter(object sender, EventArgs e)
        {
            HintTextNormal(txtTen);
        }

        private void txtTen_Leave(object sender, EventArgs e)
        {
            HintTextNormal(txtTen);
        }
        private void txtCCCD_Enter(object sender, EventArgs e)
        {
            HintTextNormal(txtCCCD);
        }

        private void txtCCCD_Leave(object sender, EventArgs e)
        {
            HintTextNormal(txtCCCD);
        }
        private void txtDiaChi_Enter(object sender, EventArgs e)
        {
            HintTextNormal(txtDiaChi);
        }

        private void txtDiaChi_Leave(object sender, EventArgs e)
        {
            HintTextNormal(txtDiaChi);
        }
        private void txtSDT_Enter(object sender, EventArgs e)
        {
            HintTextNormal(txtSDT);
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            HintTextNormal(txtSDT);
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
            }
            else
            {
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
        #endregion 
        private void lblSignin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FDangNhap login = new FDangNhap();
            login.ShowDialog();
        }
        private void btnSignup_Click(object sender, EventArgs e)
        {
            TaiKhoan taiKhoan = new TaiKhoan {
                TenTK = txtTK.Text,
                MatKhau = txtMK.Text,
                HoVaTen = txtTen.Text,
                NgaySinh = dtpNgaySinh.Value,
                CCCD = txtCCCD.Text,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text,
            };
            if (tkService.CheckDangKyTaiKhoan(taiKhoan, txtRepeatMK.Text))
            {
                tkService.ThemTKMoi(taiKhoan);
                DialogResult result = MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }


        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
