using BankManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankManagement.Service
{
    internal class TheTinDungService
    {
        public double TinhTienLai(double tienNo, int days)
        {
            return tienNo*1/100*days;
        }
        public void MoTheTinDung(int soTK)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan tkTD = db.TaiKhoans.FirstOrDefault(t=>t.SoTK == soTK);
                if (tkTD != null)
                {
                    if (tkTD.TheTinDungs.Count >= 3)
                    {
                        MessageBox.Show("Không được tạo quá 3 thẻ tín dụng!");
                        return;
                    }
                    if(tkTD.DanhSachDen == 1)
                    {
                        MessageBox.Show("Tài khoản đang nằm trong danh sách đen, không thể tạo thẻ tín dụng mới!");
                        return;
                    }
                    TheTinDung newTheTD = new TheTinDung
                    {
                        SoTK = soTK,
                        TenChuThe = tkTD.HoVaTen,
                        SoDu = 3000000,
                        HanMuc = 3000000,
                        TrangThai = (int)TrangThai.DangHoatDong,
                        NgayMoThe = DateTime.Now,
                        NgayHan = DateTime.Now.AddMonths(3),
                        MaBaoMat = tkTD.MatKhau
                    };

                    tkTD.TheTinDungs.Add(newTheTD);

                    db.TheTinDungs.Add(newTheTD);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thẻ tín dụng thành công!");
                }
            }
        }
    }
}
