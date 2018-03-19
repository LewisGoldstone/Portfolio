using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Portfolio.Domain.Services;
using Portfolio.WebUI.ViewModels.Login;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class LoginController : ProjectBaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // GET: /Login
        [AllowAnonymous]
        public ActionResult Index(string ReturnUrl)
        {
            var viewModel = new LoginViewModel(ReturnUrl);
            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel accountUser)
        {
            if (!ModelState.IsValid)
                return View(accountUser);

            var systemUser = _authenticationService.Verify(accountUser.Email, accountUser.Password);
            if (systemUser == null)
            {
                ModelState.AddModelError("", "Invalid email address or password");
                return View(accountUser);
            }

            var identity = new ClaimsIdentity
            (
                new[] 
                {
                    new Claim(ClaimTypes.Name, systemUser.FullName),
                    new Claim(ClaimTypes.Email, systemUser.Email)
                },
                DefaultAuthenticationTypes.ApplicationCookie,
                ClaimTypes.Name, 
                ClaimTypes.Role
            );

            // Set roles for authorization attributes used throughout dashboard
            foreach(var role in systemUser.Roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
            }

            AuthenticationManager.SignIn
            (
                new AuthenticationProperties
                {
                    IsPersistent = true
                }, 
                identity
            );

            if (accountUser.ReturnUrl == "/" || accountUser.ReturnUrl.Contains("Login"))
            {
                if(systemUser.Roles.Any(i => i.Name == "Administrator"))
                    return RedirectToAction("Index", "Home", new { area = "Admin", id = systemUser.Id });

                if (systemUser.Roles.Any(i => i.Name == "User"))
                    return RedirectToAction("Index", "Home", new { area = "Dashboard", id = systemUser.Id });
            }

            return Redirect(accountUser.ReturnUrl);
        }

        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}