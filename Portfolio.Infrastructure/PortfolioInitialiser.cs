using System.Data.Entity;
using System.Collections.Generic;
using Portfolio.Domain.Repositories;
using Portfolio.Domain.Models;

namespace Portfolio.Infrastructure
{
    public class PortfolioInitialiser : DropCreateDatabaseIfModelChanges<PortfolioContext>
    {
        private readonly IRepository<SystemUser> _systemUserRepo;

        public PortfolioInitialiser(IRepository<SystemUser> systemUserRepo)
        {
            _systemUserRepo = systemUserRepo;
        }

        protected override void Seed(PortfolioContext context)
        {
            //Seed System Users
            var systemUsers = new List<SystemUser>
            {
                new SystemUser
                {
                    FirstName = "Lewis",
                    LastName = "Goldstone",
                    Email = "lewispgoldstone@gmail.com",
                    Password = ""
                },
                new SystemUser
                {
                    FirstName = "Hannah",
                    LastName = "Hamlin",
                    Email = "hannahhamlin1@gmail.com",
                    Password = ""
                }
            };

            foreach(var systemUser in systemUsers)
            {
                _systemUserRepo.Insert(systemUser);
            }

            _systemUserRepo.SaveChanges();
        }
    }
}
