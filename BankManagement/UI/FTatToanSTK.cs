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
    public partial class FTatToanSTK : Form
    {
        SoTietKiemService stkService = new SoTietKiemService();
        GiaoDichService gdService = new GiaoDichService();
        SoTietKiem stk;
        double tienTT = 0;
        public FTatToanSTK()
        {
            InitializeComponent();
        }
        public FTatToanSTK(int maSTK)
        {
            InitializeComponent();
            using (var db = new BankModelContainer())
            {
                stk = db.SoTietKiems.FirstOrDefault(s => s.MaSTK == maSTK);
            }
        }

        private void FTatToanSTK_Load(object sender, EventArgs e)
        {
            //Thông tin sổ tiết kiệm
            lblMaSo.Text = stk.MaSTK.ToString();
            lblSTK.Text = stk.SoTK.ToString();
            lblTenSo.Text = stk.TenSo;
            lblNgayGD.Text = stk.NgayGui.ToString();
            lblSoTien.Text = stk.SoTienGui.ToString();
            lblTT.Text = "Chua xu ly";
            lblDaoHan.Text = stk.NgayHan.ToString();
            lblTatToan.Text = DateTime.Now.ToString();

            //Tính thời gian chênh lệch so với hạn
            TimeSpan duration = stk.NgayHan - DateTime.Now;
            int days = duration.Days;

            int months=0;
            //Số tháng được tính lãi
            if (stk.NgayHan > DateTime.Now)
            {
                duration = DateTime.Now - stk.NgayGui;
                months = (int)Math.Round(duration.TotalDays/30);
                lblSoThang.Text = Math.Abs(months).ToString();
            }
            else
            {
                months = stk.ThoiGian;
                lblSoThang.Text = months.ToString();
            }

            //Tính tiền lãi
            double tienLai = stkService.TinhTienLai(stk.SoTienGui, months, stk.LaiSuat);

            //Tính tiền phạt 
            double tienPhat = 0;
            if (days > 0)
            {
                tienPhat = stkService.TinhTienLai(stk.SoTienGui, stk.ThoiGian - months, stk.LaiSuat);
            }

            //Tính tiền tổng nhận được sau khi xử lý
            tienTT = stk.SoTienGui + tienLai - tienPhat;

            //Hiển thị thông tin 3 loại tiền
            lblPhat.Text = tienPhat.ToString();
            lblTien.Text = tienTT.ToString();
            lblTam.Text = tienLai.ToString();
        }

        private void btnTatToan_Click(object sender, EventArgs e)
        {
            gdService.TaoGiaoDichTatToanSTK(stk, tienTT);
            this.Close();
        }
    }
}
