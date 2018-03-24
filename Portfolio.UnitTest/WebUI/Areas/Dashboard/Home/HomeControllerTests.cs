using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portfolio.WebUI.Areas.Dashboard.Controllers.Home;
using Portfolio.Domain.Services;
using Moq;
using Microsoft.Owin.Security;
using Portfolio.UnitTest.Helpers;
using System.Web.Mvc;
using Portfolio.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using Portfolio.WebUI.Areas.Dashboard.Models.Home;
using Portfolio.UnitTest.Extensions;

namespace Portfolio.UnitTest.WebUI.Areas.Dashboard.Home
{
    [TestClass]
    public class HomeControllerTests
    {
        private readonly Mock<ISystemUserService> _mockSystemUserService;
        private readonly Mock<IAuthenticationManager> _mockAuthenticationManager;

        public HomeControllerTests()
        {
            _mockSystemUserService = new Mock<ISystemUserService>();
            _mockAuthenticationManager = new Mock<IAuthenticationManager>();
        }

        private HomeController GetHomeControllerInstance()
        {
            var controller = new HomeController(_mockSystemUserService.Object);
            controller.AuthenticationManager = _mockAuthenticationManager.Object;

            return controller;
        }

        [TestMethod]
        public void Authenticated_User_Returns_View()
        {
            //Arrange
            var controller = this.GetHomeControllerInstance();
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

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);

            var actionExecutedContext = MockingHelpers.InitActionExecutedContext(controller, result);
            controller.AccessOnActionExecuted(actionExecutedContext);

            var viewModel = (HomeViewModel)result.Model;
            Assert.IsNotNull(viewModel);
            Assert.IsNotNull(viewModel.CurrentUser);
        }
    }
}
