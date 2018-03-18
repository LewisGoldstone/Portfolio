using System.Collections.Generic;
using System.Linq;
using Portfolio.Domain.Repositories;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Service
{
    public class ProjectService : IProjectService
    {
        private IRepository<Project> _projectRepository;

        public ProjectService(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Project GetProject(int id)
        {
            return _projectRepository.GetById(id);
        }

        public List<Project> GetOrderedVisibleProjects(int systemUserId)
        {
            var projects = _projectRepository.Get(i => i.IsVisible);

            projects = projects.OrderBy(i => i.OrderBy == null)
                .ThenBy(i => i.OrderBy)
                .ThenBy(i => i.Created).ToList();

            return projects;
        }
    }
}
