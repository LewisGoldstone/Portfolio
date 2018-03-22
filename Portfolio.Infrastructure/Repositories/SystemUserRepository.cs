using Portfolio.Domain.Models;
using Portfolio.Domain.Repositories;
using System.Linq;

namespace Portfolio.Infrastructure.Repositories
{
    public class SystemUserRepository :
        PortfolioBaseRepository<SystemUser>, ISystemUserRepository
    {
        public SystemUserRepository()
        {
            this.dbSet = context.Set<SystemUser>();
        }

        public SystemUser GetSystemUserByEmail(string email)
        {
            return dbSet.SingleOrDefault(i => i.Email == email && i.IsDeleted == false);
        }
    }
}
