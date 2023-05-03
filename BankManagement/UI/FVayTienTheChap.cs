using BankManagement.Enums;
using BankManagement.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.UI
{
    public partial class FVayTienTheChap : Form
    {
        TaiKhoan taiKhoanVay = logging.Taikhoan;
        KhoanVayService kvService = new KhoanVayService();
        GiaoDichService gdService = new GiaoDichService();
        int thoiHan = 0;
        double laiSuat = 0;
        double tienVay = 0;
        double tienLai = 0;
        string vatTheChap = "";
        public FVayTienTheChap()
        {
            InitializeComponent();
        }


        private void FVayTien_Load(object sender, EventArgs e)
        {
            lblLaiSuat.Text = string.Empty;
            lblTong.Text = string.Empty;
            tbSoTK.Texts = taiKhoanVay.SoTK.ToString();
            if (logging.Taikhoan.IsAdmin < 1)
            {
                tbSoTK.Enabled = false;
            }
            lblTen.Text = taiKhoanVay.HoVaTen;
            tbTien.Texts = "10000000"; 
        }

        private void tbSoTK__TextChanged(object sender, EventArgs e)
        {
            int soTK;
            Int32.TryParse(tbSoTK.Texts, out soTK);
            using (var db = new BankModelContainer())
            {
                if (db.TaiKhoans.Any(tk => tk.SoTK == soTK))
                {
                    taiKhoanVay = db.TaiKhoans.FirstOrDefault(tk => tk.SoTK == soTK);
                    lblTen.Text = taiKhoanVay.HoVaTen;
                }
            }
        }

        private void tbTien__TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(tbTien.Texts, out tienVay))
            {
                if (tienVay >= 10000000 && tienVay <= 1000000000)
                {
                    tienLai = kvService.TinhTienLai(tienVay, thoiHan, laiSuat);
                    lblTong.Text = (tienVay + tienLai).ToString();
                }
            }
        }

        private void cbThoiGian_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Int32.TryParse(cbThoiGianVay.Texts, out thoiHan);
            if (thoiHan.ToString() != "" && Enum.IsDefined(typeof(ThoiHanTatToan), thoiHan))
            {
                laiSuat = kvService.TinhLaiSuatKhoanVay(thoiHan);
                lblLaiSuat.Text = laiSuat.ToString() + lblLaiSuat.Tag;
                tienLai = kvService.TinhTienLai(tienVay, thoiHan, laiSuat);
                lblTong.Text = (tienVay + tienLai).ToString();
            }
            else
            {
                MessageBox.Show("Thời hạn không hợp lệ so với chính sách ngân hàng!");
                cbThoiGianVay.Texts = "";
            }
        }

        private void btnVayTien_Click(object sender, EventArgs e)
        {
            if (CheckKhoanVay())
            {
                vatTheChap = tbTheChap.Texts;
                KhoanVay kv = new KhoanVay
                {
                    SoTK = taiKhoanVay.SoTK,
                    NgayVay = DateTime.Now,
                    NgayHan = DateTime.Now.AddMonths(thoiHan),
                    ThoiGian  = thoiHan,
                    SoTienVay = tienVay,
                    LaiSuat = laiSuat,
                    TinhTrang = 0,
                    LoaiKhoanVay = (int)LoaiGiaoDich.VayTheChap,
                    TheChap = new TheChap
                    {
                        VatTheChap = vatTheChap,
                    }
                };
                gdService.TaoGiaoDichVayTC(kv, vatTheChap);

                //đặt lại dữ liệu thực
                using (var db = new BankModelContainer())
                {
                    taiKhoanVay = db.TaiKhoans.FirstOrDefault(tk => tk.SoTK == taiKhoanVay.SoTK);
                    if (logging.Taikhoan.SoTK == taiKhoanVay.SoTK)
                    {
                        logging.Taikhoan = taiKhoanVay;
                    }
                }
            }
        }
        private Boolean CheckKhoanVay()
        {
            if (string.IsNullOrEmpty(tbSoTK.Texts))
            {
                MessageBox.Show("Số tài khoản không hợp lệ!");
                return false;
            }
            else
            {
                int soTK;
                if(Int32.TryParse(tbSoTK.Texts, out soTK))
                {
                    using (var db = new BankModelContainer())
                    {
                        if (!db.TaiKhoans.Any(tk => tk.SoTK == soTK))
                        {
                            MessageBox.Show("Số tài khoản không tồn tại!");
                            return false;
                        }
                        else
                        {
                           int blackUser = db.TaiKhoans.Where(tk => tk.SoTK == soTK).Select(tk => tk.DanhSachDen).FirstOrDefault();
                           if (blackUser == 1)
                            {
                                MessageBox.Show("Tài khoản nằm trong danh sách đen, không thể cho vay!");
                                return false;
                            }
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(tbTien.Texts) || tienVay < 10000000 || tienVay > 1000000000 )
            {
                MessageBox.Show("Số tiền muốn vay không hợp lệ (10000000<TienVay<1000000000) !");
                return false;
            }

            if (!Enum.IsDefined(typeof(ThoiHanTatToan), thoiHan))
            {
                MessageBox.Show("Thời hạn không hợp lệ so với chính sách ngân hàng!");
                return false;
            }

            if (string.IsNullOrEmpty(tbTheChap.Texts))
            {
                MessageBox.Show("Giá trị thế chấp không hợp lệ!");
                return false;
            }

            if (string.IsNullOrEmpty(lblLaiSuat.Text) || string.IsNullOrEmpty(lblTong.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return false;
            }
            return true;
        }

        private void tbTheChap__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
