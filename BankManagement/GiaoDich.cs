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
    
    public partial class GiaoDich
    {
        public GiaoDich()
        {
            this.TaiKhoans = new HashSet<TaiKhoan>();
        }
    
        public int MaGD { get; set; }
        public int LoaiGD { get; set; }
        public int MaNguoiGui { get; set; }
        public int MaNguoiNhan { get; set; }
        public double SoTienGD { get; set; }
        public System.DateTime NgayGD { get; set; }
    
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
