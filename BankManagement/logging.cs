using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement
{
    public static class logging
    {
        private static TaiKhoan taikhoan;

        internal static TaiKhoan Taikhoan { get => taikhoan; set => taikhoan = value; }

    }
    
}
