using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineMobileShopping.Models
{
    public class EditUserPasswordViewModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string MailId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}