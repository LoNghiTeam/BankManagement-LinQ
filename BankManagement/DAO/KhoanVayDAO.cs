using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.DAO
{
    internal class KhoanVayDAO
    {
        public KhoanVay GetKhoanVay(int soKV)
        {
            using (var db = new BankModelContainer())
            {
                return db.KhoanVays.FirstOrDefault(v => v.SoKV == soKV);
            }
        }

        internal List<KhoanVay> GetDSKhoanVay()
        {
            using (var db = new BankModelContainer())
            {
                if (logging.Taikhoan.IsAdmin == 1)
                    return db.KhoanVays.ToList();
                else
                    return db.KhoanVays.Where(s => s.SoTK == logging.Taikhoan.SoTK).ToList();
            }
        }
    }
}
