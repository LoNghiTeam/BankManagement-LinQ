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
    public partial class FRutTien : Form
    {
        GiaoDichService gdService = new GiaoDichService();
        TaiKhoanService tkService = new TaiKhoanService();

        TaiKhoan taiKhoan = logging.Taikhoan;
        double tienRut=0;
        public FRutTien()
        {
            InitializeComponent();
        }
        private void FRutTien_Load(object sender, EventArgs e)
        {
            lblSoDu.Text = taiKhoan.SoDu.ToString();
            lblTen.Text = taiKhoan.HoVaTen;
            tbxSoTK.Texts = taiKhoan.SoTK.ToString();
            btnRut.Enabled = false;

            if(logging.Taikhoan.IsAdmin != 1)
            {
                tbxSoTK.Enabled = false;
            }
        }

        private void tbSoTK__TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRut_Click(object sender, EventArgs e)
        {
            if (CheckRutTien())
            {
                gdService.TaoGiaoDichRut(taiKhoan.SoTK, tienRut);
                
                taiKhoan = tkService.GetTaiKhoan(taiKhoan.SoTK);
                lblSoDu.Text = taiKhoan.SoDu.ToString();

                if (logging.Taikhoan.SoTK == taiKhoan.SoTK)
                {
                    logging.Taikhoan = taiKhoan;
                }
            }
        }

        private Boolean CheckRutTien()
        {
            if (taiKhoan == null)
            {
                MessageBox.Show("Tài khoản không xác định!");
                return false;
            }
            if (tienRut > taiKhoan.SoDu || tienRut <= 0)
            {
                MessageBox.Show("Số tiền rút không hợp lệ! (0 < tiền rút =< số dư)");
                return false;
            }
            return true;
        }

        private void tbTienRut__TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(tbTienRut.Texts, out tienRut);
            if (tienRut <= taiKhoan.SoDu && tienRut > 0)
            {
                btnRut.Enabled = true;
            }
            else
            {
                btnRut.Enabled = false;
            }
        }

        private void tbxSoTK__TextChanged(object sender, EventArgs e)
        {
            int soTK;
            if(Int32.TryParse(tbxSoTK.Texts, out soTK))
            {
                if(tkService.CheckSoTaiKhoan(soTK))
                {
                    taiKhoan = tkService.GetTaiKhoan(soTK);
                    lblTen.Text = taiKhoan.HoVaTen;
                    lblSoDu.Text = taiKhoan.SoDu.ToString();
                }
            }
        }
    }
}
