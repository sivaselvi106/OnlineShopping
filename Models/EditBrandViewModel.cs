using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineMobileShopping.Models
{
    public class EditBrandViewModel
    {
        [Required]
        public int BrandId { get; set; }
        [Required]
        public string BrandName { get; set; }

    }
}