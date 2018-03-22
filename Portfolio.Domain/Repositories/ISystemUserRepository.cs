using Portfolio.Domain.Models;

namespace Portfolio.Domain.Repositories
{
    public interface ISystemUserRepository : IRepository<SystemUser>
    {
        /// <summary>
        /// Get System User by Email
        /// </summary>
        /// <param name="email">Unique email address</param>
        /// <returns>System User</returns>
        SystemUser GetSystemUserByEmail(string email);
    }
}
