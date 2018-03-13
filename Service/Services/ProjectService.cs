using Core.Services;
using Core.Models;
using Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ProjectService : IProjectService
    {
        private IRepository<Project> _projectRepo;

        public ProjectService(IRepository<Project> projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public Project GetProject(int id)
        {
            return _projectRepo.GetById(id);
        }

        public List<Project> GetOrderedVisibleProjects(int systemUserId)
        {
            var orderedResults = _projectRepo.Get(i => 
                i.IsVisible 
                && i.OrderBy != null, 
                i => i.OrderBy(c => c.OrderBy));

            var dateOrdered = _projectRepo.Get(i => 
                i.IsVisible 
                && i.OrderBy == null, 
                i => i.OrderByDescending(c => c.Created));

            orderedResults.AddRange(dateOrdered);

            return orderedResults;
        }
    }
}
