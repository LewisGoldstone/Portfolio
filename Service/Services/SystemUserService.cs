using Core.Services;
using Core.Models;
using Core.Repositories;

namespace Service
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
