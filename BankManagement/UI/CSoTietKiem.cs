using BankManagement.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.UI
{
    public partial class CSoTietKiem : UserControl
    {
        SoTietKiemService stkService = new SoTietKiemService();
        public CSoTietKiem()
        {
            InitializeComponent();
            this.dtgvGuiTK.Size = new Size(Width, Height);

            dtgvGuiTK.AutoGenerateColumns = false;
            CustomDataGridView();

            HienThiDanhSach();
        }
        private void HienThiDanhSach()
        {
            this.dtgvGuiTK.DataSource = stkService.GetDSSoTietKiem();
        }

        private void CustomDataGridView()
        {
            DataGridViewTextBoxColumn maSTKColumn = new DataGridViewTextBoxColumn();
            maSTKColumn.DataPropertyName = "MaSTK";
            maSTKColumn.HeaderText = "Mã sổ tiết kiệm";
            dtgvGuiTK.Columns.Add(maSTKColumn);

            DataGridViewTextBoxColumn soSTKGui = new DataGridViewTextBoxColumn();
            soSTKGui.DataPropertyName = "SoTK";
            soSTKGui.HeaderText = "Số tài khoản chủ sổ";
            dtgvGuiTK.Columns.Add(soSTKGui);

            DataGridViewTextBoxColumn tenSoColumn = new DataGridViewTextBoxColumn();
            tenSoColumn.DataPropertyName = "TenSo";
            tenSoColumn.HeaderText = "Tên sổ";
            dtgvGuiTK.Columns.Add(tenSoColumn);

            DataGridViewTextBoxColumn ngayGuiColumn = new DataGridViewTextBoxColumn();
            ngayGuiColumn.DataPropertyName = "NgayGui";
            ngayGuiColumn.HeaderText = "Ngày gửi sổ";
            dtgvGuiTK.Columns.Add(ngayGuiColumn);

            DataGridViewTextBoxColumn ngayHanColumn = new DataGridViewTextBoxColumn();
            ngayHanColumn.DataPropertyName = "NgayHan";
            ngayHanColumn.HeaderText = "Ngày hạn đóng sổ";
            dtgvGuiTK.Columns.Add(ngayHanColumn);

            DataGridViewTextBoxColumn soTienColumn = new DataGridViewTextBoxColumn();
            soTienColumn.DataPropertyName = "SoTienGui";
            soTienColumn.HeaderText = "Số tiền gửi";
            dtgvGuiTK.Columns.Add(soTienColumn);

            DataGridViewTextBoxColumn tinhTrangColumn = new DataGridViewTextBoxColumn();
            tinhTrangColumn.DataPropertyName = "TinhTrang";
            tinhTrangColumn.HeaderText = "Tình trạng";
            dtgvGuiTK.Columns.Add(tinhTrangColumn);
        }

        private void dtgvGuiTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvGuiTK.Rows[e.RowIndex];

                int maSTK = int.Parse(row.Cells[0].Value.ToString());
                tbxMaSo.Texts = row.Cells[0].Value.ToString();
                tbxSTK.Texts = row.Cells[1].Value.ToString();
                tbxTenSo.Texts = row.Cells[2].Value.ToString();
                try
                {
                    dpNgayVay.Value = (DateTime)row.Cells[3].Value;
                    dpNgayHan.Value = (DateTime)row.Cells[4].Value;
                }
                catch
                {
                    dpNgayVay.Value = DateTime.Now;
                    dpNgayHan.Value = DateTime.Now;
                }
                tbxTien.Texts = row.Cells[5].Value.ToString();
                tbxTinhTrang.Texts = row.Cells[6].Value.ToString();

                if(stkService.CheckSoTietKiem(maSTK))
                {
                    SoTietKiem stk = stkService.GetSoTietKiem(maSTK);
                    if (stk.TinhTrang == 0)
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            FTietKiem tietKiem = new FTietKiem();
            tietKiem.ShowDialog();
        }

        private void btnTatToan_Click(object sender, EventArgs e)
        {
            int index = dtgvGuiTK.CurrentCell.RowIndex;
            int maSTK = int.Parse(dtgvGuiTK.Rows[index].Cells[0].Value.ToString());

            FTatToanSTK tatToanSTK = new FTatToanSTK(maSTK);
            tatToanSTK.ShowDialog();

            HienThiDanhSach();
            btnTatToan.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
