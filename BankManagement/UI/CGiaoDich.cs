using BankManagement.Service;
using BankManagement.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
            this.dtgvTrans.DataSource = gdService.GetDSGiaoDich();
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
                    if(gdService.CheckGiaoDich(maGD))
                    {
                        GiaoDich gd = gdService.GetGiaoDich(maGD);
                        giaoDiches.Add(gd);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi không xác định, có thể do giao dịch không tồn tại!");
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
                if (gdService.CheckGiaoDich(maGD))
                {
                    GiaoDich gd = gdService.GetGiaoDich(maGD);
                    giaoDiches.Add(gd);
                }
                else
                {
                    MessageBox.Show("Lỗi không xác định, có thể do giao dịch không tồn tại!");
                    return;
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
            dtgvTrans.DataSource = gdService.KetQuaTimKiem(tbxMaGD.Texts, tbxNgGui.Texts, tbxNgNhan.Texts,
                                                            cbDate.Checked, dpNgayGD.Value, tbxTienGD.Texts,
                                                            cbbLoaiGD.SelectedIndex);
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
