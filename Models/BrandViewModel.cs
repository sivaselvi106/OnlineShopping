using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineMobileShopping.Models
{
    public class BrandViewModel
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public virtual List<MobileViewModel> Mobiles { get; set; }
    }
}
