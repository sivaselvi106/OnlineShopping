using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using OnlineMobileShopping.BL;
using OnlineMobileShopping.Entity;
using OnlineMobileShopping.Models;

namespace OnlineMobileShopping.Controllers
{
    public class AccountController : Controller
    {
        IAccountBL accountBL;

        public AccountController()
        {
            accountBL = new AccountBL();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SignUp(SignUpModel signUpModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(mapping =>
                    {
                        mapping.CreateMap<SignUpModel, Account>().IgnoreAllNonExisting();
                    });
                    IMapper mapper = config.CreateMapper();
                    var account = mapper.Map<SignUpModel, Account>(signUpModel);
                    account.IsAdmin = false;
                    accountBL.SignUp(account);
                    ViewBag.Message = "Successfully registered";
                    ModelState.Clear();
                    return RedirectToAction("Login");
                    // Account account = new Account();
                    // account.UserName = signUpModel.UserName;
                    //// account.UserId = signUpModel.UserId;
                    // account.MailId = signUpModel.MailId;
                    // account.Password = signUpModel.Password;
                    // account.MobileNo = signUpModel.MobileNo;
                    // account.CreateDate = DateTime.Now;
                    // account.UpdatedDate = DateTime.Now;
                    // account.LastLoginTime = DateTime.Now;
                    // account.Gender = signUpModel.Gender;
                    // account.Age = signUpModel.Age;
                    // account.City = signUpModel.City;
                }
            }
            catch
            {
                ModelState.AddModelError("", "Some error occurred");
                View("Error");
            }
            return View(signUpModel);
        }
        [HttpGet]
        //   [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
               var config = new MapperConfiguration(mapping =>
                    {
                        mapping.CreateMap<LoginModel, Account>().IgnoreAllNonExisting();
                    });
                    IMapper mapper = config.CreateMapper();
                    Account user = mapper.Map<LoginModel, Account>(loginModel);
                   Account result = accountBL.Login(user.MailId, user.Password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(user.MailId, false);
                var authTicket = new FormsAuthenticationTicket(1, user.MailId, DateTime.Now, DateTime.Now.AddMinutes(60), false,user.MailId);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login credentials");
                return View(user);
            }
        }
        public ActionResult EditUser(int UserId) //Edit                             
        {
            Account user = accountBL.GetUserById(UserId);
            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateUser(EditUserDetailViewModel editUserDetailViewModel)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(mapping =>
                {
                    mapping.CreateMap<EditUserDetailViewModel, Account>().IgnoreAllNonExisting();
                });
                IMapper mapper = config.CreateMapper();
                var account = mapper.Map<EditUserDetailViewModel, Account>(editUserDetailViewModel);
                //account.UserName = editUserDetailViewModel.UserName;
                //account.MobileNo = editUserDetailViewModel.MobileNo;
                //account.UpdatedDate = DateTime.Now;
                //account.Gender = editUserDetailViewModel.Gender;
                //account.Age = editUserDetailViewModel.Age;
                //account.City = editUserDetailViewModel.City;
                //account.MailId = editUserDetailViewModel.MailId;
                // account.CreateDate = DateTime.Now;
                //account.Password = editUserDetailViewModel.Password;
                // account.UserId = editUserDetailViewModel.UserId;
                // account.LastLoginTime = DateTime.Now;
                accountBL.EditUser(account);
                return RedirectToAction("UserDetails");
            }
            else
            {
                ModelState.AddModelError("", "Some error occurred");
                return View();
            }
        }
        public ActionResult UpdateUserPassword(int UserId) //Edit                             
        {
            Account user = accountBL.GetUserById(UserId);
            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateUserPassword(EditUserPasswordViewModel editUserPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(mapping =>
                {
                    mapping.CreateMap<EditUserDetailViewModel, Account>().IgnoreAllNonExisting();
                });
                IMapper mapper = config.CreateMapper();
                var account = mapper.Map<EditUserPasswordViewModel, Account>(editUserPasswordViewModel);
                accountBL.UpdateUserPassword(account);
                return RedirectToAction("UserDetails");
            }
            else
            {
                ModelState.AddModelError("", "some error occured");
                return View();
            }
        }
        public ActionResult DeleteUser(int id) //Delete
        {
            accountBL.DeleteUser(id);
            return RedirectToAction("UserDetails");
        }
        public ActionResult GetUsers()
        {
            IEnumerable<Account> list = accountBL.GetUsers();
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(mapping =>
                {
                    mapping.CreateMap<Account, UserViewModel>().IgnoreAllNonExisting();
                });
                IMapper mapper = config.CreateMapper();
                IEnumerable<UserViewModel> users = mapper.Map<IEnumerable<Account>, IEnumerable<UserViewModel>>(list);
                return View(users);
            }
            else
            {
                ModelState.AddModelError("", "some error occured");
                return View();
            }
        }
      public ActionResult GetUsersByMailId(UserViewModel userViewModel)
        {
            var config = new MapperConfiguration(mapping =>
            {
                mapping.CreateMap<UserViewModel, Account>().IgnoreAllNonExisting();
            });
            IMapper mapper = config.CreateMapper();
            Account user = mapper.Map<UserViewModel, Account>(userViewModel);
            Account result = accountBL.GetUserByEmail(user.MailId);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                ModelState.AddModelError("", "MailId not found");
                return View(user);
            }
        }
        public ActionResult GetUsersByUserId(UserViewModel userViewModel)
        {
            var config = new MapperConfiguration(mapping =>
            {
                mapping.CreateMap<UserViewModel, Account>().IgnoreAllNonExisting();
            });
            IMapper mapper = config.CreateMapper();
            Account user = mapper.Map<UserViewModel, Account>(userViewModel);
            Account result = accountBL.GetUserById(user.UserId);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                ModelState.AddModelError("", "UserId not found");
                return View(user);
            }
        }
    }
}