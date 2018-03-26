using Portfolio.Domain.Models;
using System.Data.Entity;

namespace Portfolio.Infrastructure
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext()
            : base("name=PortfolioConnection")
        {
            Database.SetInitializer(new PortfolioInitialiser());
        }

        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<DigitalPortfolio> DigitalPortfolios { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure System User Role many-to-many link table 
            modelBuilder.Entity<SystemUser>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.SystemUsers)
                .Map(m =>
                {
                    m.ToTable("SystemUserRole");
                    m.MapLeftKey("SystemUserId");
                    m.MapRightKey("RoleId");
                });
        }

        
    }
}
