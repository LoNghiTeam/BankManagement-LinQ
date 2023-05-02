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
        public FRutTien()
        {
            InitializeComponent();
        }
        TaiKhoan taiKhoan = new TaiKhoan();
        private void FRutTien_Load(object sender, EventArgs e)
        {
            lblSoDu.Text = logging.Taikhoan.SoDu.ToString();
            lblTen.Text = logging.Taikhoan.HoVaTen;
            lblSoTK.Text = logging.Taikhoan.SoTK.ToString();
            btnRut.Enabled = false;
        }

        private void tbSoTK__TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRut_Click(object sender, EventArgs e)
        {
            double tienRut;
            Double.TryParse(tbTienRut.Texts, out tienRut);
            if (tienRut <= logging.Taikhoan.SoDu)
            {
                gdService.TaoGiaoDichRut(logging.Taikhoan, tienRut);
                BankModelContainer db = new BankModelContainer();
                logging.Taikhoan = db.TaiKhoans.FirstOrDefault(tk => tk.SoTK == logging.Taikhoan.SoTK);
                lblSoDu.Text = logging.Taikhoan.SoDu.ToString();
            }
            else
            {
                MessageBox.Show("Số dư không đủ để rút tiền");
            }
        }

        private void tbTienRut__TextChanged(object sender, EventArgs e)
        {
            double tienRut;
            Double.TryParse(tbTienRut.Texts, out tienRut);
            if (tienRut <= logging.Taikhoan.SoDu)
            {
                btnRut.Enabled = true;
            }
            else
            {
                btnRut.Enabled = false;
            }
        }
    }
}
