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
    public partial class FNapTien : Form
    {
        TaiKhoanService tkService = new TaiKhoanService();
        GiaoDichService gdService = new GiaoDichService();
        TaiKhoan taiKhoan = logging.Taikhoan;
        public FNapTien()
        {
            InitializeComponent();
        }
        private void btnNap_Click(object sender, EventArgs e)
        {
            double soTien;
            if (!double.TryParse(tbSoTien.Text, out soTien))
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (soTien.ToString() == "" && soTien <= 0)
            {
                MessageBox.Show("Yêu cầu nhập số tiền nạp! (>0)", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            gdService.TaoGiaoDichNap(taiKhoan.SoTK, soTien);

            BankModelContainer db = new BankModelContainer();
            taiKhoan = db.TaiKhoans.FirstOrDefault(tk => tk.SoTK == taiKhoan.SoTK);
            if (logging.Taikhoan.SoTK == taiKhoan.SoTK)
                logging.Taikhoan = taiKhoan;
            lblSoDu.Text = taiKhoan.SoDu.ToString();
        }

        private void NapTien_Load(object sender, EventArgs e)
        {
            btnNap.Enabled = false;
            tbSoTK.Text = taiKhoan.SoTK.ToString();
            lblSoDu.Text = taiKhoan.SoDu.ToString() + lblSoDu.Tag;
            lblNguoiNhan.Text = taiKhoan.HoVaTen;
            if (logging.Taikhoan.IsAdmin != 1)
            {
                tbSoTK.Enabled = false;
                btnCheck.Enabled = false;
                btnNap.Enabled = true;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            BankModelContainer db = new BankModelContainer();
            int result;
            Int32.TryParse(tbSoTK.Text, out result);
            if (db.TaiKhoans.Any(tk => tk.SoTK == result)) 
            {
                taiKhoan = db.TaiKhoans.FirstOrDefault(tk => tk.SoTK == result);
                lblNguoiNhan.Text = taiKhoan.HoVaTen;
                lblSoDu.Text = taiKhoan.SoDu.ToString() + lblSoDu.Tag;
                btnNap.Enabled = true;
            }
            else
            {
                MessageBox.Show("Số tài khoản không hợp lệ hoặc không tồn tại!");
            }
        }
    }
}
