using BankManagement.Enums;
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
    public partial class FTietKiem : Form
    {
        TaiKhoan taiKhoanTK = logging.Taikhoan;
        SoTietKiemService gtkService= new SoTietKiemService();
        GiaoDichService gdService = new GiaoDichService();
        int thoiHan = 0;
        double laiSuat = 0;
        double tienGui = 0;
        double tienLai = 0;

        public FTietKiem()
        {
            InitializeComponent();
        }

        private void FTietKiem_Load(object sender, EventArgs e)
        {
            lblRate.Text = string.Empty;
            if (logging.Taikhoan.IsAdmin < 1)
            {
                tbSoTK.Enabled = false;
            }
            tbSoTK.Texts = logging.Taikhoan.SoTK.ToString();
            lblTienHienCo.Text = logging.Taikhoan.SoDu.ToString();
            lblTamTinh.Text = string.Empty;
        }

        private void tbSoTK__TextChanged(object sender, EventArgs e)
        {
            int soTK;
            Int32.TryParse(tbSoTK.Texts, out soTK);
            using (var db = new BankModelContainer())
            {
                if (db.TaiKhoans.Any(tk => tk.SoTK == soTK))
                {
                    taiKhoanTK = db.TaiKhoans.FirstOrDefault(tk => tk.SoTK == soTK);
                    lblTen.Text = taiKhoanTK.HoVaTen;
                    lblTienHienCo.Text = taiKhoanTK.SoDu.ToString();
                }
            }
        }

        private void cbThoiGian_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Int32.TryParse(cbThoiGian.Texts, out thoiHan);
            if (thoiHan.ToString() != "" && Enum.IsDefined(typeof(ThoiHanTatToan), thoiHan))
            {
                laiSuat = gtkService.TinhLaiSuatTietKiem(thoiHan);
                lblRate.Text = laiSuat.ToString() + lblRate.Tag;
                tienLai = gtkService.TinhTienLai(tienGui, thoiHan, laiSuat);
                lblTamTinh.Text = (tienGui+tienLai).ToString();
                tbTienGui.Enabled = true;
            }
            else
            {
                MessageBox.Show("Thời hạn không hợp lệ so với chính sách ngân hàng!");
                tbTienGui.Enabled = false;
                cbThoiGian.Texts = "";
            }
        }

        private void tbTienGui__TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(tbTienGui.Texts, out tienGui))
            {
                if (tienGui <= taiKhoanTK.SoDu && tienGui > 0)
                {
                    tienLai = gtkService.TinhTienLai(tienGui, thoiHan, laiSuat);
                    lblTamTinh.Text = (tienGui + tienLai).ToString();
                }
            }
        }

        private void btnGuiTietKiem_Click(object sender, EventArgs e)
        {
            if (CheckSoTK())
            {
                SoTietKiem stk = new SoTietKiem
                {
                    SoTK = taiKhoanTK.SoTK,
                    TenSo = tbTenSo.Texts,
                    NgayGui = DateTime.Now,
                    NgayHan = DateTime.Now.AddMonths(thoiHan),
                    SoTienGui = tienGui,
                    LaiSuat = laiSuat,
                    ThoiGian = thoiHan,
                    TinhTrang = 0
                };
                gdService.TaoGiaoDichGuiTietKiem(stk);

                using (var db = new BankModelContainer())
                {
                    taiKhoanTK = db.TaiKhoans.FirstOrDefault(tk => tk.SoTK == taiKhoanTK.SoTK);
                }

                lblTienHienCo.Text = taiKhoanTK.SoDu.ToString();
            }
        }

        private Boolean CheckSoTK()
        {
            if (string.IsNullOrEmpty(tbSoTK.Texts))
            {
                MessageBox.Show("Số tài khoản không hợp lệ!");
                return false;
            }
            if (string.IsNullOrEmpty(tbTenSo.Texts))
            {
                MessageBox.Show("Tên sổ không hợp lệ hoặc rỗng!");
                return false;
            }
            if (string.IsNullOrEmpty(cbThoiGian.Texts))
            {
                MessageBox.Show("Thời hạn không hợp lệ hoặc rỗng!");
                return false;
            }
            if (string.IsNullOrEmpty(tbTienGui.Texts))
            {
                MessageBox.Show("Số tiền gửi không hợp lệ hoặc rỗng!");
                return false;
            }
            if (tienGui > taiKhoanTK.SoDu || tienGui <= 0)
            {
                MessageBox.Show("Số tiền gửi không hợp lệ ( 0<tiền gửi <= số dư )!");
                return false;
            }
            if (!Enum.IsDefined(typeof(ThoiHanTatToan), thoiHan))
            {
                MessageBox.Show("Thời hạn không hợp lệ so với chính sách ngân hàng!");
                tbTienGui.Enabled = false;
                return false;
            }
            return true;
        }
    }
}
