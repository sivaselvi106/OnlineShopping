using OnlineMobileShopping.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.Web.Security;
using OnlineMobileShopping.Models;
using OnlineMobileShopping.Entity;

namespace OnlineMobileShopping.Controllers
{
    public class BrandController : Controller
    {
        IBrandBL brandBL;
        public BrandController()
        {
            brandBL = new BrandBL();
        }
        [HttpGet]
        public ActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBrand(AddNewBrandViewModel addNewBrandViewModel)
        {

            var config = new MapperConfiguration(mapping =>
            {
                mapping.CreateMap<AddNewBrandViewModel,Brand>().IgnoreAllNonExisting();
            });
            IMapper mapper = config.CreateMapper();
            Brand brand = mapper.Map<AddNewBrandViewModel, Brand>(addNewBrandViewModel);
            brandBL.Create(brand);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult EditBrand(int BrandId) //Edit                             
        {
            Brand brand = brandBL.GetBrandById(BrandId);
            return View(brand);
        }
        [HttpPost]
        public ActionResult UpdateBrand(EditBrandViewModel editBrandViewModel)
        {
            var config = new MapperConfiguration(mapping =>
            {
                mapping.CreateMap<EditBrandViewModel, Brand>().IgnoreAllNonExisting();
            });
            IMapper mapper = config.CreateMapper();
            Brand brand = mapper.Map<EditBrandViewModel, Brand>(editBrandViewModel);
            brandBL.UpdateBrand(brand);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DeleteBrand(int id)
        {
            brandBL.DeleteBrand(id);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult GetBrands()
        {
            IEnumerable<Brand> list = brandBL.GetBrands();
            var config = new MapperConfiguration(mapping =>
            {
                mapping.CreateMap<Brand, BrandViewModel>().IgnoreAllNonExisting();
            });
            IMapper mapper = config.CreateMapper();
            IEnumerable<BrandViewModel> brand = mapper.Map<IEnumerable<Brand>,IEnumerable<BrandViewModel>>(list);
            return View(brand);
        }
        //public ActionResult GetBrandById(int id)
        //{
        //    Brand brand = brandBL.GetBrandById(id);
        //    BrandViewModel brandViewModel = null;
        //    if (brand != null)
        //    {
        //        var config = new MapperConfiguration(mapping =>
        //        {
        //            mapping.CreateMap<Brand, BrandViewModel>().IgnoreAllNonExisting();
        //        });
        //        IMapper mapper = config.CreateMapper();
        //        brandViewModel = mapper.Map<Brand, BrandViewModel>(brand);
        //    }
        //    return View(brandViewModel);
        //}

    }
}