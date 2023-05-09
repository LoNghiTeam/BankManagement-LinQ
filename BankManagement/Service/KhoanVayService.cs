using BankManagement.DAO;
using BankManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Service
{
    internal class KhoanVayService
    {
        KhoanVayDAO kvDAO = new KhoanVayDAO();
        public double TinhTienLai(double tienVay, int thoiHan, double laiSuat)
        {
            double tienLai = tienVay;
            int i = 1;
            while (i <= thoiHan)
            {
                tienLai = tienLai + (tienLai * laiSuat / 12 / 100);
                i++;
            }
            tienLai = tienLai - tienVay;
            return Math.Round(tienLai, 2);
        }
        public double TinhLaiSuatKhoanVay(int thoiHan)
        {
            double laiSuat = 0;
            switch (thoiHan)
            {
                case (int)ThoiHanTatToan.Mot_Thang:
                    laiSuat = 0.013f * 12 * 100;
                    break;
                case (int)ThoiHanTatToan.Ba_Thang:
                    laiSuat = 0.012f * 12 * 100;
                    break;
                case (int)ThoiHanTatToan.Sau_Thang:
                    laiSuat = 0.011f * 12 * 100;
                    break;
                case (int)ThoiHanTatToan.Muoi_Hai_Thang:
                    laiSuat = 0.01f * 12 * 100;
                    break;
                case (int)ThoiHanTatToan.Hai_Muoi_Tu_Thang:
                    laiSuat = 0.009f * 12 * 100;
                    break;
                case (int)ThoiHanTatToan.Ba_Muoi_Sau_Thang:
                    laiSuat = 0.008f * 12 * 100;
                    break;
            }
            return Math.Round(laiSuat, 2);
        }

        public KhoanVay GetKhoanVay(int soKV)
        {
            return kvDAO.GetKhoanVay(soKV);
        }

        internal List<KhoanVay> GetDSKhoanVay()
        {
            return kvDAO.GetDSKhoanVay();
        }
    }
}
