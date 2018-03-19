using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}