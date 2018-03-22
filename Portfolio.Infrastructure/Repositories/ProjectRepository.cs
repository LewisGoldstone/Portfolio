using Portfolio.Domain.Models;
using Portfolio.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Infrastructure.Repositories
{
    public class ProjectRepository :
        PortfolioBaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository()
        {
            this.dbSet = context.Set<Project>();
        }

        public List<Project> GetVisibleProjectsBySystemUser(int systemUserId)
        {
            return dbSet.Where(i => i.IsVisible 

                && i.SystemUserId == systemUserId

                && i.IsDeleted == false).ToList();
        }
    }
}
