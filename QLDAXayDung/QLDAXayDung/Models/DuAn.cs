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
    
    public partial class DuAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DuAn()
        {
            this.NV_DA = new HashSet<NV_DA>();
            this.TienDoDAs = new HashSet<TienDoDA>();
            this.VatTuTrongDuAns = new HashSet<VatTuTrongDuAn>();
        }
    
        public int MaDA { get; set; }
        public byte[] Anh { get; set; }
        public string TenDA { get; set; }
        public string DiaDiem { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NV_DA> NV_DA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TienDoDA> TienDoDAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VatTuTrongDuAn> VatTuTrongDuAns { get; set; }
    }
}
