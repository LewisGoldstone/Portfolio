using Core.Models;
using System.Data.Entity;

namespace Infrastructure
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext()
            : base("name=PortfolioConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<SystemUser> SystemUser { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<DigitalPortfolio> DigitalPortfolio { get; set; }
        public DbSet<Project> Project { get; set; }
    }
}
