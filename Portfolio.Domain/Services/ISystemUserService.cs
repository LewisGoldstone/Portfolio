using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface ISystemUserService
    {
        /// <summary>
        /// Get System User by Email
        /// </summary>
        /// <param name="email">Unique email address</param>
        /// <returns>System User</returns>
        SystemUser GetSystemUserByEmail(string email);
    }
}
