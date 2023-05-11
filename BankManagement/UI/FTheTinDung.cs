using BankManagement.Enums;
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
    public partial class FTheTinDung : Form
    {
        TheTinDungService theTDService = new TheTinDungService();
        TheTinDung theTD = new TheTinDung();
        TaiKhoan taiKhoan = logging.Taikhoan;
        TaiKhoanService tkService = new TaiKhoanService();
        public FTheTinDung()
        {
            InitializeComponent();
        }

        private void FTheTinDung_Load(object sender, EventArgs e)
        {
           if (logging.Taikhoan.IsAdmin != 1)
           {
                tbxSoTK.Enabled = false;
                btnMoThe.Visible = false;
           }
           lbTenChuThe.Text = taiKhoan.HoVaTen;
           tbxSoTK.Texts = taiKhoan.SoTK.ToString();
        }

        private void btnMoThe_Click(object sender, EventArgs e)
        {
            int soTK;
            if (Int32.TryParse(tbxSoTK.Texts, out soTK))
            {
                if (tkService.CheckSoTaiKhoan(soTK))
                {
                    theTDService.MoTheTinDung(soTK);
                    LoadTheTinDung();
                }
                else
                {
                    MessageBox.Show("Số tài khoản không hợp lệ!");
                    gbThongTinThe.Enabled = false;
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(theTD.SoDu  != theTD.HanMuc)
            {
                FThanhToanTTD fThanhToanTTD = new FThanhToanTTD(theTD, taiKhoan);
                fThanhToanTTD.ShowDialog();
                cbSoTheTD_OnSelectedIndexChanged(sender, e);

                taiKhoan = tkService.GetTaiKhoan(taiKhoan.SoTK);
                if(logging.Taikhoan.SoTK == taiKhoan.SoTK)
                {
                    logging.Taikhoan = taiKhoan;
                }
            }
            else
            {
                MessageBox.Show("Thẻ không có nợ để thanh toán!");
            }
        }
       
        
        private void btnRutTien_Click(object sender, EventArgs e)
        {
            if (taiKhoan.DanhSachDen == 1)
            {
                MessageBox.Show("Tài khoản của bạn đang bị khoá!");
                return;
            }
            if (theTD.TrangThai == 0 || theTD.NgayHan >= DateTime.Now)
            {
                FRutTienTTD fRutTienTTD = new FRutTienTTD(theTD, taiKhoan);
                fRutTienTTD.ShowDialog();
                cbSoTheTD_OnSelectedIndexChanged(sender, e);
            }
            else
            {
                MessageBox.Show("Thẻ của bạn đã hết hạn hoặc bị khoá! Vui lòng thanh toàn nợ (nếu có) để mở lại thẻ!");
            }
        }

        private void btnChuyenTien_Click(object sender, EventArgs e)
        {
            if (taiKhoan.DanhSachDen == 1)
            {
                MessageBox.Show("Tài khoản của bạn đang bị khoá!");
                return;
            }
            if (theTD.TrangThai == 0 || theTD.NgayHan >= DateTime.Now)
            {
                FChuyenTienTTD fChuyenTienTTD = new FChuyenTienTTD(theTD, taiKhoan);
                fChuyenTienTTD.ShowDialog();
                cbSoTheTD_OnSelectedIndexChanged(sender, e);
            }
            else
            {
                MessageBox.Show("Thẻ của bạn đã hết hạn hoặc bị khoá! Vui lòng thanh toàn nợ (nếu có) để mở lại thẻ!");
            }
        }

        private void tbxSoTK__TextChanged(object sender, EventArgs e)
        {
            int soTK;
            if (Int32.TryParse(tbxSoTK.Texts, out soTK))
            {
                if (tkService.CheckSoTaiKhoan(soTK))
                {
                    taiKhoan = tkService.GetTaiKhoan(soTK);
                    lbTenChuThe.Text = taiKhoan.HoVaTen;
                    LoadTheTinDung();
                }
                else
                {
                    gbThongTinThe.Enabled = false;
                }
            }
        }

        private void LoadTheTinDung()
        {
            gbThongTinThe.Enabled = true;
            cbSoTheTD.DataSource = theTDService.LoadDSTheTinDung(taiKhoan.SoTK);

            if (cbSoTheTD.Items.Count == 0)
            {
                cbSoTheTD.SelectedItem = "";
                lbSoDuThe.Text = "...";
                lbHanMuc.Text = "...";
                lbTrangThai.Text = "...";
                lbNgayHan.Text = "...";
                btnChuyenTien.Enabled = false;
                btnRutTien.Enabled = false;
                btnThanhToan.Enabled = false;
            }
        }

        private void cbSoTheTD_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int maTheTD;
            if (Int32.TryParse(cbSoTheTD.SelectedItem.ToString(), out maTheTD))
            {
                if (theTDService.CheckTheTinDung(maTheTD))
                {
                    theTD = theTDService.GetTheTinDung(maTheTD);

                    lbSoDuThe.Text = theTD.SoDu.ToString();
                    lbHanMuc.Text = theTD.HanMuc.ToString();
                    lbTrangThai.Text = Enum.GetName(typeof(TrangThai), theTD.TrangThai);
                    lbNgayHan.Text = theTD.NgayHan.ToString();

                    if (theTD.TrangThai != 0 || theTD.NgayHan < DateTime.Now)
                    {
                        btnChuyenTien.Enabled = false;
                        btnRutTien.Enabled = false;
                    }
                    else
                    {
                        btnChuyenTien.Enabled = true;
                        btnRutTien.Enabled = true;
                    }
                    btnThanhToan.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thẻ lỗi và không tồn tại!");
                }
            }
        }
    }

}
