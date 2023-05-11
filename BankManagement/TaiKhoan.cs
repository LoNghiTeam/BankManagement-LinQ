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
    
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            this.GiaoDiches = new HashSet<GiaoDich>();
            this.KhoanVays = new HashSet<KhoanVay>();
            this.SoTietKiems = new HashSet<SoTietKiem>();
            this.TheTinDungs = new HashSet<TheTinDung>();
        }
    
        public int SoTK { get; set; }
        public string TenTK { get; set; }
        public string MatKhau { get; set; }
        public string HoVaTen { get; set; }
        public System.DateTime NgaySinh { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public int IsAdmin { get; set; }
        public double SoDu { get; set; }
        public string NgayMoTaiKhoan { get; set; }
        public int DanhSachDen { get; set; }
    
        public virtual ICollection<GiaoDich> GiaoDiches { get; set; }
        public virtual ICollection<KhoanVay> KhoanVays { get; set; }
        public virtual ICollection<SoTietKiem> SoTietKiems { get; set; }
        public virtual ICollection<TheTinDung> TheTinDungs { get; set; }
    }
}
