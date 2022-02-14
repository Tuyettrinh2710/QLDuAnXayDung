﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations;
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            this.DuAns = new HashSet<DuAn>();
        }

        [Display(Name = "Mã nhân viên")]
        public int MaNV { get; set; }

        [Display(Name = "Tên nhân viên")]
        public string TenNV { get; set; }

        [Display(Name = "Ngày sinh")]
        public Nullable<System.DateTime> NgaySinh { get; set; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [Display(Name = "Số CMND")]
        public string CMND { get; set; }

        [Display(Name = "Chức vụ")]
        public string ChucVu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DuAn> DuAns { get; set; }
    }
}
