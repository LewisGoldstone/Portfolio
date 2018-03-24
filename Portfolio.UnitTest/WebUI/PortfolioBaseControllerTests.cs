using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portfolio.WebUI.Controllers;
using System.Web.Mvc;
using Moq;
using System.Security.Claims;
using System.Collections.Generic;
using System.Security.Principal;
using Portfolio.Domain.Models;
using System.Linq;
using Portfolio.UnitTest.Helpers;
using Portfolio.UnitTest.Extensions;

namespace Portfolio.UnitTest.WebUI
{
    [TestClass]
    public class PortfolioBaseControllerTests
    {
        private PortfolioBaseController GetPortfolioBaseControllerInstance()
        {
            var controller = new PortfolioBaseController();

            return controller;
        }

        [TestMethod]
        public void Authenticated_Administrator_Becomes_CurrentUser()
        {
            //Arrange
            var controller = this.GetPortfolioBaseControllerInstance();
            var systemUser = new SystemUser
            {
                Id = new Random().Next(),
                FirstName = "Joe",
                LastName = "Bloggs",
                Email = "test@email.co.uk",
                Roles = new List<Role>
                {
                    new Role
                    {
                        Name = "Administrator"
                    }
                }
            };
            string[] roles = systemUser.Roles.Select(i => i.Name).ToArray();

            controller.InitAuthentication(systemUser.Id, systemUser.FirstName, systemUser.LastName, systemUser.Email, roles);
            var currentUser = controller.CurrentUser;
            
            //Act
            Assert.IsNotNull(currentUser);
            Assert.AreEqual(currentUser.Id, systemUser.Id);
            Assert.AreEqual(currentUser.FirstName, systemUser.FirstName);
            Assert.AreEqual(currentUser.LastName, systemUser.LastName);
            Assert.AreEqual(currentUser.FullName, systemUser.FullName);
            Assert.IsTrue(controller.AuthenticationManager.User.IsInRole("Administrator"));
        }

        [TestMethod]
        public void Authenticated_User_Becomes_CurrentUser()
        {
            //Arrange
            var controller = this.GetPortfolioBaseControllerInstance();
            var systemUser = new SystemUser
            {
                Id = new Random().Next(),
                FirstName = "Joe",
                LastName = "Bloggs",
                Email = "test@email.co.uk",
                Roles = new List<Role>
                {
                    new Role
                    {
                        Name = "User"
                    }
                }
            };
            string[] roles = systemUser.Roles.Select(i => i.Name).ToArray();

            controller.InitAuthentication(systemUser.Id, systemUser.FirstName, systemUser.LastName, systemUser.Email, roles);
            var currentUser = controller.CurrentUser;

            //Act
            Assert.IsNotNull(currentUser);
            Assert.AreEqual(currentUser.Id, systemUser.Id);
            Assert.AreEqual(currentUser.FirstName, systemUser.FirstName);
            Assert.AreEqual(currentUser.LastName, systemUser.LastName);
            Assert.AreEqual(currentUser.FullName, systemUser.FullName);
            Assert.IsTrue(controller.AuthenticationManager.User.IsInRole("User"));
        }
    }
}
