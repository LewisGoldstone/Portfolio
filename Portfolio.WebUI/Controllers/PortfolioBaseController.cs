using Microsoft.Owin;
using Microsoft.Owin.Security;
using Portfolio.Security.WebUI;
using Portfolio.WebUI.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class PortfolioBaseController : Controller
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

        private PortfolioIdentity _currentUser;
        public PortfolioIdentity CurrentUser
        {
            get
            {
                if(_currentUser == null && AuthenticationManager.User.Identity != null)
                {
                    return new PortfolioIdentity(AuthenticationManager.User.Identity, AuthenticationManager.User.Claims);
                }

                return _currentUser;
            }
            set
            {
                _currentUser = value;
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var result = filterContext.Result as ViewResultBase;

            if (result != null 
                && result.Model != null
                && result.Model.GetType().IsSubclassOf(typeof(PortfolioBaseViewModel)))
            {
                ((PortfolioBaseViewModel)result.Model).CurrentUser = CurrentUser;
            }

            base.OnActionExecuted(filterContext);
        }

        /// <summary>
        /// This is used for unit testing OnActionExecuted due to its innaccessibility
        /// </summary>
        /// <param name="filterContext">Action Executed Context</param>
        public void AccessOnActionExecuted(ActionExecutedContext filterContext)
        {
            OnActionExecuted(filterContext);
        }
    }
}