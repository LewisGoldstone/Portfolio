using Portfolio.Cryptography;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private ISystemUserService _systemUserService;

        public AuthenticationService(ISystemUserService systemUserService)
        {
            _systemUserService = systemUserService;
        }

        public SystemUser Verify(string email, string password)
        {
            var systemUser = _systemUserService.GetSystemUserByEmail(email);
            if (systemUser == null)
                return null;

            bool isValid = PasswordHasher.VerifyPassword(password, systemUser.Password);
            return isValid ? systemUser : null;
        }
    }
}
