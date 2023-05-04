using BankManagement.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BankManagement.Service
{
    internal class TaiKhoanService
    {
        public Boolean DoiMatKhau(string newMK)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoan = db.TaiKhoans.FirstOrDefault(tk => tk.SoTK == logging.Taikhoan.SoTK);
                if (taiKhoan != null)
                {
                    taiKhoan.MatKhau = newMK;
                }
                else
                {
                    return false;
                }
                db.SaveChanges();
            }
            return true;
        }
        public void ThemTKMoi(TaiKhoan tk)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanMoi = new TaiKhoan
                {
                    TenTK = tk.TenTK,
                    MatKhau = tk.MatKhau,
                    HoVaTen = tk.HoVaTen,
                    NgaySinh = tk.NgaySinh,
                    CCCD = tk.CCCD,
                    DiaChi = tk.DiaChi,
                    SDT = tk.SDT,
                    IsAdmin = 0,
                    SoDu = 0,
                    DiemTinDung = 100,
                    NgayMoTaiKhoan = DateTime.Now.ToString(),
                    DanhSachDen = 0
                };
                db.TaiKhoans.Add(taiKhoanMoi);
                db.SaveChanges();
            }
        }
        public void ChinhSuaTK(TaiKhoan tk)
        {
            using (var db = new BankModelContainer())
            {
                var query = from a in db.TaiKhoans
                            where a.SoTK == tk.SoTK
                            select a;

                var taiKhoan = query.FirstOrDefault();

                if (taiKhoan != null)
                {
                    taiKhoan.HoVaTen = tk.HoVaTen;
                    taiKhoan.NgaySinh = tk.NgaySinh;
                    taiKhoan.CCCD = tk.CCCD;
                    taiKhoan.DiaChi = tk.DiaChi;
                    taiKhoan.SDT = tk.SDT;
                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công");
                }
            }
        }
        //Kiểm tra xem tên tk và mật khẩu có đúng
        public bool CheckTenTKVaMK(string tenTk, string matKhau)
        {
            using (var db = new BankModelContainer())
            {
                var query = from a in db.TaiKhoans
                            where a.TenTK == tenTk && a.MatKhau == matKhau
                            select a;

                if (query.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //Kiểm tra xem tài khoản có hợp lệ, đầy đủ thông tin để đăng ký
        public bool CheckDangKyTaiKhoan(TaiKhoan tk, string rpMK)
        {
            if (tk.MatKhau != rpMK)
            {
                MessageBox.Show("Mật khẩu nhập lại chưa khớp với mật khẩu ban đầu!");
                return false;
            }
            if (CheckTenTaiKhoan(tk.TenTK))
            {
                MessageBox.Show("Tên tài khoản đã tồn tại, vui lòng nhập tên khác!");
                return false;
            }
            if (!IsValidPhone(tk.SDT))
            {
                MessageBox.Show("Số điện thoại không hợp lệ, vui lòng nhập lại!");
                return false;
            }
            if (CheckNull(tk, rpMK).Length > 15)
            {
                MessageBox.Show(CheckNull(tk, rpMK));
                return false;
            }
            return true;
        }
        public string CheckNull(TaiKhoan tk, string rpMK)
        {
            String result = "Ô đang bị trống: ";
            if (tk.TenTK.Length == 0 || tk.TenTK == "Tài khoản") result += "Tài khoản, ";
            if (tk.MatKhau.Length == 0 || tk.MatKhau == "Mật khẩu") result += "Mật khẩu, ";
            if (rpMK.Length == 0 || rpMK == "Nhập lại mật khẩu") result += "Nhập lại mật khẩu, ";
            if (tk.HoVaTen.Length == 0 || tk.HoVaTen == "Họ và tên") result += "Họ và tên , ";
            if (tk.CCCD.Length == 0 || tk.CCCD == "CCCD") result += "CCCD, ";
            if (tk.DiaChi.Length == 0 || tk.DiaChi == "Địa chỉ") result += "Địa chỉ, ";
            if (tk.SDT.Length == 0 || tk.SDT == "Số điện thoại") result += "Số điện thoại, ";
            return result = result.Substring(0, result.Length - 2);
        }
        public bool IsValidPhone(string sdt)
        {
            string pattern = @"^\d{10}$";
            return Regex.IsMatch(sdt, pattern);
        }
        //Kiểm tra xem tên tài khoản đã tồn tại hay chưa
        public bool CheckTenTaiKhoan(string tenTk)
        {
            using (var db = new BankModelContainer())
            {
                var query = from a in db.TaiKhoans
                            where a.TenTK == tenTk
                            select a;

                if (query.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
