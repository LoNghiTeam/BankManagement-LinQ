using BankManagement.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.UI
{
    public partial class CKhoanVay : UserControl
    {
        KhoanVayService kvService = new KhoanVayService();
        public CKhoanVay()
        {
            InitializeComponent();
            this.dtgvKhoanVay.Size = new Size(Width, Height);

            dtgvKhoanVay.AutoGenerateColumns = false;
            CustomDataGridView();

            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            using (var db = new BankModelContainer())
            {
                if (logging.Taikhoan.IsAdmin == 1)
                    this.dtgvKhoanVay.DataSource = db.KhoanVays.ToList();
                else
                    this.dtgvKhoanVay.DataSource = db.KhoanVays.Where(s => s.SoTK == logging.Taikhoan.SoTK).ToList();
            }
        }

        private void CustomDataGridView()
        {
            DataGridViewTextBoxColumn soKVColumn = new DataGridViewTextBoxColumn();
            soKVColumn.DataPropertyName = "SoKV";
            soKVColumn.HeaderText = "Mã số khoản vay";
            dtgvKhoanVay.Columns.Add(soKVColumn);

            DataGridViewTextBoxColumn soTKColumn = new DataGridViewTextBoxColumn();
            soTKColumn.DataPropertyName = "SoTK";
            soTKColumn.HeaderText = "Số tài khoản vay";
            dtgvKhoanVay.Columns.Add(soTKColumn);

            DataGridViewTextBoxColumn ngayVayColumn = new DataGridViewTextBoxColumn();
            ngayVayColumn.DataPropertyName = "NgayVay";
            ngayVayColumn.HeaderText = "Ngày vay";
            dtgvKhoanVay.Columns.Add(ngayVayColumn);

            DataGridViewTextBoxColumn ngayHanColumn = new DataGridViewTextBoxColumn();
            ngayHanColumn.DataPropertyName = "NgayHan";
            ngayHanColumn.HeaderText = "Ngày hạn trả nợ";
            dtgvKhoanVay.Columns.Add(ngayHanColumn);

            DataGridViewTextBoxColumn soTienColumn = new DataGridViewTextBoxColumn();
            soTienColumn.DataPropertyName = "SoTienVay";
            soTienColumn.HeaderText = "Số tiền vay";
            dtgvKhoanVay.Columns.Add(soTienColumn);

            DataGridViewTextBoxColumn tinhTrangColumn = new DataGridViewTextBoxColumn();
            tinhTrangColumn.DataPropertyName = "TinhTrang";
            tinhTrangColumn.HeaderText = "Tình trạng";
            dtgvKhoanVay.Columns.Add(tinhTrangColumn);

            DataGridViewTextBoxColumn loaiKVColumn = new DataGridViewTextBoxColumn();
            loaiKVColumn.DataPropertyName = "LoaiKhoanVay";
            loaiKVColumn.HeaderText = "Loại khoản vay";
            dtgvKhoanVay.Columns.Add(loaiKVColumn);
        }

        private void btnTatToan_Click(object sender, EventArgs e)
        {
            int index = dtgvKhoanVay.CurrentCell.RowIndex;
            int soKV = int.Parse(dtgvKhoanVay.Rows[index].Cells[0].Value.ToString());

            FTatToanKV tatToanKV = new FTatToanKV(soKV);
            tatToanKV.ShowDialog();

            HienThiDanhSach();
            btnTatToan.Visible = false;
        }

        private void dtgvKhoanVay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvKhoanVay.Rows[e.RowIndex];

                int soKV = int.Parse(row.Cells[0].Value.ToString());
                tbxSoKV.Texts = row.Cells[0].Value.ToString();
                tbxSoTK.Texts = row.Cells[1].Value.ToString();

                tbxNgVay.Texts = row.Cells[2].Value.ToString();
                tbxNgHan.Texts = row.Cells[3].Value.ToString();

                tbxTien.Texts = row.Cells[4].Value.ToString();
                tbxTinhTrang.Texts = row.Cells[5].Value.ToString();
                tbxLoai.Texts = row.Cells[6].Value.ToString();

                using (var db = new BankModelContainer())
                {
                    int tinhTrang = db.KhoanVays.Where(v => v.SoKV == soKV).Select(tk => tk.TinhTrang).FirstOrDefault();
                    if (tinhTrang == 0)
                    {
                        btnTatToan.Visible = true;
                    }
                    else
                    {
                        btnTatToan.Visible = false;
                    }
                }
            }
        }
    }
}
