//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class TheTinDung
    {
        public int MaTTD { get; set; }
        public int SoTK { get; set; }
        public int DiemTD { get; set; }
        public double DaVay { get; set; }
        public int Khoa { get; set; }
    
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
