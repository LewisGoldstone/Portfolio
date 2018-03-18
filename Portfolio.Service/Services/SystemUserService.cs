using Portfolio.Domain.Repositories;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Service
{
    public class SystemUserService : ISystemUserService
    {
        private IRepository<SystemUser> _systemUserRepo;

        public SystemUserService(IRepository<SystemUser> systemUserRepo)
        {
            _systemUserRepo = systemUserRepo;
        }

        public SystemUser GetSystemUser(int id)
        {
            return _systemUserRepo.GetById(id);
        }
    }
}
