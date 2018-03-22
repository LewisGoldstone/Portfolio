using Microsoft.Owin.Security;
using Portfolio.Domain.Security;
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

        private IPortfolioIdentity _currentUser;
        public IPortfolioIdentity CurrentUser
        {
            get
            {
                if(_currentUser == null && AuthenticationManager.User.Identity != null)
                {
                    var portfolioIdentity = (IPortfolioIdentity)AuthenticationManager.User.Identity;
                    portfolioIdentity.Id = Convert.ToInt32(AuthenticationManager.User.Claims.Single(i => i.ValueType == ClaimTypes.NameIdentifier).Value);
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
            var viewModel = filterContext.Controller.ViewData.Model;
            if (viewModel.GetType().IsSubclassOf(typeof(PortfolioBaseViewModel)))
            {
                ((PortfolioBaseViewModel)viewModel).CurrentUser = CurrentUser;
            }

            base.OnActionExecuted(filterContext);
        }
    }
}