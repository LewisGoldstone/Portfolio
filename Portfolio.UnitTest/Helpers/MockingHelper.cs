using Moq;
using Portfolio.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Portfolio.UnitTest.Helpers
{
    public class MockingHelper
    {
        /// <summary>
        /// Mock http context/identity
        /// </summary>
        /// <param name="controller">Controller where extends PortfolioBaseController</param>
        /// <param name="systemUserId">System User ID</param>
        /// <param name="name">System User Name</param>
        /// <param name="email">System User Email</param>
        /// <param name="roles">System User Roles</param>
        public static void InitHttpContext<T>(T controller, int systemUserId, string name, string email, string[] roles)
            where T : PortfolioBaseController
        {
            var mockHttpContext = new Mock<System.Web.HttpContextBase>();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, systemUserId.ToString()),
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, email)
            };

            var genericIdentity = new GenericIdentity("");
            genericIdentity.AddClaims(claims);
            var genericPrincipal = new GenericPrincipal(genericIdentity, roles);

            mockHttpContext.SetupGet(x => x.User).Returns(genericPrincipal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(mockHttpContext.Object);

            controller.ControllerContext = controllerContext.Object;
        }
    }
}
