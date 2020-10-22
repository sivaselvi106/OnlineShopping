using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineMobileShopping.Models
{
    public class AddNewBrandViewModel
    {
        [Required]
        public string BrandName { get; set; }

    }
}