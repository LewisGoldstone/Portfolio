using Portfolio.Domain.Models;
using Portfolio.Domain.Repositories;

namespace Portfolio.Infrastructure.Repositories
{
    public class DigitalPortfolioRepository : 
        PortfolioBaseRepository<DigitalPortfolio>, IDigitalPortfolioRepository
    {
        public DigitalPortfolioRepository()
        {
            this.dbSet = context.Set<DigitalPortfolio>();
        }
    }
}
