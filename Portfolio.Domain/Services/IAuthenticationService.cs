using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Verifies login credentials
        /// </summary>
        /// <param name="email">Email address</param>
        /// <param name="password">Password in plain text</param>
        /// <returns>Authenticated system user</returns>
        SystemUser Verify(string email, string password);
    }
}
