using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineMobileShopping.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string MailId { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}