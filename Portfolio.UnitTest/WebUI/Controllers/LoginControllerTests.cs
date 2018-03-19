using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portfolio.Domain.Services;
using Moq;
using Portfolio.WebUI.ViewModels.Login;
using Portfolio.WebUI.Controllers;
using Microsoft.Owin.Security;
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;

namespace Portfolio.UnitTest.WebUI.Controllers
{
    [TestClass]
    public class LoginControllerTests : ProjectBaseControllerTests
    {
        private readonly Mock<IAuthenticationManager> _mockAuthenticationManager;
        private readonly Mock<IAuthenticationService> _mockAuthenticationService;

        public LoginControllerTests()
        {
            _mockAuthenticationManager = new Mock<IAuthenticationManager>();
            _mockAuthenticationService = new Mock<IAuthenticationService>();
        }

        private LoginController GetLoginControllerInstance()
        {
            var controller = new LoginController(_mockAuthenticationService.Object);
            controller.AuthenticationManager = _mockAuthenticationManager.Object;

            return controller;
        }

        [TestMethod]
        public void Login_Validation_Fails_Before_Verification_Is_Called()
        {
            // Arrange
            var viewModel = new LoginViewModel("/");
            var controller = this.GetLoginControllerInstance();
            controller.ModelState.AddModelError("Email", "Email is required");
            controller.ModelState.AddModelError("Password", "Password is required");

            // Act
            var result = controller.Index(viewModel) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

            Assert.IsFalse(controller.ModelState.IsValid);
            _mockAuthenticationService.Verify(m => m.Verify(viewModel.Email, viewModel.Password), Times.Never);
            _mockAuthenticationManager.Verify(m => m.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity>()), Times.Never);
        }

        [TestMethod]
        public void Login_Unverified_System_User_Fails_Before_Signed_In()
        {
            // Arrange
            var viewModel = new LoginViewModel("/");
            var controller = this.GetLoginControllerInstance();
            _mockAuthenticationService.Setup(m => m.Verify(viewModel.Email, viewModel.Password));

            // Act
            var result = controller.Index(viewModel) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(controller.ModelState.IsValid);
            _mockAuthenticationService.Verify(m => m.Verify(viewModel.Email, viewModel.Password), Times.Once);
            _mockAuthenticationManager.Verify(m => m.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity>()), Times.Never);
        }

        [TestMethod]
        public void Login_Verified_Authenticates_System_User()
        {
            // Arrange
            string returnUrl = "/";
            var viewModel = new LoginViewModel(returnUrl)
            {
                Email = "email@test.co.uk",
                Password = "password-test"
            };
            var systemUser = new SystemUser()
            {
                Id = new Random().Next(),
                FirstName = "Joe",
                LastName = "Bloggs",
                Email = viewModel.Email,
                Password = viewModel.Password,
                Roles = new List<Role>()
            };

            var controller = this.GetLoginControllerInstance();
            _mockAuthenticationService.Setup(m => m.Verify(viewModel.Email, viewModel.Password))
                .Returns(systemUser);
            _mockAuthenticationManager.Setup(m => m.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity>()));

            // Act
            var result = controller.Index(viewModel) as RedirectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(controller.ModelState.IsValid);
            Assert.IsTrue(result.Url == returnUrl);
            _mockAuthenticationService.Verify(m => m.Verify(viewModel.Email, viewModel.Password), Times.Once);
            _mockAuthenticationManager.Verify(m => m.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity>()), Times.Once);
        }

        [TestMethod]
        public void Login_Verified_Redirects_Administrator()
        {
            // Arrange
            var viewModel = new LoginViewModel("/")
            {
                Email = "email@test.co.uk",
                Password = "password-test"
            };
            var systemUser = new SystemUser()
            {
                Id = new Random().Next(),
                FirstName = "Joe",
                LastName = "Bloggs",
                Email = viewModel.Email,
                Password = viewModel.Password,
                Roles = new List<Role>
                {
                    new Role
                    {
                        Name = "Administrator"
                    }
                }
            };

            var controller = this.GetLoginControllerInstance();
            _mockAuthenticationService.Setup(m => m.Verify(viewModel.Email, viewModel.Password))
                .Returns(systemUser);
            _mockAuthenticationManager.Setup(m => m.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity>()));

            // Act
            var result = controller.Index(viewModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.RouteValues.ContainsValue("Admin"));
            Assert.IsTrue(result.RouteValues.ContainsValue(systemUser.Id));
        }

        [TestMethod]
        public void Login_Verified_Redirects_User()
        {
            // Arrange
            var viewModel = new LoginViewModel("/Login")
            {
                Email = "email@test.co.uk",
                Password = "password-test"
            };
            var systemUser = new SystemUser()
            {
                Id = new Random().Next(),
                FirstName = "Joe",
                LastName = "Bloggs",
                Email = viewModel.Email,
                Password = viewModel.Password,
                Roles = new List<Role>
                {
                    new Role
                    {
                        Name = "User"
                    }
                }
            };

            var controller = this.GetLoginControllerInstance();
            _mockAuthenticationService.Setup(m => m.Verify(viewModel.Email, viewModel.Password))
                .Returns(systemUser);
            _mockAuthenticationManager.Setup(m => m.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity>()));

            // Act
            var result = controller.Index(viewModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.RouteValues.ContainsValue("Dashboard"));
            Assert.IsTrue(result.RouteValues.ContainsValue(systemUser.Id));
        }
    }
}
