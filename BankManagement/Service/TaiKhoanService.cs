using BankManagement.DAO;
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
        TaiKhoanDAO tkDAO = new TaiKhoanDAO();
        //Kiểm tra xem tài khoản có hợp lệ, đầy đủ thông tin để đăng ký
        public bool CheckDangKyTaiKhoan(TaiKhoan tk, string rpMK)
        {
            if (tk.MatKhau != rpMK)
            {
                MessageBox.Show("Mật khẩu nhập lại chưa khớp với mật khẩu ban đầu!");
                return false;
            }
            if (tkDAO.CheckTenTaiKhoan(tk.TenTK))
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

        internal bool CheckSoTaiKhoan(int soTK)
        {
            return tkDAO.CheckSoTaiKhoan(soTK);
        }

        internal bool CheckTenTKVaMK(string text1, string text2)
        {
            return tkDAO.CheckTenTKVaMK(text1,text2);
        }

        internal void ChinhSuaTK(TaiKhoan tk)
        {
            tkDAO.ChinhSuaTK(tk);
        }

        internal bool DoiMatKhau(string texts)
        {
            return tkDAO.DoiMatKhau(texts);
        }

        internal List<TaiKhoan> GetDSTaiKhoan()
        {
            return tkDAO.GetDSTaiKhoan();
        }

        internal TaiKhoan GetTaiKhoan(int soTK)
        {
            return tkDAO.GetTaiKhoan(soTK);
        }
        internal TaiKhoan GetTaiKhoanByTen(string tenTK)
        {
            return tkDAO.GetTaiKhoanByTen(tenTK);
        }

        internal void ThemTKMoi(TaiKhoan taiKhoan)
        {
            tkDAO.ThemTKMoi(taiKhoan);
        }
    }
}
