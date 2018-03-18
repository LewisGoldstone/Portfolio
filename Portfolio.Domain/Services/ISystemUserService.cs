using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface ISystemUserService
    {
        SystemUser GetSystemUser(int id);
    }
}
