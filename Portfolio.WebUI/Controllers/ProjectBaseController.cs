using Microsoft.Owin.Security;
using Portfolio.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class ProjectBaseController : Controller
    {
        private IAuthenticationManager _authenticationManager;
        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return _authenticationManager ?? HttpContext.GetOwinContext().Authentication;
            }
            set
            {
                _authenticationManager = value;
            }
        }

        private IIdentity _currentUser;
        public IIdentity CurrentUser
        {
            get
            {
                return _currentUser ?? AuthenticationManager.User.Identity;
            }
            set
            {
                _currentUser = value;
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewModel = filterContext.Controller.ViewData.Model;
            if (viewModel.GetType().IsSubclassOf(typeof(BaseViewModel)))
            {
                ((BaseViewModel)viewModel).CurrentUser = CurrentUser;
            }

            base.OnActionExecuted(filterContext);
        }
    }
}