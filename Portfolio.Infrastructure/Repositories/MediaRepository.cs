using Portfolio.Domain.Models;
using Portfolio.Domain.Repositories;

namespace Portfolio.Infrastructure.Repositories
{
    public class MediaRepository :
        PortfolioBaseRepository<Media>, IMediaRepository
    {
        public MediaRepository()
        {
            this.dbSet = context.Set<Media>();
        }
    }
}
