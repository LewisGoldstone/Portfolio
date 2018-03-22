using System.Collections.Generic;
using System.Linq;
using Portfolio.Domain.Repositories;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Service
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public List<Project> GetOrderedVisibleProjects(int systemUserId)
        {
            var projects = _projectRepository.GetVisibleProjectsBySystemUser(systemUserId);

            projects = projects.OrderBy(i => i.OrderBy == null)
                .ThenBy(i => i.OrderBy)
                .ThenBy(i => i.Created).ToList();

            return projects;
        }
    }
}
