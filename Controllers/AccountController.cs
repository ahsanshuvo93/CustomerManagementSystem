using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerManagementSystem.Models;
using System.Web.Security;

namespace CustomerManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private DBCustomerManagementSystemEntities db = new DBCustomerManagementSystemEntities();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User _user)
        {
            bool _isvalid = db.User.Any(x => x.UserName == _user.UserName && x.Password == _user.Password);

            if (_isvalid)
            {
                FormsAuthentication.SetAuthCookie(_user.UserName, false);

                return RedirectToAction("Index","Clients");
            }

            ModelState.AddModelError("","Invalid username and password");
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User _user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(_user);
                db.SaveChanges();
            }

            return RedirectToAction("login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}