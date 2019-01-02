
using Microsoft.AspNet.Identity;
using PRSipl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PRSipl.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PRSIndex()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PIndex(User user)
        {
            Database1Entities1 usersEntities = new Database1Entities1();
            User userdetail = usersEntities.Users.Where(m => m.User_Name == user.User_Name && m.Password == user.Password).FirstOrDefault();

            string message = string.Empty;
            if (userdetail == null)
            {
                message = "Incorrect Username or Password";
                ViewBag.Message = message;
                return View(user);
            }
            Session["Id"] = userdetail.Id;
            Session["username"] = userdetail.User_Name;
            message = "Congratulation";
            ViewBag.Message = message;

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(User user)
        {
            Database1Entities1 usersEntities = new Database1Entities1();
            User userdetail = usersEntities.Users.Where(m => m.User_Name == user.User_Name && m.Password == user.Password).FirstOrDefault();
            string message = string.Empty;
            if (userdetail == null)
            {
                message = "Incorrect Username or Password";
                ViewBag.Message = message;
                return View(user);
            }
            Session["Id"] = userdetail.Id;
            Session["username"] = userdetail.User_Name;
            message = "Congratulation";
            ViewBag.Message = message;

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}