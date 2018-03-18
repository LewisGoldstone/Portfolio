using Portfolio.Domain.Models;
using System.Data.Entity;

namespace Portfolio.Infrastructure
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext()
            : base("name=PortfolioConnection")
        {}

        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<DigitalPortfolio> DigitalPortfolios { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
