using BankManagement.Enums;
using BankManagement.Service;
using System;
using System.Windows.Forms;

namespace BankManagement.UI
{
    public partial class FVayTienTinDung : Form
    {
        TaiKhoan taiKhoanVay = logging.Taikhoan;
        TaiKhoanService tkService = new TaiKhoanService();
        KhoanVayService kvService = new KhoanVayService();
        GiaoDichService gdService = new GiaoDichService();

        int thoiHan = 0;
        double laiSuat = 0;
        double tienVay = 0;
        double tienLai = 0;
        double tienDuocVay = 0;
        int diemTD = 0;
        public FVayTienTinDung()
        {
            InitializeComponent();
        }

        private void FVayTienTinDung_Load(object sender, EventArgs e)
        {
            lblLaiSuat.Text = string.Empty;
            lblTong.Text = string.Empty;
            tbSoTK.Texts = taiKhoanVay.SoTK.ToString();
            if (logging.Taikhoan.IsAdmin < 1)
            {
                tbSoTK.Enabled = false;
            }
            lblTen.Text = taiKhoanVay.HoVaTen;
            lblTienDuocVay.Text = tienDuocVay.ToString() + lblTienDuocVay.Tag;
        }

        private void tbSoTK__TextChanged(object sender, EventArgs e)
        {
            int soTK;
            Int32.TryParse(tbSoTK.Texts, out soTK);
            if (tkService.CheckSoTaiKhoan(soTK)) 
            {  
                taiKhoanVay = tkService.GetTaiKhoan(soTK);
                lblTen.Text = taiKhoanVay.HoVaTen;
                lblTienDuocVay.Text = tienDuocVay.ToString() + lblTienDuocVay.Tag;
            }
        }

        private void cbThoiGian_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Int32.TryParse(cbThoiGian.Texts, out thoiHan);
            if (thoiHan.ToString() != "" && Enum.IsDefined(typeof(ThoiHanTatToan), thoiHan))
            {
                laiSuat = kvService.TinhLaiSuatKhoanVay(thoiHan);
                lblLaiSuat.Text = laiSuat.ToString() + lblLaiSuat.Tag;
                tienLai = kvService.TinhTienLai(tienVay, thoiHan, laiSuat);
                lblTong.Text = (tienVay + tienLai).ToString();
            }
            else
            {
                MessageBox.Show("Thời hạn không hợp lệ so với chính sách ngân hàng!");
                cbThoiGian.Texts = "";
            }
        }

        private void tbTien__TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(tbTien.Texts, out tienVay))
            {
                if (tienVay <= tienDuocVay && tienVay > 0)
                {
                    tienLai = kvService.TinhTienLai(tienVay, thoiHan, laiSuat);
                    lblTong.Text = (tienVay + tienLai).ToString();
                }
            }
        }

        private void btnVayTien_Click(object sender, EventArgs e)
        {
            if (CheckKhoanVay())
            {
                KhoanVay kv = new KhoanVay
                {
                    SoTK = taiKhoanVay.SoTK,
                    NgayVay = DateTime.Now,
                    NgayHan = DateTime.Now.AddMonths(thoiHan),
                    ThoiGian = thoiHan,
                    SoTienVay = tienVay,
                    LaiSuat = laiSuat,
                    TinhTrang = 0,
                    LoaiKhoanVay = (int)LoaiGiaoDich.VayTinDung
                };
                gdService.TaoGiaoDichVayTD(kv);

                //Load lai tai khoan
                taiKhoanVay = tkService.GetTaiKhoan(taiKhoanVay.SoTK);
                lblTienDuocVay.Text = tienDuocVay.ToString() + lblTienDuocVay.Tag;
                if(logging.Taikhoan.SoTK == taiKhoanVay.SoTK)
                {
                    logging.Taikhoan = taiKhoanVay;
                }
            }
        }

        private Boolean CheckKhoanVay()
        {
            if (string.IsNullOrEmpty(tbSoTK.Texts))
            {
                MessageBox.Show("Số tài khoản không hợp lệ!");
                return false;
            }
            else
            {
                int soTK;
                if (Int32.TryParse(tbSoTK.Texts, out soTK))
                {
                    if (!tkService.CheckSoTaiKhoan(soTK))
                    {
                        MessageBox.Show("Số tài khoản không tồn tại!");
                        return false;
                    }
                    else
                    {
                        if (taiKhoanVay.DanhSachDen == 1)
                        {
                            MessageBox.Show("Tài khoản nằm trong danh sách đen, không thể cho vay!");
                            return false;
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(tbTien.Texts) || tienVay <=0 || tienVay > tienDuocVay)
            {
                MessageBox.Show("Số tiền muốn vay không hợp lệ (0<TienVay<TienDuocVay) !");
                return false;
            }
            if (!Enum.IsDefined(typeof(ThoiHanTatToan), thoiHan))
            {
                MessageBox.Show("Thời hạn không hợp lệ so với chính sách ngân hàng!");
                return false;
            }
            if (string.IsNullOrEmpty(lblLaiSuat.Text) || string.IsNullOrEmpty(lblTong.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return false;
            }    
            return true;
        }

        private void tbxDTD__TextChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(tbxDTD.Texts, out diemTD))
            {
                diemTD = 0;
            }
        }
    }
}
