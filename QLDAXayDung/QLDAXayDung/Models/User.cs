using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QLDAXayDung.Models
{
    public class User
    {
        public string Id { get; set;}
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnable { get; set; }
        public string LockOutEndDateUtc { get; set; }
        public bool LockOutEnable { get; set; }
        public int AccessFailedCount { get; set; }
        [Display(Name ="Tên người dùng")]
        public string UserName { get; set; }


    }
}