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
    public partial class TienDoDA
    {
        [Display(Name = "Mã Tiến Độ")]
        public int MaTD { get; set; }

        [Display(Name = "Mã Dự Án")]
        public string MaDA { get; set; }

        [Display(Name = "Công Việc")]
        public string CongViec { get; set; }

        [Display(Name = "Ngày Bắt Đầu")]
        public Nullable<System.DateTime> NgayBatDau { get; set; }

        [Display(Name = "Ngày Kết Thúc")]
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
    
        public virtual DuAn DuAn { get; set; }
    }
}
