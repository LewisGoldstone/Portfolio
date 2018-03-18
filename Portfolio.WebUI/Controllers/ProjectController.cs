using System.Web.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        /*
        private IProjectRepository _projectRepository;

        public ProjectController()
        {
            this._projectRepository = new ProjectRepository(new PortfolioContext());
        }

        // GET: Project
        public ActionResult Index(string slug)
        {
            // Return list
            if (slug == null)
            {
                IEnumerable projects = _projectRepository.GetOrderedVisibleProjects().ToList();
                return View(projects);
            }

            ProjectViewModel vm = new ProjectViewModel();
            vm.Project = _projectRepository.GetProjectBySlug(slug);
            if (vm.Project == null)
            {
                return HttpNotFound();
            }

            vm.Prev = _projectRepository.GetProjectDesc(vm.Project.ID);
            vm.Next = _projectRepository.GetProjectAsc(vm.Project.ID);

            return View("view", vm);
        }

        protected override void Dispose(bool disposing)
        {
            _projectRepository.Dispose();
            base.Dispose(disposing);
        }*/
    }
}
