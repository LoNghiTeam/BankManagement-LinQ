using BankManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankManagement.Service
{
    internal class SoTietKiemService
    {
        
        public double TinhTienLai(double tienGui, int thoiHan, double laiSuat)
        {
            double tienLai = tienGui;
            int i = 1;
            while (i <= thoiHan)
            {
                tienLai =  tienLai + (tienLai* laiSuat/12/100);
                i++;
            }
            tienLai = tienLai - tienGui;
            return Math.Round(tienLai, 2);
        }
        public double TinhLaiSuatTietKiem(int thoiHan)
        {
            double laiSuat = 0;
            switch (thoiHan)
            {
                case (int)ThoiHanTatToan.Mot_Thang:
                    laiSuat = 0.005f * 12 * 100;
                    break;
                case (int)ThoiHanTatToan.Ba_Thang:
                    laiSuat = 0.006f * 12 * 100;
                    break;
                case (int)ThoiHanTatToan.Sau_Thang:
                    laiSuat = 0.007f * 12 * 100;
                    break;
                case (int)ThoiHanTatToan.Muoi_Hai_Thang:
                    laiSuat = 0.008f * 12 * 100;
                    break;
                case (int)ThoiHanTatToan.Hai_Muoi_Tu_Thang:
                    laiSuat = 0.009f * 12 * 100;
                    break;
                case (int)ThoiHanTatToan.Ba_Muoi_Sau_Thang:
                    laiSuat = 0.01f * 12 * 100;
                    break;
            }
            return Math.Round(laiSuat, 2);
        }
    }
}
