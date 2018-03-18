using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Areas.Dashboard.Controllers
{
    public class DashboardBaseController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}