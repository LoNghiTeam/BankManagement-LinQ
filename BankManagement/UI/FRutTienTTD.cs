﻿using BankManagement.Service;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BankManagement.UI
{
    public partial class FRutTienTTD : Form
    {
        GiaoDichService gdService = new GiaoDichService();
        TheTinDungService ttdService = new TheTinDungService();
        TheTinDung theTD;
        TaiKhoan taiKhoanRut;
        double soTien = 0;
        public FRutTienTTD(TheTinDung theTinDung, TaiKhoan tk)
        {
            InitializeComponent();
            theTD = theTinDung;
            taiKhoanRut = tk;
        }

        private void FRutTienTTD_Load(object sender, EventArgs e)
        {
            lblSoTK.Text = theTD.SoTK.ToString();
            lblMaSoThe.Text = theTD.MaTTD.ToString();
            lblTen.Text = theTD.TenChuThe;
            lblSoDu.Text = theTD.SoDu.ToString();
        }

        private void tbTienRut__TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(tbTienRut.Texts, out soTien))
            {
                soTien = 0;
            }
        }

        private void btnRut_Click(object sender, EventArgs e)
        {
            if (CheckRutTien())
            {
                gdService.TaoGiaoDichRutTienTheTD(taiKhoanRut.SoTK, theTD.MaTTD, soTien);

                theTD = ttdService.GetTheTinDung(theTD.MaTTD);
                lblSoDu.Text = theTD.SoDu.ToString();
            }
        }

        private Boolean CheckRutTien()
        {
            if (taiKhoanRut == null)
            {
                MessageBox.Show("Tài khoản nhận không chính xác hoặc lỗi!");
                return false;
            }
            if (soTien <= 0 || soTien > theTD.SoDu)
            {
                MessageBox.Show("Số tiền rút không hợp lệ! (0 < số tiền =< số dư tín dụng)");
                return false;
            }
            return true;
        }
    }
}
