//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLDAXayDung.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VatTuTrongDuAn
    {
        public int MaVT { get; set; }
        public string MaDA { get; set; }
        public Nullable<int> SoLuong { get; set; }
    
        public virtual DuAn DuAn { get; set; }
        public virtual VatTu VatTu { get; set; }
    }
}
