using System.Data.Entity;
using System.Collections.Generic;
using Portfolio.Domain.Repositories;
using Portfolio.Domain.Models;
using Portfolio.Cryptography;

namespace Portfolio.Infrastructure
{
    public class PortfolioInitialiser : DropCreateDatabaseIfModelChanges<PortfolioContext>
    {
        private readonly IRepository<SystemUser> _systemUserRepo;
        private readonly IRepository<Role> _roleRepo;

        public PortfolioInitialiser(IRepository<SystemUser> systemUserRepo, IRepository<Role> roleRepo)
        {
            _systemUserRepo = systemUserRepo;
            _roleRepo = roleRepo;
        }

        protected override void Seed(PortfolioContext context)
        {
            //Seed Roles
            var roles = new List<Role>
            {
                new Role
                {
                    Name = "Administrator"
                },
                new Role
                {
                    Name = "User"
                }
            };

            foreach (var role in roles)
            {
                _roleRepo.Insert(role);
            }

            _roleRepo.SaveChanges();

            //Seed System Users
            var systemUsers = new List<SystemUser>
            {
                new SystemUser
                {
                    FirstName = "Lewis",
                    LastName = "Goldstone",
                    Email = "lewispgoldstone@gmail.com",
                    Password = PasswordHasher.HashPassword("siweLGoldstone"),
                    Roles = new List<Role>()
                    {
                        roles[0]
                    }
                },
                new SystemUser
                {
                    FirstName = "Hannah",
                    LastName = "Hamlin",
                    Email = "hannahhamlin1@gmail.com",
                    Password = PasswordHasher.HashPassword("hannaHHamlin"),
                    Roles = new List<Role>()
                    {
                        roles[1]
                    }
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
