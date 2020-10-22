using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace OnlineMobileShopping.Models
{
    public class MobileViewModel
    {
        public int MobileId { get; set; }
        public string MobileModel { get; set; }
        public string Processor { get; set; } 
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string DisplaySize { get; set; }
        public string Slimness { get; set; }
        public string Pixel { get; set; }
        public string BatteryCapacity { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public int BrandId { get; set; }
    }
}