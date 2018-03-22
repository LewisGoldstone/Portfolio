using Portfolio.Domain.Models;
using System.Collections.Generic;

namespace Portfolio.Domain.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        /// <summary>
        /// Get visible projects
        /// </summary>
        /// <param name="systemUserId">System User Identifier</param>
        /// <returns>List<Project></returns>
        List<Project> GetVisibleProjectsBySystemUser(int systemUserId);
    }
}
