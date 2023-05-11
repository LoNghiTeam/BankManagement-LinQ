using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.DAO
{
    internal class SoTietKiemDAO
    {
        internal bool CheckSoTietKiem(int maSTK)
        {
            using (var db = new BankModelContainer())
            {
                return db.SoTietKiems.Any(s => s.MaSTK == maSTK);
            }
        }

        internal SoTietKiem GetSoTietKiem(int maSTK)
        {
            using (var db = new BankModelContainer())
            {
                return db.SoTietKiems.FirstOrDefault(s => s.MaSTK == maSTK);
            }
        }
        internal List<SoTietKiem> GetDSSoTietKiem()
        {
            using (var db = new BankModelContainer())
            {
                if (logging.Taikhoan.IsAdmin == 1)
                    return db.SoTietKiems.Where(s => s.TinhTrang == 0).ToList();
                else
                    return db.SoTietKiems.Where(s => s.SoTK == logging.Taikhoan.SoTK && s.TinhTrang == 0).ToList();
            }
        }
    }
}
