using Portfolio.Domain.Repositories;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using System.Linq;

namespace Portfolio.Service
{
    public class SystemUserService : ISystemUserService
    {
        private ISystemUserRepository _systemUserRepo;

        public SystemUserService(ISystemUserRepository systemUserRepo)
        {
            _systemUserRepo = systemUserRepo;
        }

        public SystemUser GetSystemUserByEmail(string email)
        {
            return _systemUserRepo.GetSystemUserByEmail(email);
        }
    }
}
