using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portfolio.WebUI.Controllers;
using System.Web.Mvc;
using Moq;

namespace Portfolio.UnitTest.WebUI
{
    [TestClass]
    public class ProjectBaseControllerTests
    {
        public T InitControllerContext<T>(T controller, bool authenticate = false)
            where T : ProjectBaseController
        {
            var mock = new Mock<ControllerContext>();

            if (authenticate)
            {
                mock.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("Joe Bloggs");
                mock.SetupGet(x => x.HttpContext.Request.IsAuthenticated).Returns(true);
            }
            
            controller.ControllerContext = mock.Object;
            return controller;
        }
    }
}
