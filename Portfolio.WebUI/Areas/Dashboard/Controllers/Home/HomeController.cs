using Portfolio.Domain.Services;
using Portfolio.WebUI.Areas.Dashboard.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Areas.Dashboard.Controllers
{
    public class HomeController : DashboardBaseController
    {
        private readonly ISystemUserService _systemUserService;

        public HomeController(ISystemUserService systemUserService)
        {
            _systemUserService = systemUserService;
        }

        // GET: Dashboard/Home
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel();
            return View(viewModel);
        }
    }
}