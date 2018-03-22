using Portfolio.Domain.Services;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class HomeController : PortfolioBaseController
    {
        private readonly IProjectService _projectService;

        public HomeController (
            IProjectService projectService
            )
        {
            _projectService = projectService;
        }

        public ActionResult Index()
        {
            var projects = _projectService.GetOrderedVisibleProjects(1).Take(8);
            return View(projects);
        }
    }
}