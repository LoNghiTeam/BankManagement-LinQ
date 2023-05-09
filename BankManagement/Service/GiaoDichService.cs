using BankManagement.DAO;
using BankManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Service
{
    internal class GiaoDichService
    {
        GiaoDichDAO gdDAO = new GiaoDichDAO();

        internal List<GiaoDich> KetQuaTimKiem(string tbxMaGD, string tbxNgGui, string tbxNgNhan, Boolean dateCheck,
                                                DateTime date, string tbxTienGD, int loaiGD)
        {
            return gdDAO.KetQuaTimKiem( tbxMaGD,tbxNgGui,  tbxNgNhan, dateCheck,  date,  tbxTienGD, loaiGD);
        }
        internal Boolean CheckGiaoDich(int maGD)
        {
            return gdDAO.CheckGiaoDich(maGD);
        }
        internal GiaoDich GetGiaoDich(int maGD)
        {
            return gdDAO.GetGiaoDich(maGD);
        }

        internal List<GiaoDich> GetDSGiaoDich()
        {
            return gdDAO.GetDSGiaoDich();
        }

        internal void TaoGiaoDichGuiTietKiem(SoTietKiem stk)
        {
            gdDAO.TaoGiaoDichGuiTietKiem(stk);
        }

        internal void TaoGiaoDichVayTC(KhoanVay kv, string vatTheChap)
        {
            gdDAO.TaoGiaoDichVayTC(kv, vatTheChap);
        }

        internal void TaoGiaoDichVayTD(KhoanVay kv)
        {
            gdDAO.TaoGiaoDichVayTD(kv);
        }
        public void TaoGiaoDichThanhToanNoTheTD(int maTheTD, int soTK, double soTien)
        {
            gdDAO.TaoGiaoDichThanhToanNoTheTD(maTheTD, soTK, soTien);
        }
        public void TaoGiaoDichRutTienTheTD(int soTKRut, int maTheTD, double soTien)
        {
            gdDAO.TaoGiaoDichRutTienTheTD(soTKRut, maTheTD, soTien);    
        }
        public void TaoGiaoDichChuyenTienTheTD(int soTKChuyen, int soTKNhan, int maTheTD, double soTien)
        {
            gdDAO.TaoGiaoDichChuyenTienTheTD(soTKChuyen,soTKNhan,maTheTD, soTien);
        }
        public void TaoGiaoDichTatToanKV(KhoanVay kv, double soTien)
        {
            gdDAO.TaoGiaoDichTatToanKV(kv, soTien);
        }
        public void TaoGiaoDichTatToanSTK(SoTietKiem stk, double soTien)
        {
            gdDAO.TaoGiaoDichTatToanSTK(stk, soTien);
        }

        public void TaoGiaoDichChuyenTien(int soTKChuyen, int soTKNhan, double soTien)
        {
            gdDAO.TaoGiaoDichChuyenTien(soTKChuyen,soTKNhan, soTien);
        }

        public void TaoGiaoDichRut(int soTK, double soTien)
        {
            gdDAO.TaoGiaoDichRut(soTK, soTien); 
        }
        public void TaoGiaoDichNap(int soTK, double soTien)
        {
            gdDAO.TaoGiaoDichNap(soTK, soTien);
        }
    }
}
