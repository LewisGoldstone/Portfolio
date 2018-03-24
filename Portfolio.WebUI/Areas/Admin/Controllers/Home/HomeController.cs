using Portfolio.Domain.Services;
using Portfolio.WebUI.Areas.Admin.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Areas.Admin.Controllers.Home
{
    public class HomeController : AdminBaseController
    {
        private readonly ISystemUserService _systemUserService;

        public HomeController(ISystemUserService systemUserService)
        {
            _systemUserService = systemUserService;
        }

        public ActionResult Index()
        {
            var viewModel = new HomeViewModel();
            return View(viewModel);
        }
    }
}