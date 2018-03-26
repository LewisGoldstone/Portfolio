using Microsoft.Owin.Security;
using Moq;
using Portfolio.WebUI.Controllers;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Mvc;

namespace Portfolio.UnitTest.Extensions
{
    public static class ControllerExtensions
    {
        /// <summary>
        /// Mock http context/identity authentication
        /// </summary>
        /// <param name="controller">Controller where extends PortfolioBaseController</param>
        /// <param name="systemUserId">System User ID</param>
        /// <param name="firstName">System First Name</param>
        /// <param name="lastName">System Last Name</param>
        /// <param name="email">System User Email</param>
        /// <param name="roles">System User Roles</param>
        public static void InitAuthentication<TController>(this TController controller, int systemUserId, string firstName, string lastName, string email, string[] roles)
            where TController : PortfolioBaseController
        {   
            //Setup Identity and assign to Principal
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, systemUserId.ToString()),
                new Claim(ClaimTypes.Surname, lastName),
                new Claim(ClaimTypes.Email, email)
            };
            var genericIdentity = new GenericIdentity(firstName);
            genericIdentity.AddClaims(claims);
            var genericPrincipal = new GenericPrincipal(genericIdentity, roles);

            //Setup HTTP Context and assign to Controller Context
            var mockHttpContext = new Mock<System.Web.HttpContextBase>();
            mockHttpContext.SetupGet(x => x.User).Returns(genericPrincipal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(mockHttpContext.Object);

            //Assign Principal to Authentication Manager
            var mockAuthenticationManager = new Mock<IAuthenticationManager>();
            mockAuthenticationManager.Setup(i => i.User).Returns(genericPrincipal);

            //Assign Controller Context and Authentication Manager to controller
            controller.ControllerContext = controllerContext.Object;
            controller.AuthenticationManager = mockAuthenticationManager.Object;
        }
    }
}
