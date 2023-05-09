using BankManagement.DAO;
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
        TheTinDungDAO ttdDAO = new TheTinDungDAO();
        public double TinhTienLai(double tienNo, int days)
        {
            return tienNo*1/100*days;
        }
        public void MoTheTinDung(int soTK)
        {
            ttdDAO.MoTheTinDung(soTK);
        }

        public List<int> LoadDSTheTinDung(int soTK)
        {
            return ttdDAO.LoadDSTheTinDung(soTK);
        }

        public TheTinDung GetTheTinDung(int soTK)
        {
            return ttdDAO.GetTheTinDung(soTK);
        }

        public Boolean CheckTheTinDung(int maTTD)
        {
            return ttdDAO.CheckTheTinDung(maTTD);
        }
    }
}
