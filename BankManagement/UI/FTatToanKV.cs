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
    public partial class FTatToanKV : Form
    {
        KhoanVayService kvService = new KhoanVayService();
        GiaoDichService gdService = new GiaoDichService();
        KhoanVay kv;
        double laiSuat = 0;
        double tienTT = 0;
        public FTatToanKV()
        {
            InitializeComponent();
        }

        internal FTatToanKV(int soKV)
        {
            InitializeComponent();
            using (var db = new BankModelContainer())
            {
                kv = db.KhoanVays.FirstOrDefault(v => v.SoKV == soKV);
            }
        }

        private void FTatToanKV_Load(object sender, EventArgs e)
        {
            lblSoKV.Text = kv.SoKV.ToString();
            lblSTK.Text = kv.SoTK.ToString();
            lblNgayVay.Text = kv.NgayVay.ToString();
            lblDaoHan.Text = kv.NgayHan.ToString();
            lblSoTien.Text = kv.SoTienVay.ToString();
            lblTT.Text = "Chưa tất toán";
            lblLoai.Text = Enum.GetName(typeof(LoaiGiaoDich), kv.LoaiKhoanVay);

            //Tính thời gian chênh lệch so với hạn
            lblNgayTT.Text = DateTime.Now.ToString();
            TimeSpan duration = DateTime.Now - kv.NgayHan;
            int tongSoNgayLech = duration.Days;
            lblNgaySai.Text = Math.Abs(tongSoNgayLech).ToString();

            int months = 0;
            //Số tháng tính lãi
            duration = DateTime.Now - kv.NgayVay;
            months = (int)Math.Round(duration.TotalDays / 30);
            lblThang.Text = months.ToString();

            //Tính tiền lãi
            double tienLai = kvService.TinhTienLai(kv.SoTienVay, months, kv.LaiSuat);

            //Tính tiền phạt 
            double tienPhat = 0;
            if (tongSoNgayLech > 0)
            {
                tienPhat = kvService.TinhTienLai(kv.SoTienVay, months - kv.ThoiGian +1, kv.LaiSuat);
            }
            else if(tongSoNgayLech < 0)
            {
                tienPhat = kvService.TinhTienLai(kv.SoTienVay, 1, kv.LaiSuat);
            }

            //Tính tiền tổng nhận được sau khi xử lý
            tienTT = kv.SoTienVay + tienLai + tienPhat;

            //Hiển thị thông tin 3 loại tiền
            lblPhat.Text = tienPhat.ToString();
            lblTongTien.Text = tienTT.ToString();
            lblTienLai.Text = tienLai.ToString();
        }
       
        private void btnTatToan_Click(object sender, EventArgs e)
        {
            gdService.TaoGiaoDichTatToanKV(kv, tienTT);
            if(logging.Taikhoan.SoTK == kv.SoTK)
            {
                using (var db = new BankModelContainer())
                {
                    logging.Taikhoan = db.TaiKhoans.FirstOrDefault(tk=>tk.SoTK== kv.SoTK);
                }
            }
            this.Close();
        }
    }
}
