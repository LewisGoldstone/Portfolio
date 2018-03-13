using Core.Models;

namespace Core.Services
{
    public interface ISystemUserService
    {
        SystemUser GetSystemUser(int id);
    }
}
