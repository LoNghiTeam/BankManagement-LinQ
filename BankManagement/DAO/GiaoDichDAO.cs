using BankManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankManagement.DAO
{
    internal class GiaoDichDAO
    {
        public void ThayDoiTrangThaiGD(int maGD, int trangThai)
        {
            using (var db = new BankModelContainer())
            {
                GiaoDich giaoDich = db.GiaoDiches.FirstOrDefault(t => t.MaGD == maGD);
                if(giaoDich != null)
                {
                    giaoDich.TrangThaiGD = trangThai;
                }
                db.SaveChanges();
            }
        }
        public void TaoGiaoDichThanhToanNoTheTD(int maGD, int maTheTD,int soTK, double soTien)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanThanhToan = db.TaiKhoans.FirstOrDefault(t => t.SoTK == soTK);
                TaiKhoan taiKhoanNhan = db.TaiKhoans.FirstOrDefault(t => t.SoTK == 1);
                TheTinDung theTD = db.TheTinDungs.FirstOrDefault(t => t.MaTTD == maTheTD);

                GiaoDich newGD = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.ThanhToanNoTheTinDung,
                    MaNguoiGui = taiKhoanThanhToan.SoTK,
                    MaNguoiNhan = 1,
                    SoTienGD = soTien,
                    NgayGD = DateTime.Now,
                    NoiDungGD ="Thanh toán nợ thẻ tín dụng!",
                    TrangThaiGD = (int)TrangThaiGiaoDich.Da_xu_ly

                };
                if(taiKhoanThanhToan.SoDu < soTien)
                {
                    MessageBox.Show("Số dư không đủ để thanh toán nợ!");
                    return;
                }
                taiKhoanThanhToan.GiaoDiches.Add(newGD);
                taiKhoanThanhToan.SoDu -= soTien;
                theTD.SoDu += soTien;
                theTD.NgayHan = DateTime.Now.AddMonths(3);

                if(theTD.TrangThai != (int)TrangThai.DangHoatDong)
                {
                    theTD.TrangThai = (int)TrangThai.DangHoatDong;
                }

                taiKhoanNhan.SoDu += soTien;

                db.GiaoDiches.Add(newGD);

                db.SaveChanges();

                ThayDoiTrangThaiGD(maGD, (int)TrangThaiGiaoDich.Da_xu_ly);
                MessageBox.Show("Thanh toán nợ thành công!");
            }
        }
        public void TaoGiaoDichRutTienTheTD(int soTKRut, int maTheTD, double soTien)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanRut = db.TaiKhoans.FirstOrDefault(t => t.SoTK == soTKRut);
                TaiKhoan taiKhoanNH = db.TaiKhoans.FirstOrDefault(t => t.SoTK == 1);
                TheTinDung theTD = db.TheTinDungs.FirstOrDefault(t => t.MaTTD == maTheTD);

                GiaoDich newGD = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.RutTienTheTinDung,
                    MaNguoiGui = taiKhoanRut.SoTK,
                    MaNguoiNhan = taiKhoanRut.SoTK,
                    SoTienGD = soTien,
                    NgayGD = DateTime.Now,
                    NoiDungGD = "Rút tiền thẻ tín dụng!",
                    TrangThaiGD = (int)TrangThaiGiaoDich.Trong_qua_trinh_xu_ly
                };
                taiKhoanNH.SoDu -= soTien;

                taiKhoanRut.GiaoDiches.Add(newGD);
                theTD.SoDu -= soTien;
                if (theTD.SoDu <= 0)
                {
                    theTD.TrangThai = (int)TrangThai.BiKhoa;
                    db.SaveChanges();
                }

                db.GiaoDiches.Add(newGD);

                db.SaveChanges();
                MessageBox.Show("Rút tiền thành công!");
            }
        }
        public void TaoGiaoDichChuyenTienTheTD(int soTKChuyen, int soTKNhan,int maTheTD, double soTien)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanChuyen = db.TaiKhoans.FirstOrDefault(t => t.SoTK == soTKChuyen);
                TaiKhoan taiKhoanNhan = db.TaiKhoans.FirstOrDefault(t => t.SoTK == soTKNhan);
                TaiKhoan taiKhoanNH = db.TaiKhoans.FirstOrDefault(t => t.SoTK == 1);
                TheTinDung theTD = db.TheTinDungs.FirstOrDefault(t=>t.MaTTD == maTheTD);

                GiaoDich newGD = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.ChuyenTienTheTinDung,
                    MaNguoiGui = taiKhoanChuyen.SoTK,
                    MaNguoiNhan = taiKhoanNhan.SoTK,
                    SoTienGD = soTien,
                    NgayGD = DateTime.Now,
                    NoiDungGD = "Chuyển tiền thẻ tín dụng!",
                    TrangThaiGD = (int)TrangThaiGiaoDich.Trong_qua_trinh_xu_ly
                };
                taiKhoanNH.SoDu -= soTien;

                taiKhoanChuyen.GiaoDiches.Add(newGD);
                theTD.SoDu -= soTien;
                if (theTD.SoDu <= 0)
                {
                    theTD.TrangThai = (int)TrangThai.BiKhoa;
                    db.SaveChanges();
                }

                taiKhoanNhan.SoDu += soTien;
                taiKhoanNhan.GiaoDiches.Add(newGD);

                db.GiaoDiches.Add(newGD);

                db.SaveChanges();
                MessageBox.Show("Chuyển tiền thành công!");
            }
        }
        public void TaoGiaoDichTatToanKV(KhoanVay kv, double soTien)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanNhan = db.TaiKhoans.FirstOrDefault(t => t.SoTK == 1);
                TaiKhoan taiKhoanGui = db.TaiKhoans.FirstOrDefault(t => t.SoTK == kv.SoTK);
                KhoanVay ttKV = db.KhoanVays.FirstOrDefault(s => s.SoKV == kv.SoKV);
                
                var newGD = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.ThanhToanNo,
                    MaNguoiNhan= 1,
                    MaNguoiGui = taiKhoanGui.SoTK,
                    SoTienGD = soTien,
                    NgayGD = DateTime.Now,
                    NoiDungGD = "Tất toán khoản vay!",
                    TrangThaiGD = (int)TrangThaiGiaoDich.Da_xu_ly
                };

                if (taiKhoanGui != null)
                {
                    if(taiKhoanGui.SoDu >= soTien)
                    {
                        taiKhoanGui.SoDu -= soTien;
                        taiKhoanGui.GiaoDiches.Add(newGD);
                        if(kv.NgayHan.Date < DateTime.Now.Date)
                        {
                            taiKhoanGui.DanhSachDen = (int)TrangThai.BiKhoa;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số dư không đủ để trả nợ!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Giao dịch thất bại, vui lòng thử lại sau!");
                    return;
                }

                if (taiKhoanNhan != null)
                {
                    taiKhoanNhan.SoDu += soTien;
                }
                else
                {
                    MessageBox.Show("Giao dịch thất bại, vui lòng thử lại sau!");
                    return;
                }

                ttKV.TinhTrang = 1;
                ttKV.NgayTatToan = DateTime.Now;

                db.GiaoDiches.Add(newGD);
                db.SaveChanges();
                MessageBox.Show("Thanh toán nợ thành công");
            }
        }
        public void TaoGiaoDichVayTC(KhoanVay kv, string theChap)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanNhan = db.TaiKhoans.FirstOrDefault(t => t.SoTK == kv.SoTK);
                TaiKhoan taiKhoanGui = db.TaiKhoans.FirstOrDefault(t => t.SoTK == 1);
                if (taiKhoanNhan != null)
                {
                    taiKhoanNhan.SoDu += kv.SoTienVay;
                }
                else
                {
                    MessageBox.Show("Vay thất bại, vui lòng thử lại sau!");
                    return;
                }

                if (taiKhoanGui != null)
                {
                    taiKhoanGui.SoDu -= kv.SoTienVay;
                }
                else
                {
                    MessageBox.Show("Giao dịch thất bại, vui lòng thử lại sau!");
                    return;
                }

                GiaoDich newGD = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.VayTheChap,
                    MaNguoiGui = 1,
                    MaNguoiNhan = taiKhoanNhan.SoTK,
                    SoTienGD = kv.SoTienVay,
                    NgayGD = DateTime.Now,
                    NoiDungGD = "Vay thế chấp",
                    TrangThaiGD = (int)TrangThaiGiaoDich.Da_xu_ly
                };

                taiKhoanNhan.GiaoDiches.Add(newGD);
                db.KhoanVays.Add(kv);
                db.SaveChanges();
                MessageBox.Show("Vay thành công!");
            }
        }
        public void TaoGiaoDichVayTD(KhoanVay kv)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanNhan = db.TaiKhoans.FirstOrDefault(t => t.SoTK == kv.SoTK);
                TaiKhoan taiKhoanGui = db.TaiKhoans.FirstOrDefault(t => t.SoTK == 1);
                if (taiKhoanNhan != null)
                {
                    taiKhoanNhan.SoDu += kv.SoTienVay;
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
                    NgayGD = DateTime.Now,
                    NoiDungGD = "Vay tín dụng",
                    TrangThaiGD = (int)TrangThaiGiaoDich.Da_xu_ly
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
                SoTietKiem ttSTK = db.SoTietKiems.FirstOrDefault(s => s.MaSTK == stk.MaSTK);

                var newGD = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.TatToanGiaoDich,
                    MaNguoiGui = 1,
                    MaNguoiNhan = taiKhoanNhan.SoTK,
                    SoTienGD = soTien,
                    NgayGD = DateTime.Now,
                    NoiDungGD = "Tất toán sổ tiết kiệm",
                    TrangThaiGD = (int)TrangThaiGiaoDich.Da_xu_ly
                };

                if (taiKhoanGui != null)
                {
                    taiKhoanGui.SoDu -= soTien;
                }
                else
                {
                    MessageBox.Show("Giao dịch thất bại, vui lòng thử lại sau!");
                    return;
                }

                if (taiKhoanNhan != null)
                {
                    taiKhoanNhan.SoDu += soTien;
                    taiKhoanNhan.GiaoDiches.Add(newGD);
                }
                else
                {
                    MessageBox.Show("Giao dịch thất bại, vui lòng thử lại sau!");
                    return;
                }
                ttSTK.TinhTrang = 1;
                ttSTK.NgayTatToan = DateTime.Now;

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
                else
                {
                    MessageBox.Show("Giao dịch thất bại, vui lòng thử lại sau!");
                    return;
                }

                GiaoDich newGD = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.GuiTietKiem,
                    MaNguoiGui = taiKhoanGui.SoTK,
                    MaNguoiNhan = 1,
                    SoTienGD = stk.SoTienGui,
                    NgayGD = DateTime.Now,
                    NoiDungGD = "Gửi tiết kiệm tiền",
                    TrangThaiGD = (int)TrangThaiGiaoDich.Da_xu_ly
                };

                taiKhoanGui.GiaoDiches.Add(newGD);
                db.SoTietKiems.Add(stk);
                db.SaveChanges();
                MessageBox.Show("Gửi tiết kiệm thành công!");
            }
        }
        public void TaoGiaoDichChuyenTien(int soTKChuyen, int soTKNhan, double soTien, string noiDung)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanChuyen = db.TaiKhoans.FirstOrDefault(t => t.SoTK == soTKChuyen);
                TaiKhoan taiKhoanNhan = db.TaiKhoans.FirstOrDefault(t => t.SoTK == soTKNhan);

                GiaoDich newGDChuyenTien = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.ChuyenKhoan,
                    MaNguoiGui = taiKhoanChuyen.SoTK,
                    MaNguoiNhan = taiKhoanNhan.SoTK,
                    SoTienGD = soTien,
                    NgayGD = DateTime.Now,
                    NoiDungGD = noiDung,
                    TrangThaiGD = (int)TrangThaiGiaoDich.Da_xu_ly
                };

                taiKhoanChuyen.SoDu -= soTien;
                taiKhoanChuyen.GiaoDiches.Add(newGDChuyenTien);

                taiKhoanNhan.SoDu += soTien;
                taiKhoanNhan.GiaoDiches.Add(newGDChuyenTien);

                db.GiaoDiches.Add(newGDChuyenTien);

                db.SaveChanges();
                MessageBox.Show("Chuyển tiền thành công!");
            }
        }

        public void TaoGiaoDichRut(int soTK, double soTien)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanRut = db.TaiKhoans.FirstOrDefault(t => t.SoTK == soTK);

                GiaoDich newGDRut = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.RutTien,
                    MaNguoiGui = taiKhoanRut.SoTK,
                    MaNguoiNhan = taiKhoanRut.SoTK,
                    SoTienGD = soTien,
                    NgayGD = DateTime.Now,
                    NoiDungGD = "Rút tiền",
                    TrangThaiGD = (int)TrangThaiGiaoDich.Da_xu_ly
                };

                taiKhoanRut.SoDu -= soTien;
                taiKhoanRut.GiaoDiches.Add(newGDRut);

                db.GiaoDiches.Add(newGDRut);

                db.SaveChanges();
                MessageBox.Show("Rút tiền thành công!");
            }
        }
        public void TaoGiaoDichNap(int soTK, double soTien)
        {
            using (var db = new BankModelContainer())
            {
                TaiKhoan taiKhoanNap = db.TaiKhoans.FirstOrDefault(t => t.SoTK == soTK);

                GiaoDich newGDNap = new GiaoDich
                {
                    LoaiGD = (int)LoaiGiaoDich.NapTien,
                    MaNguoiGui = taiKhoanNap.SoTK,
                    MaNguoiNhan = taiKhoanNap.SoTK,
                    SoTienGD = soTien,
                    NgayGD = DateTime.Now,
                    NoiDungGD = "Nạp tiền",
                    TrangThaiGD = (int)TrangThaiGiaoDich.Da_xu_ly
                };

                taiKhoanNap.SoDu += soTien;
                taiKhoanNap.GiaoDiches.Add(newGDNap);

                db.GiaoDiches.Add(newGDNap);

                db.SaveChanges();
                MessageBox.Show("Nạp tiền thành công!");
            }
        }
        internal Boolean CheckGiaoDich(int maGD)
        {
            using (var db = new BankModelContainer())
            {
                return db.GiaoDiches.Any(g => g.MaGD == maGD);
            }
        }

        internal GiaoDich GetGiaoDich(int maGD)
        {
            using (var db = new BankModelContainer())
            {
                return db.GiaoDiches.FirstOrDefault(g => g.MaGD == maGD);
            }
        }

        internal List<GiaoDich> GetDSGiaoDich()
        {
            using (var db = new BankModelContainer())
            {
                if (logging.Taikhoan.IsAdmin == 1)
                {
                    return db.GiaoDiches.ToList();
                }
                else
                {
                    return db.GiaoDiches.Where(t => t.MaNguoiNhan == logging.Taikhoan.SoTK
                                                || t.MaNguoiGui == logging.Taikhoan.SoTK).ToList();
                }
            }
        }

        internal List<GiaoDich> KetQuaTimKiem(string tbxMaGD, string tbxNgGui, string tbxNgNhan,Boolean dateCheck,
                                                DateTime date, string tbxTienGD, int loaiGD)
        {
            using (var db = new BankModelContainer())
            {
                IQueryable<GiaoDich> listGD = db.GiaoDiches;

                if (!string.IsNullOrEmpty(tbxMaGD))
                {
                    int maGD;
                    if (Int32.TryParse(tbxMaGD, out maGD))
                    {
                        listGD = listGD.Where(l => l.MaGD == maGD);
                    }
                }
                if (!string.IsNullOrEmpty(tbxNgGui))
                {
                    int maNgGui;
                    if (Int32.TryParse(tbxNgGui, out maNgGui))
                    {
                        listGD = listGD.Where(l => l.MaNguoiGui == maNgGui);
                    }
                }
                if (!string.IsNullOrEmpty(tbxNgNhan))
                {
                    int maNgNhan;
                    if (Int32.TryParse(tbxNgNhan, out maNgNhan))
                    {
                        listGD = listGD.Where(l => l.MaNguoiNhan == maNgNhan);
                    }
                }
                if (dateCheck)
                {
                    listGD = listGD.Where(l => l.NgayGD.Year == date.Year
                                                && l.NgayGD.Month == date.Month
                                                && l.NgayGD.Day == date.Day);
                }
                if (!string.IsNullOrEmpty(tbxTienGD))
                {
                    double soTien;
                    if (Double.TryParse(tbxTienGD, out soTien))
                    {
                        listGD = listGD.Where(l => l.SoTienGD == soTien);
                    }
                }
                if (loaiGD != 0)
                {
                    listGD = listGD.Where(l => l.LoaiGD == loaiGD);
                }
                if (logging.Taikhoan.IsAdmin == 1)
                {
                    return listGD.ToList();
                }
                else
                {
                    return listGD.Where(t => t.MaNguoiNhan == logging.Taikhoan.SoTK
                                              || t.MaNguoiGui == logging.Taikhoan.SoTK).ToList();
                }
            }
        }
    }
}
