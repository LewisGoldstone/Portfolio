using Portfolio.Domain.Models;
using System.Collections.Generic;

namespace Portfolio.Domain.Services
{
    public interface IProjectService
    {
        /// <summary>
        /// Get ordered visible projects by set order then date created
        /// </summary>
        /// <param name="systemUserId">System User Identifier</param>
        /// <returns>List<Project></returns>
        List<Project> GetOrderedVisibleProjects(int systemUserId);
    }
}
