using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineMobileShopping.Models
{
    public class EditMobileViewModel
    {
        [Required]
        public int MobileId { get; set; }
        [Required]
        public string MobileModel { get; set; }
        [Required]
        public string Processor { get; set; }
        [Required]
        public string RAM { get; set; }
        [Required]
        public string Storage { get; set; }
        [Required]
        public string DisplaySize { get; set; }
        [Required]
        public string Slimness { get; set; }
        [Required]
        public string Pixel { get; set; }
        [Required]
        public string BatteryCapacity { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int BrandId { get; set; }
        public virtual BrandViewModel Brand { get; set; }

    }
}