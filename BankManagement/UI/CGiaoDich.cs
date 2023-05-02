using BankManagement.Service;
using BankManagement.UI;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BankManagement
{
    public partial class CGiaoDich : UserControl
    {
        GiaoDichService gdService = new GiaoDichService();
        List<GiaoDich> giaoDiches = new List<GiaoDich>();

        public CGiaoDich()
        {
            InitializeComponent();
            this.dtgvTrans.Size = new Size(Width, Height);

            dtgvTrans.AutoGenerateColumns = false;
            CustomDataGridView();

            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            using (var db = new BankModelContainer())
            {
                if(logging.Taikhoan.IsAdmin == 1)
                {
                    this.dtgvTrans.DataSource = db.GiaoDiches.ToList();
                }    
                else
                {
                    this.dtgvTrans.DataSource =
                        db.GiaoDiches.Where(t => t.MaNguoiNhan == logging.Taikhoan.SoTK
                                              || t.MaNguoiGui == logging.Taikhoan.SoTK).ToList();
                }
            }
        }

        private void CustomDataGridView()
        {
            DataGridViewTextBoxColumn maGDColumn = new DataGridViewTextBoxColumn();
            maGDColumn.DataPropertyName = "MaGD";
            maGDColumn.HeaderText = "Mã giao dịch";
            dtgvTrans.Columns.Add(maGDColumn);

            DataGridViewTextBoxColumn loaiGDColumn = new DataGridViewTextBoxColumn();
            loaiGDColumn.DataPropertyName = "LoaiGD";
            loaiGDColumn.HeaderText = "Mã loại giao dịch";
            dtgvTrans.Columns.Add(loaiGDColumn);

            DataGridViewTextBoxColumn maNgGuiColumn = new DataGridViewTextBoxColumn();
            maNgGuiColumn.DataPropertyName = "MaNguoiGui";
            maNgGuiColumn.HeaderText = "Mã người gửi";
            dtgvTrans.Columns.Add(maNgGuiColumn);

            DataGridViewTextBoxColumn maNgNhanColumn = new DataGridViewTextBoxColumn();
            maNgNhanColumn.DataPropertyName = "MaNguoiNhan";
            maNgNhanColumn.HeaderText = "Mã người nhận";
            dtgvTrans.Columns.Add(maNgNhanColumn);

            DataGridViewTextBoxColumn soTienColumn = new DataGridViewTextBoxColumn();
            soTienColumn.DataPropertyName = "SoTienGD";
            soTienColumn.HeaderText = "Số tiền giao dịch";
            dtgvTrans.Columns.Add(soTienColumn);

            DataGridViewTextBoxColumn ngayGDColumn = new DataGridViewTextBoxColumn();
            ngayGDColumn.DataPropertyName = "NgayGD";
            ngayGDColumn.HeaderText = "Ngày giao dịch";
            dtgvTrans.Columns.Add(ngayGDColumn);
        }

        private void CTrans_Load(object sender, EventArgs e)
        {
            cbbLoaiGD.SelectedIndex = 0;
            dpNgayGD.Value = DateTime.Now;
            cbDate.Checked = false;
        }

        private void dtgvTrans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvTrans.Rows[e.RowIndex];

                lbMaGD.Text = row.Cells[0].Value.ToString();

                flowLayoutPanel2.Enabled = true;
            }
            else
            {
                flowLayoutPanel2.Enabled = false;
            }
        }
        /*ReportDataSource rs = new ReportDataSource();*/
        private void btnPrintAllGD_Click(object sender, EventArgs e)
        {
            giaoDiches.Clear();
            for (int i = 0; i < dtgvTrans.Rows.Count - 1; i++)
            {
                int maGD;
                if (Int32.TryParse(dtgvTrans.Rows[i].Cells[0].Value.ToString(), out maGD))
                {
                    using (var db = new BankModelContainer())
                    {
                        GiaoDich gd = db.GiaoDiches.FirstOrDefault(g => g.MaGD == maGD);
                        if (gd != null)
                            giaoDiches.Add(gd);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi không xác định!");
                    return;
                }
            }
            FPrintGD print = new FPrintGD(giaoDiches);
            print.ShowDialog();
        }
        private void btnPrintGD_Click(object sender, EventArgs e)
        {
            giaoDiches.Clear();
            int maGD;
            if (Int32.TryParse(lbMaGD.Text, out maGD))
            {
                using (var db = new BankModelContainer())
                {
                    GiaoDich gd = db.GiaoDiches.FirstOrDefault(g => g.MaGD == maGD);
                    if (gd != null)
                        giaoDiches.Add(gd);
                    else 
                    {
                        MessageBox.Show("Lỗi không xác định!");
                        return;
                    }
                }
                FPrintGD print = new FPrintGD(giaoDiches);
                print.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mã giao dịch không hợp lệ!");
            }
        }

        private void btnDetailGD_Click(object sender, EventArgs e)
        {
            int index = dtgvTrans.CurrentCell.RowIndex;
            int maGD;
            if (Int32.TryParse(dtgvTrans.Rows[index].Cells[0].Value.ToString(),out maGD))
            {
                FChiTietGD chiTietGD = new FChiTietGD(maGD);
                chiTietGD.ShowDialog();
            }
            else
            {
                MessageBox.Show("Có gì đó không đúng, hãy kiểm tra lại mã giao dịch!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (var db = new BankModelContainer())
            {
                IQueryable<GiaoDich> listGD = db.GiaoDiches;

                if (!string.IsNullOrEmpty(tbxMaGD.Texts))
                {
                    int maGD;
                    if (Int32.TryParse(tbxMaGD.Texts, out maGD))
                    {
                        listGD = listGD.Where(l => l.MaGD == maGD);
                    }
                }
                if (!string.IsNullOrEmpty(tbxNgGui.Texts))
                {
                    int maNgGui;
                    if (Int32.TryParse(tbxNgGui.Texts, out maNgGui))
                    {
                        listGD = listGD.Where(l => l.MaNguoiGui == maNgGui);
                    }
                }
                if (!string.IsNullOrEmpty(tbxNgNhan.Texts))
                {
                    int maNgNhan;
                    if (Int32.TryParse(tbxNgNhan.Texts, out maNgNhan))
                    {
                        listGD = listGD.Where(l => l.MaNguoiNhan == maNgNhan);
                    }
                }
                if (cbDate.Checked)
                {
                    listGD = listGD.Where(l => l.NgayGD.Year == dpNgayGD.Value.Year
                                                && l.NgayGD.Month == dpNgayGD.Value.Month
                                                && l.NgayGD.Day == dpNgayGD.Value.Day);
                }
                if (!string.IsNullOrEmpty(tbxTienGD.Texts))
                {
                    double soTien;
                    if (Double.TryParse(tbxTienGD.Texts, out soTien))
                    {
                        listGD = listGD.Where(l => l.SoTienGD == soTien);
                    }
                }
                if(cbbLoaiGD.SelectedIndex != 0)
                {
                    listGD = listGD.Where(l => l.LoaiGD == cbbLoaiGD.SelectedIndex);
                }
                if(logging.Taikhoan.IsAdmin == 1)
                {
                    dtgvTrans.DataSource = listGD.ToList();
                }
                else
                {
                    dtgvTrans.DataSource = listGD.Where(t => t.MaNguoiNhan == logging.Taikhoan.SoTK
                                              || t.MaNguoiGui == logging.Taikhoan.SoTK).ToList();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxMaGD.Texts = "";
            tbxNgGui.Texts = "";
            tbxNgNhan.Texts = "";
            cbDate.Checked = false;
            tbxTienGD.Texts = "";
            cbbLoaiGD.SelectedIndex = 0;
            btnTimKiem_Click(sender,e);
        }

        private void dtgvTrans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
