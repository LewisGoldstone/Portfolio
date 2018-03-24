using Portfolio.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Portfolio.UnitTest.Helpers
{
    public static class MockingHelpers
    {
        public static ActionExecutedContext InitActionExecutedContext<TController>(TController controller, ActionResult result)
            where TController : PortfolioBaseController
        {
            var actionExecutedContext = new ActionExecutedContext();
            actionExecutedContext.Controller = controller;
            actionExecutedContext.HttpContext = controller.HttpContext;
            actionExecutedContext.Result = result;

            return actionExecutedContext;
        }
    }
}
