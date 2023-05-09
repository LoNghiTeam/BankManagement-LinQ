using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankManagement.DAO
{
    internal class TaiKhoanDAO
    {
        public Boolean CheckSoTaiKhoan(int soTK)
        {
            using (var db = new BankModelContainer())
            {
                return db.TaiKhoans.Any(tk => tk.SoTK == soTK);
            }
        }
        public TaiKhoan GetTaiKhoan(int soTK)
        {
            using (var db = new BankModelContainer())
            {
                return db.TaiKhoans.FirstOrDefault(tk => tk.SoTK == soTK);
            } 
        }
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

        internal TaiKhoan GetTaiKhoanByTen(string tenTK)
        {
            using( var db = new BankModelContainer())
            {
                return db.TaiKhoans.FirstOrDefault(t => t.TenTK == tenTK);
            }
        }

        internal List<TaiKhoan> GetDSTaiKhoan()
        {
            using (var db = new BankModelContainer())
            {
                if (logging.Taikhoan.IsAdmin == 1)
                    return db.TaiKhoans.ToList();
                else
                    return db.TaiKhoans.Where(s => s.SoTK == logging.Taikhoan.SoTK).ToList();
            }
        }
    }
}
