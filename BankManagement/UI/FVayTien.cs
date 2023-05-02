using BankManagement.Controller;
using BankManagement.DAO;
using BankManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.UI
{
    public partial class FVayTien : Form
    {
        TaiKhoan taiKhoan = new TaiKhoan();
        VayTien vayTien = new VayTien();
        TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();    
        LaiSuatDAO laiSuatDAO = new LaiSuatDAO();
        int thoigian;
        double tien;
        LaiSuat laiSuat = new LaiSuat();
        TinhLai tinhLai = new TinhLai();
        ChuyenTien chuyenTien = new ChuyenTien();
        public FVayTien()
        {
            InitializeComponent();
        }


        private void FVayTien_Load(object sender, EventArgs e)
        {
            btnVayTien.Enabled = false;
            cbThoiGian.Items.Add("1 tháng");
            cbThoiGian.Items.Add("3 tháng");
            cbThoiGian.Items.Add("6 tháng");
            cbThoiGian.Items.Add("12 tháng");
            cbThoiGian.Items.Add("24 tháng");
            cbThoiGian.Items.Add("36 tháng");
            if(logging.Taikhoan.IsAdmin < 1)
            {
                tbSoTK.Enabled = false;
            }
            tbSoTK.Texts = logging.Taikhoan.SoTK.ToString();
            lblTen.Text = logging.Taikhoan.HoTen;
            lblTong.Text = string.Empty;
            lblLaiSuat.Text = string.Empty;

        }

        private void tbSoTK__TextChanged(object sender, EventArgs e)
        {
            int soTK = -1;
            int.TryParse(tbSoTK.Texts.Trim(), out soTK);

            btnVayTien.Enabled = false;
            taiKhoan = taiKhoanDAO.TimSoTK(soTK);
            if (taiKhoan != null)
            {
                if (lblTong.Text != "")
                {
                    btnVayTien.Enabled = true;
                }
                lblTen.Text = taiKhoan.HoTen;
                
            }
            else
            {
                lblTen.Text = string.Empty;
                btnVayTien.Enabled = false;
            }
        }

        private void tbTien__TextChanged(object sender, EventArgs e)
        {
            double lai;
            double.TryParse(tbTien.Texts.Trim(), out tien);
            
            if (cbThoiGian.Texts != "" && tien>0)
            {
                string laiSuat = lblLaiSuat.Text;
                laiSuat = laiSuat.Remove(laiSuat.IndexOf('%'));
                double.TryParse(laiSuat, out lai);
                vayTien.TinhlaichangeTbTien(cbThoiGian.Texts.ToString(), ref tien, ref lai);
                lblTong.Text = tien.ToString() + "VNĐ";
                btnVayTien.Enabled = true;
            }
            else {
                lblTong.Text = string.Empty;
                btnVayTien.Enabled = false; 
            }
        }

        private void cbThoiGian_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
            laiSuat = laiSuatDAO.find();
            double lai = 0;
            vayTien.TinhlaichangecbThoiGian(ref thoigian, cbThoiGian.Texts.ToString(), ref lai);
            lblLaiSuat.Text = lai.ToString() + "%";
            if (lblTong != null)
            {
                double.TryParse(tbTien.Texts.Trim(), out tien);
                tien += tinhLai.TinhTienLai(tien, lai / 100, thoigian);
                lblTong.Text = tien.ToString() + "VNĐ";
                btnVayTien.Enabled = true;
            }
        }

        private void btnVayTien_Click(object sender, EventArgs e)
        {
            int soTK = -1;
            int.TryParse(tbSoTK.Texts.Trim(), out soTK);
            if (vayTien.TaoKhoanVay(soTK, DateTime.Now, thoigian, tien, laiSuat.MaLS, 0, 1))
                if(chuyenTien.GiaoDichTienNhan(soTK, tien))
                    if(chuyenTien.TaoGiaoDich(-1, soTK, DateTime.Now, tien))
                        MessageBox.Show("Vay tiền thành công", "Thông báo", MessageBoxButtons.OK);

            if(soTK == logging.Taikhoan.SoTK)
            {
                logging.Taikhoan.Tien += tien;
            }
        }

    }
}
