using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Portfolio.Domain.Services;
using Portfolio.Service.Services;
using Portfolio.Domain.Models;
using Portfolio.Cryptography;

namespace Portfolio.UnitTest.Services
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        private readonly Mock<ISystemUserService> _mockSystemUserService;

        public AuthenticationServiceTests()
        {
            _mockSystemUserService = new Mock<ISystemUserService>();
        }

        [TestMethod]
        public void System_User_Does_Not_Exist_Fails_Verification()
        {
            // Arrange
            string email = "email@test.co.uk";
            string password = "passwordTest";

            _mockSystemUserService.Setup(m => m.GetSystemUserByEmail(email));

            // Act
            var result = new AuthenticationService(_mockSystemUserService.Object)
                .Verify(email, password);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void System_User_Exists_Password_Mismatch_Fails_Verification()
        {
            // Arrange
            string incorrectPassword = PasswordHasher.HashPassword("IncorrectPassword");
            var systemUser = new SystemUser
            {
                Id = 1,
                Email = "email@test.co.uk",
                Password = PasswordHasher.HashPassword("CorrectPassword")
            };

            _mockSystemUserService.Setup(m => m.GetSystemUserByEmail(systemUser.Email))
                .Returns(systemUser);

            // Act
            var result = new AuthenticationService(_mockSystemUserService.Object)
                .Verify(systemUser.Email, incorrectPassword);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void System_User_Exists_Password_Match_Verify_Success()
        {
            // Arrange
            string correctPassword = "CorrectPassword";
            int id = new Random().Next();
            var systemUser = new SystemUser
            {
                Id = id,
                Email = "email@test.co.uk",
                Password = PasswordHasher.HashPassword(correctPassword)
            };

            _mockSystemUserService.Setup(m => m.GetSystemUserByEmail(systemUser.Email))
                .Returns(systemUser);

            // Act
            var result = new AuthenticationService(_mockSystemUserService.Object)
                .Verify(systemUser.Email, correctPassword);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(id, systemUser.Id);
        }
    }
}
