using BankManagement.Enums;
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

namespace BankManagement.UI
{

    public partial class FThanhToanTTD : Form
    {
        GiaoDichService gdService = new GiaoDichService();
        TheTinDungService theTDService = new TheTinDungService();

        TheTinDung theTD;
        TaiKhoan taiKhoan;
        double tienNo = 0;
        double tienPhat = 0;
        double tienTong = 0;
        public FThanhToanTTD(TheTinDung theTinDung, TaiKhoan tk)
        {
            InitializeComponent();
            theTD = theTinDung;
            taiKhoan = tk;
        }

        private void FThanhToanTTD_Load(object sender, EventArgs e)
        {
            lblSoTK.Text = taiKhoan.SoTK.ToString();
            lblTen.Text = taiKhoan.HoVaTen;
            lblMST.Text = theTD.MaTTD.ToString();
            lblSoDu.Text = taiKhoan.SoDu.ToString();

            tienNo = theTD.HanMuc - theTD.SoDu;
            lblTienNo.Text = tienNo.ToString();

            lblTrangThai.Text = Enum.GetName(typeof(TrangThai), theTD.TrangThai);
            lblNgayHan.Text = theTD.NgayHan.ToString();
            lblNgayThanhToan.Text = DateTime.Now.ToString();

            //Tính phí phạt
            TimeSpan duration = theTD.NgayHan - DateTime.Now;
            int days = duration.Days;
            lblSaiLech.Text = "0";

            if (days < 0)
            {
                lblSaiLech.Text = Math.Abs(days).ToString();
                tienPhat = theTDService.TinhTienLai(tienNo, days);
            }

            //Tính tổng tiền
            tienTong = tienNo + tienPhat;
            lblTong.Text = tienTong.ToString();
            lblPhat.Text = tienPhat.ToString();
        }

        private void btnTatToan_Click(object sender, EventArgs e)
        {
            gdService.TaoGiaoDichThanhToanNoTheTD(theTD.MaTTD, taiKhoan.SoTK, tienTong);
            this.Close();
        }
    }
}

