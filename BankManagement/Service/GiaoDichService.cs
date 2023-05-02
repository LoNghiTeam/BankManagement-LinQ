using BankManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankManagement.Service
{
    internal class GiaoDichService
    {
        public void TaoGiaoDichVayTD(KhoanVay kv)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanNhan = db.TaiKhoans.FirstOrDefault(t => t.SoTK == kv.SoTK);
                TaiKhoan taiKhoanGui = db.TaiKhoans.FirstOrDefault(t => t.SoTK == 1);
                if (taiKhoanNhan != null)
                {
                    taiKhoanNhan.SoDu += kv.SoTienVay;
                    taiKhoanNhan.DiemTinDung -= (int)Math.Floor((double)kv.SoTienVay / 100000)+1;
                }
                else
                {
                    MessageBox.Show("Vay thất bại, vui lòng thử lại sau!");
                    return;
                }

                if (taiKhoanGui != null)
                {
                    taiKhoanGui.SoDu -= kv.SoTienVay ;
                }

                GiaoDich newGD = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.VayTinDung,
                    MaNguoiGui = 1,
                    MaNguoiNhan = taiKhoanNhan.SoTK,
                    SoTienGD = kv.SoTienVay,
                    NgayGD = DateTime.Now
                };

                taiKhoanNhan.GiaoDiches.Add(newGD);
                db.KhoanVays.Add(kv);
                db.SaveChanges();
                MessageBox.Show("Vay thành công!");
            }
        }
        public void TaoGiaoDichTatToanSTK(SoTietKiem stk, double soTien)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanGui = db.TaiKhoans.FirstOrDefault(t => t.SoTK == 1);
                TaiKhoan taiKhoanNhan = db.TaiKhoans.FirstOrDefault(t => t.SoTK == stk.SoTK);
                SoTietKiem ttSTK = db.SoTietKiems.FirstOrDefault(s => s.SoTK == stk.SoTK);
                var newGD = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.TatToanGiaoDich,
                    MaNguoiGui = 1,
                    MaNguoiNhan = taiKhoanNhan.SoTK,
                    SoTienGD = soTien,
                    NgayGD = DateTime.Now
                };

                if (taiKhoanGui != null)
                {
                    taiKhoanGui.SoDu -= soTien;
                }
                else
                {
                    return;
                }

                if (taiKhoanNhan != null)
                {
                    taiKhoanNhan.SoDu += soTien;
                    taiKhoanNhan.GiaoDiches.Add(newGD);
                }
                else
                {
                    return;
                }
                ttSTK.TinhTrang = 1;

                db.GiaoDiches.Add(newGD);
                db.SaveChanges();
                MessageBox.Show("Tất toán thành công");
            }
        }

        public void TaoGiaoDichGuiTietKiem(SoTietKiem stk)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanGui = db.TaiKhoans.FirstOrDefault(t => t.SoTK == stk.SoTK);
                TaiKhoan taiKhoanNhan = db.TaiKhoans.FirstOrDefault(t => t.SoTK == 1);
                if (taiKhoanGui != null)
                {
                    taiKhoanGui.SoDu -= stk.SoTienGui;
                    taiKhoanGui.DiemTinDung += 5;
                }
                else
                {
                    MessageBox.Show("Gửi thất bại, vui lòng thử lại sau!");
                    return;
                }

                if(taiKhoanNhan != null)
                {
                    taiKhoanNhan.SoDu += stk.SoTienGui;
                }

                GiaoDich newGD = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.GuiTietKiem,
                    MaNguoiGui = taiKhoanGui.SoTK,
                    MaNguoiNhan = 1,
                    SoTienGD = stk.SoTienGui,
                    NgayGD = DateTime.Now
                };

                taiKhoanGui.GiaoDiches.Add(newGD);
                db.SoTietKiems.Add(stk);
                db.SaveChanges();
                MessageBox.Show("Gửi tiết kiệm thành công!");
            }
        }
        public void TaoGiaoDichChuyenTien(TaiKhoan tkChuyen, TaiKhoan tkNhan, double soTien)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanChuyen = db.TaiKhoans.FirstOrDefault(t => t.SoTK == tkChuyen.SoTK);
                TaiKhoan taiKhoanNhan = db.TaiKhoans.FirstOrDefault(t => t.SoTK == tkNhan.SoTK);

                GiaoDich newGDChuyenTien = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.ChuyenKhoan,
                    MaNguoiGui = taiKhoanChuyen.SoTK,
                    MaNguoiNhan = taiKhoanNhan.SoTK,
                    SoTienGD = soTien,
                    NgayGD = DateTime.Now
                };

                taiKhoanChuyen.SoDu -= soTien;
                taiKhoanChuyen.DiemTinDung += 1;
                taiKhoanChuyen.GiaoDiches.Add(newGDChuyenTien);

                taiKhoanNhan.SoDu += soTien;
                taiKhoanNhan.GiaoDiches.Add(newGDChuyenTien);

                db.GiaoDiches.Add(newGDChuyenTien);

                db.SaveChanges();
                MessageBox.Show("Chuyển tiền thành công!");
            }
        }

        public void TaoGiaoDichRut(TaiKhoan tk, double soTien)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanRut = db.TaiKhoans.FirstOrDefault(t => t.SoTK == tk.SoTK);

                GiaoDich newGDRut = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.RutTien,
                    MaNguoiGui = taiKhoanRut.SoTK,
                    MaNguoiNhan = taiKhoanRut.SoTK,
                    SoTienGD = soTien,
                    NgayGD = DateTime.Now
                };

                taiKhoanRut.SoDu -= soTien;
                taiKhoanRut.GiaoDiches.Add(newGDRut);

                db.GiaoDiches.Add(newGDRut);

                db.SaveChanges();
                MessageBox.Show("Rút tiền thành công!");
            }
        }
        public void TaoGiaoDichNap(TaiKhoan tk, double soTien)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanNap = db.TaiKhoans.FirstOrDefault(t => t.SoTK == tk.SoTK);

                GiaoDich newGDNap = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.NapTien,
                    MaNguoiGui = taiKhoanNap.SoTK,
                    MaNguoiNhan = taiKhoanNap.SoTK,
                    SoTienGD = soTien,
                    NgayGD = DateTime.Now
                };

                taiKhoanNap.SoDu += soTien;
                taiKhoanNap.DiemTinDung += 2;
                taiKhoanNap.GiaoDiches.Add(newGDNap);

                db.GiaoDiches.Add(newGDNap);

                db.SaveChanges();
                MessageBox.Show("Nạp tiền thành công!");
            }
        }
    }
}
