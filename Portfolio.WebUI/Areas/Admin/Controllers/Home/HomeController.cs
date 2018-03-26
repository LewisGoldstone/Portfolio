using Portfolio.Domain.Services;
using Portfolio.WebUI.Areas.Admin.Models.Home;
using System.Web.Mvc;

namespace Portfolio.WebUI.Areas.Admin.Controllers
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