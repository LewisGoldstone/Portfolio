﻿using Core.Services;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
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