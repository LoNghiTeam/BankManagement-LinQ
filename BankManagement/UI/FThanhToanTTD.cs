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
        GiaoDich gd;

        TheTinDung theTD;
        TaiKhoan taiKhoan;
        List<GiaoDich> dsGiaoDich;
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

            lblTienNo.Text = (theTD.HanMuc - theTD.SoDu).ToString();
            lblTrangThai.Text = Enum.GetName(typeof(TrangThai), theTD.TrangThai);
            dsGiaoDich = theTDService.GetDSNoTheTD(taiKhoan.SoTK);
            cbGiaoDich.DataSource = dsGiaoDich;
            cbGiaoDich.DisplayMember = "NoiDungGD";
        }

        private void btnTatToan_Click(object sender, EventArgs e)
        {
            gdService.TaoGiaoDichThanhToanNoTheTD(gd.MaGD,theTD.MaTTD, taiKhoan.SoTK, tienTong);
            this.Close();
        }

        private void cbGiaoDich_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            gd = (GiaoDich)cbGiaoDich.SelectedItem;
            tienNo = gd.SoTienGD;
            lbTraNo.Text = tienNo.ToString();
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

            btnTatToan.Enabled = true;
        }
    }
}

