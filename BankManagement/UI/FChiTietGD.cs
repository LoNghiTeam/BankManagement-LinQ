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
    public partial class FChiTietGD : Form
    {
        private int maGD;
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
            this.maGD = maGD;
            using (var db = new BankModelContainer())
            {
                gd = db.GiaoDiches.FirstOrDefault(g => g.MaGD == maGD);
                taiKhoanGui = db.TaiKhoans.FirstOrDefault(t => t.SoTK == gd.MaNguoiGui);
                taiKhoanNhan = db.TaiKhoans.FirstOrDefault(t => t.SoTK == gd.MaNguoiNhan);
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
