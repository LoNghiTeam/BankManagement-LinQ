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
    
    public partial class SoTietKiem
    {
        public int MaSTK { get; set; }
        public int SoTK { get; set; }
        public string TenSo { get; set; }
        public System.DateTime NgayGui { get; set; }
        public System.DateTime NgayHan { get; set; }
        public double SoTienGui { get; set; }
        public double LaiSuat { get; set; }
        public int ThoiGian { get; set; }
        public int TinhTrang { get; set; }
        public Nullable<System.DateTime> NgayTatToan { get; set; }
    
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
