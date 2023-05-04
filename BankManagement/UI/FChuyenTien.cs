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
    public partial class FChuyenTien : Form
    {
        GiaoDichService gdService = new GiaoDichService();
        TaiKhoan taiKhoanChuyen = logging.Taikhoan;
        TaiKhoan taiKhoanNhan;
        public FChuyenTien()
        {
            InitializeComponent();
        }


        private void GiaoDich_Load(object sender, EventArgs e)
        {
            btnChuyenTien.Enabled = false;
            lblNguoiChuyen.Text = taiKhoanChuyen.HoVaTen;
            tbxSoTKChuyen.Text = taiKhoanChuyen.SoTK.ToString();
            lblSoDu.Text = taiKhoanChuyen.SoDu.ToString() + " VND";
            if (logging.Taikhoan.IsAdmin != 1)
            {
                tbxSoTKChuyen.Enabled = false;
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            BankModelContainer db = new BankModelContainer();
            int soTKNhan;
            Int32.TryParse(tbxSoTKNhan.Text, out soTKNhan);
            if (db.TaiKhoans.Any(tk=> tk.SoTK == soTKNhan))
            {
                taiKhoanNhan = db.TaiKhoans.FirstOrDefault(tk => tk.SoTK == soTKNhan);
                if (taiKhoanNhan.SoTK != taiKhoanChuyen.SoTK)
                {
                    btnChuyenTien.Enabled = true;
                    lblNguoiNhan.Text = taiKhoanNhan.HoVaTen;
                }
                else
                    MessageBox.Show("Không thể chuyển tiền cho bản thân!", "Thông báo", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Số tài khoản không tìm thấy hoặc không hợp lệ!", "Thông báo", MessageBoxButtons.OK);

        }
        private void btnChuyenTien_Click(object sender, EventArgs e)
        {
            double soTien;
            if (double.TryParse(tbSoTien.Text, out soTien))
            {
                if (soTien.ToString() != "" && soTien > 0)
                {
                    if (taiKhoanChuyen.SoDu >= soTien)
                    {
                        gdService.TaoGiaoDichChuyenTien(taiKhoanChuyen.SoTK, taiKhoanNhan.SoTK, soTien);
                        BankModelContainer db = new BankModelContainer();
                        taiKhoanChuyen = db.TaiKhoans.FirstOrDefault(tk => tk.SoTK == taiKhoanChuyen.SoTK);
                        taiKhoanNhan = db.TaiKhoans.FirstOrDefault(tk => tk.SoTK == taiKhoanNhan.SoTK);
                        if (logging.Taikhoan.SoTK == taiKhoanChuyen.SoTK || logging.Taikhoan.SoTK == taiKhoanNhan.SoTK)
                        {
                            logging.Taikhoan = db.TaiKhoans.FirstOrDefault(t => t.SoTK == logging.Taikhoan.SoTK);
                        }

                        lblSoDu.Text = taiKhoanChuyen.SoDu.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Số dư không đủ để chuyển tiền!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else 
                { 
                    MessageBox.Show("Yêu cầu nhập số tiền cần chuyển (>0)!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void tbxSoTKChuyen_TextChanged(object sender, EventArgs e)
        {
            int soTKChuyen;
            Int32.TryParse(tbxSoTKChuyen.Text, out soTKChuyen);
            BankModelContainer db = new BankModelContainer();
            if(db.TaiKhoans.Any(tk=>tk.SoTK == soTKChuyen))
            {
                taiKhoanChuyen = db.TaiKhoans.FirstOrDefault(tk => tk.SoTK == soTKChuyen);
                lblNguoiChuyen.Text = taiKhoanChuyen.HoVaTen;
                lblSoDu.Text = taiKhoanChuyen.SoDu.ToString();
                btnChuyenTien.Enabled = true;
            }
        }
    }
}
