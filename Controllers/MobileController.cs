using OnlineMobileShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using OnlineMobileShopping.BL;
using OnlineMobileShopping.Entity;

namespace OnlineMobileShopping.Controllers
{
    public class MobileController : Controller
    {
        // GET: Mobile
        IMobileBL mobileBL;
        public MobileController()
        {
            mobileBL = new MobileBL();
        }
       public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AddNewMobileViewModel addNewMobileViewModel)
        {
            var config = new MapperConfiguration(mapping =>
            {
                mapping.CreateMap<AddNewMobileViewModel, Mobile>().IgnoreAllNonExisting();
            });
            IMapper mapper = config.CreateMapper();
            Mobile mobile = mapper.Map<AddNewMobileViewModel, Mobile>(addNewMobileViewModel);
            mobileBL.Create(mobile);
            return RedirectToAction("", "");
        }
        public ActionResult EditMobile(int mobileId)
        {
            Mobile mobile = mobileBL.GetMobileById(mobileId);
          return View(mobile);
        }
        public ActionResult UpdateMobile(EditMobileViewModel editMobileViewModel)
        {
            var config = new MapperConfiguration(mapping =>
            {
                mapping.CreateMap<EditMobileViewModel, Mobile>().IgnoreAllNonExisting();
            });
            IMapper mapper = config.CreateMapper();
            Mobile mobile = mapper.Map<EditMobileViewModel, Mobile>(editMobileViewModel);
            mobileBL.UpdateMobile(mobile);
            return RedirectToAction("");
        }
        public ActionResult GetMobiles()
        {
            IEnumerable<Mobile> list = mobileBL.GetMobiles();
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(mapping =>
                {
                    mapping.CreateMap<Mobile, MobileViewModel>().IgnoreAllNonExisting();
                });
                IMapper mapper = config.CreateMapper();
                IEnumerable<MobileViewModel> mobiles = mapper.Map<IEnumerable<Mobile>, IEnumerable<MobileViewModel>>(list);
                return View(mobiles);
            }
            else
            {
                ModelState.AddModelError("", "some error occured");
                return View();
            }
        }
        public ActionResult GetMobileByBrand(int brandId)
        {
            var config = new MapperConfiguration(mapping =>
            {
                mapping.CreateMap<MobileViewModel, Mobile>().IgnoreAllNonExisting();
            });
            IMapper mapper = config.CreateMapper();
            List<Mobile> list = mobileBL.GetMobileByBrand(brandId);
            List<MobileViewModel> mobiles = mapper.Map<List<Mobile>, List<MobileViewModel>>(list);
            if (mobiles != null)
            {
                return View(mobiles);
            }
            else
            {
                ModelState.AddModelError("", "Mobiles not found");
                return View(mobiles);
            }
        }
        public ActionResult DeleteMobile(int id)
        {
            mobileBL.DeleteMobile(id);
            return RedirectToAction("");
        }
    }
}
