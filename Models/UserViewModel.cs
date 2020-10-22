using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMobileShopping.Models
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string MailId { get; set; }
        public string Password { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public long MobileNo { get; set; }
        public bool IsAdmin { get; set; }
    }
}