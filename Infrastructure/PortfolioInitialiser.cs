using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Common.Helpers;
using Core.Repositories;

namespace Infrastructure
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
                    Password = PasswordHasher.Hash("password"),
                    IsSuperUser = true
                },
                new SystemUser
                {
                    FirstName = "Hannah",
                    LastName = "Hamlin",
                    Email = "hannahhamlin1@gmail.com",
                    Password = PasswordHasher.Hash("password")
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
