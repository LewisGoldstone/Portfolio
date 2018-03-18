using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Portfolio.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public LoginController() { }

        //
        // GET: /Login
        [AllowAnonymous]
        public ActionResult Index(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(object accountUser, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(accountUser);
            }

            return RedirectToAction("Index", "Dashboard");   
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}