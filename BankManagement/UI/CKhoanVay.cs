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
    public partial class CKhoanVay : UserControl
    {
        //KhoanVayDAO khoanVayDAO = new KhoanVayDAO();
        public CKhoanVay()
        {
            InitializeComponent();
            tbxLoai.Enabled = false;
            tbxMaLS.Enabled = false;
            tbxTien.Enabled = false;
            tbxTinhTrang.Enabled = false;
            dpNgayHan.Enabled = false;
            dpNgayVay.Enabled = false;
            //dtgvKhoanVay.DataSource = khoanVayDAO.FindAll();
            btnTatToan.Enabled = false;
        }

        private void tbxSoKV__TextChanged(object sender, EventArgs e)
        {
            btnTatToan.Enabled = false;

        }
        private void tbxSoTK__TextChanged(object sender, EventArgs e)
        {
            btnTatToan.Enabled = false;
            int soTK;
            int.TryParse(tbxSoTK.Texts, out soTK);
            //dtgvKhoanVay.DataSource = khoanVayDAO.FindSoTK(soTK);
        }
        private void dtgvKhoanVay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvKhoanVay.Rows[e.RowIndex];

                tbxSoKV.Texts = row.Cells[0].Value.ToString();
                tbxSoTK.Texts = row.Cells[1].Value.ToString();
                try
                {
                    dpNgayVay.Value = (DateTime)row.Cells[2].Value;
                    dpNgayHan.Value = (DateTime)row.Cells[3].Value;
                }
                catch
                {
                    dpNgayVay.Value = DateTime.Now;
                    dpNgayHan.Value = DateTime.Now;
                }
                tbxTien.Texts = row.Cells[4].Value.ToString();
                tbxMaLS.Texts = row.Cells[5].Value.ToString();
                tbxTinhTrang.Texts = row.Cells[6].Value.ToString();
                tbxLoai.Texts = row.Cells[7].Value.ToString();
            }
            if (tbxTinhTrang.Texts == "0")
            {
                btnTatToan.Enabled = true;
            }
            else
            {
                btnTatToan.Enabled = false;
            }
        }

        private void btnTatToan_Click(object sender, EventArgs e)
        {

        }

        //private void btnTatToan_Click(object sender, EventArgs e)
        //{
        //    int index = dtgvKhoanVay.CurrentCell.RowIndex;
        //    KhoanVay khoanVay = new KhoanVay(
        //            int.Parse(dtgvKhoanVay.Rows[index].Cells[0].Value.ToString()),
        //            int.Parse(dtgvKhoanVay.Rows[index].Cells[1].Value.ToString()),

        //            (DateTime)dtgvKhoanVay.Rows[index].Cells[2].Value,
        //            (DateTime)dtgvKhoanVay.Rows[index].Cells[3].Value,
        //            double.Parse(dtgvKhoanVay.Rows[index].Cells[4].Value.ToString()),
        //            int.Parse(dtgvKhoanVay.Rows[index].Cells[5].Value.ToString()),
        //            int.Parse(dtgvKhoanVay.Rows[index].Cells[6].Value.ToString()),
        //            int.Parse(dtgvKhoanVay.Rows[index].Cells[7].Value.ToString())
        //    );
        //    FTatToanKV tatToanKV = new FTatToanKV(khoanVay);
        //    tatToanKV.ShowDialog();
        //}
    }
}
