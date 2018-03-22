using Portfolio.Domain.Models;
using Portfolio.Domain.Repositories;

namespace Portfolio.Infrastructure.Repositories
{
    public class RoleRepository :
        PortfolioBaseRepository<Role>, IRoleRepository
    {
        public RoleRepository()
        {
            this.dbSet = context.Set<Role>();
        }
    }
}
