using BankManagement.Service;
using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BankManagement
{
    public partial class CTaiKhoan : UserControl
    {
        TaiKhoanService tkService = new TaiKhoanService();
        public CTaiKhoan()
        {
            InitializeComponent();
            this.dtgvBank.Size=new Size(Width,Height);
            // Khởi tạo DataGridView
            dtgvBank.AutoGenerateColumns = false;

            // Thêm cột cho DataGridView
            CustomDataGridView();

            //Hiển thị danh sách tài khoản
            HienThiDanhSach();
        }
        private void CustomDataGridView()
        {
            DataGridViewTextBoxColumn stkColumn = new DataGridViewTextBoxColumn();
            stkColumn.DataPropertyName = "SoTK";
            stkColumn.HeaderText = "Số tài khoản";
            dtgvBank.Columns.Add(stkColumn);

            DataGridViewTextBoxColumn tenColumn = new DataGridViewTextBoxColumn();
            tenColumn.DataPropertyName = "HoVaTen";
            tenColumn.HeaderText = "Họ và tên";
            dtgvBank.Columns.Add(tenColumn);

            DataGridViewTextBoxColumn ngaySinhColumn = new DataGridViewTextBoxColumn();
            ngaySinhColumn.DataPropertyName = "NgaySinh";
            ngaySinhColumn.HeaderText = "Ngày sinh";
            dtgvBank.Columns.Add(ngaySinhColumn);

            DataGridViewTextBoxColumn cccdColumn = new DataGridViewTextBoxColumn();
            cccdColumn.DataPropertyName = "CCCD";
            cccdColumn.HeaderText = "CCCD";
            dtgvBank.Columns.Add(cccdColumn);

            DataGridViewTextBoxColumn diaChiColumn = new DataGridViewTextBoxColumn();
            diaChiColumn.DataPropertyName = "DiaChi";
            diaChiColumn.HeaderText = "Địa chỉ";
            dtgvBank.Columns.Add(diaChiColumn);

            DataGridViewTextBoxColumn sdtColumn = new DataGridViewTextBoxColumn();
            sdtColumn.DataPropertyName = "SDT";
            sdtColumn.HeaderText = "Số điện thoại";
            dtgvBank.Columns.Add(sdtColumn);

            DataGridViewTextBoxColumn soDuColumn = new DataGridViewTextBoxColumn();
            soDuColumn.DataPropertyName = "SoDu";
            soDuColumn.HeaderText = "Số dư";
            dtgvBank.Columns.Add(soDuColumn);

            DataGridViewTextBoxColumn ngayMoColumn = new DataGridViewTextBoxColumn();
            ngayMoColumn.DataPropertyName = "NgayMoTaiKhoan";
            ngayMoColumn.HeaderText = "Ngày mở";
            dtgvBank.Columns.Add(ngayMoColumn);
        }
        private void HienThiDanhSach()
        {
            this.dtgvBank.DataSource = tkService.GetDSTaiKhoan();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan
            {
                SoTK = Int32.Parse(tbxSTK.Texts),
                HoVaTen = tbxName.Texts,
                NgaySinh = dpNgaySinh.Value,
                CCCD = tbxCCCD.Texts,
                DiaChi = tbxQueQuan.Texts,
                SDT = tbxSDT.Texts,
            };
            if (IsValid(tk))
            {
                tkService.ChinhSuaTK(tk);
            }

            HienThiDanhSach();
        }
        bool IsValid(TaiKhoan tk)
        {
            if (string.IsNullOrWhiteSpace(tk.HoVaTen) ||
                string.IsNullOrWhiteSpace(tk.NgaySinh.ToString()) ||
                string.IsNullOrWhiteSpace(tk.CCCD) ||
                string.IsNullOrWhiteSpace(tk.DiaChi) ||
                string.IsNullOrWhiteSpace(tk.SDT))
            {
                MessageBox.Show("Không được để trống!");
                return false;
            }

            if (!IsValidPhone(tk.SDT))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return false;
            }

            return true;
        }
        public bool IsValidPhone(string sdt)
        {
            string pattern = @"^\d{10}$";
            return Regex.IsMatch(sdt, pattern);
        }

        private void dtgvBank_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvBank.Rows[e.RowIndex];

                tbxSTK.Texts = row.Cells[0].Value.ToString();
                tbxName.Texts = row.Cells[1].Value.ToString();
                try
                {
                    dpNgaySinh.Value = (DateTime)row.Cells[2].Value;
                }
                catch
                {
                    dpNgaySinh.Value = DateTime.Now;
                }
                tbxCCCD.Texts = row.Cells[3].Value.ToString();
                tbxQueQuan.Texts = row.Cells[4].Value.ToString();
                tbxSDT.Texts = row.Cells[5].Value.ToString();
                tbxSoDu.Texts = row.Cells[6].Value.ToString();
                tbxNgayMo.Texts = row.Cells[7].Value.ToString();
            }

        }
    }
}
