using Portfolio.Domain.Models;
using System.Collections.Generic;

namespace Portfolio.Domain.Services
{
    public interface IProjectService
    {
        Project GetProject(int id);
        List<Project> GetOrderedVisibleProjects(int systemUserId);
    }
}
