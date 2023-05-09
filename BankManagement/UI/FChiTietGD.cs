using BankManagement.Enums;
using BankManagement.Service;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BankManagement.UI
{
    public partial class FChiTietGD : Form
    {
        TaiKhoanService tkService = new TaiKhoanService();
        GiaoDichService gdService = new GiaoDichService();

        GiaoDich gd = new GiaoDich();
        TaiKhoan taiKhoanGui = new TaiKhoan();
        TaiKhoan taiKhoanNhan = new TaiKhoan();

        public FChiTietGD()
        {
            InitializeComponent();
        }
        public FChiTietGD(int maGD)
        {
            InitializeComponent();
            {
                gd = gdService.GetGiaoDich(maGD);
                taiKhoanGui = tkService.GetTaiKhoan(gd.MaNguoiGui);
                taiKhoanNhan = tkService.GetTaiKhoan(gd.MaNguoiNhan);
            }
        }
        private void FChiTietGD_Load(object sender, EventArgs e)
        {
            tbxMaGD.Texts = gd.MaGD.ToString();
            tbxTien.Texts = gd.SoTienGD.ToString();
            tbxNgayGD.Texts = gd.NgayGD.ToString();
            tbxMaNgGui.Texts = gd.MaNguoiGui.ToString();
            tbxMaNgNhan.Texts = gd.MaNguoiNhan.ToString();
            tbxTenNgGui.Texts = taiKhoanGui.HoVaTen;
            tbxTenNgNhan.Texts = taiKhoanNhan.HoVaTen;
            tbxLoaiGD.Texts = Enum.GetName(typeof(LoaiGiaoDich), gd.LoaiGD);
        }
    }
}
