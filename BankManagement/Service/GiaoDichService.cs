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
        public void TaoGiaoDichThanhToanNoTheTD(int maTheTD,int soTK, double soTien)
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
                    NgayGD = DateTime.Now
                };
                if(taiKhoanThanhToan.SoDu < soTien)
                {
                    MessageBox.Show("Số dư không đủ để thanh toán nợ!");
                    return;
                }
                taiKhoanThanhToan.GiaoDiches.Add(newGD);
                taiKhoanThanhToan.SoDu -= soTien;
                theTD.SoDu += soTien;
                if(theTD.TrangThai != 0)
                {
                    theTD.TrangThai = 0;
                }

                taiKhoanNhan.SoDu += soTien;

                db.GiaoDiches.Add(newGD);

                db.SaveChanges();
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
                    NgayGD = DateTime.Now
                };
                taiKhoanNH.SoDu -= soTien;

                taiKhoanRut.GiaoDiches.Add(newGD);
                theTD.SoDu -= soTien;

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
                    NgayGD = DateTime.Now
                };
                taiKhoanNH.SoDu -= soTien;

                taiKhoanChuyen.GiaoDiches.Add(newGD);
                theTD.SoDu -= soTien;

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
                    MaNguoiGui = taiKhoanNhan.SoTK,
                    SoTienGD = soTien,
                    NgayGD = DateTime.Now
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
                    taiKhoanGui.DiemTinDung += (int)Math.Floor((double)stk.SoTienGui / 100000) + 1;
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
                    NgayGD = DateTime.Now
                };

                taiKhoanGui.GiaoDiches.Add(newGD);
                db.SoTietKiems.Add(stk);
                db.SaveChanges();
                MessageBox.Show("Gửi tiết kiệm thành công!");
            }
        }
        public void TaoGiaoDichChuyenTien(int soTKChuyen, int soTKNhan, double soTien)
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
                    NgayGD = DateTime.Now
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
                    NgayGD = DateTime.Now
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
                    NgayGD = DateTime.Now
                };

                taiKhoanNap.SoDu += soTien;
                taiKhoanNap.DiemTinDung += (int)Math.Floor((double)soTien / 1000000) + 1;
                taiKhoanNap.GiaoDiches.Add(newGDNap);

                db.GiaoDiches.Add(newGDNap);

                db.SaveChanges();
                MessageBox.Show("Nạp tiền thành công!");
            }
        }
    }
}
