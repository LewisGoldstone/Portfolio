using Portfolio.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Areas.Dashboard.Controllers.Home
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
            return View();
        }
    }
}