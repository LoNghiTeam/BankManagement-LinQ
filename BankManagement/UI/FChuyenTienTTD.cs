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
    public partial class FChuyenTienTTD : Form
    {
        GiaoDichService gdService = new GiaoDichService();
        TheTinDung theTD;
        TaiKhoan taiKhoanChuyen;
        TaiKhoan taiKhoanNhan;
        double soTien = 0;
        public FChuyenTienTTD()
        {
            InitializeComponent();
        }

        public FChuyenTienTTD(TheTinDung ttd, TaiKhoan tkChuyen)
        {
            InitializeComponent();
            theTD = ttd;
            taiKhoanChuyen = tkChuyen;
        }

        private void FChuyenTienTTD_Load(object sender, EventArgs e)
        {
            lblSoTK.Text = theTD.SoTK.ToString();
            lblMaSoThe.Text = theTD.MaTTD.ToString();
            lblSoDu.Text = theTD.SoDu.ToString();
        }


        private void tbSoTKNhan__TextChanged(object sender, EventArgs e)
        {
            int soTKNhan;
            if(Int32.TryParse(tbSoTKNhan.Texts, out soTKNhan))
            {
                using (var db = new BankModelContainer())
                {
                    taiKhoanNhan = db.TaiKhoans.FirstOrDefault(t => t.SoTK == soTKNhan);
                    if (taiKhoanNhan != null)
                    {
                        lblTenNguoiNhan.Text = taiKhoanNhan.HoVaTen;
                    }
                }
            }
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (CheckChuyenTien())
            {
                gdService.TaoGiaoDichChuyenTienTheTD(taiKhoanChuyen.SoTK, taiKhoanNhan.SoTK, theTD.MaTTD, soTien);
                
                using (var db = new BankModelContainer())
                {
                    theTD = db.TheTinDungs.FirstOrDefault(t => t.SoTK == theTD.SoTK);
                    lblSoDu.Text = theTD.SoDu.ToString();
                }
            }
        }

        private Boolean CheckChuyenTien()
        {
            if(taiKhoanNhan == null)
            {
                MessageBox.Show("Tài khoản nhận không chính xác hoặc lỗi!");
                return false;
            }
            if(soTien <= 0 || soTien > theTD.SoDu)
            {
                MessageBox.Show("Số tiền chuyển không hợp lệ! (0 < số tiền =< số dư tín dụng)");
                return false;
            }
            if(taiKhoanChuyen.SoTK == taiKhoanNhan.SoTK)
            {
                MessageBox.Show("Không thể tự chuyển cho bản thân!");
                return false;
            }
            return true;
        }

        private void tbTienChuyen__TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(tbTienChuyen.Texts,out soTien))
            {
                soTien = 0;
            }
        }
    }
    
}
