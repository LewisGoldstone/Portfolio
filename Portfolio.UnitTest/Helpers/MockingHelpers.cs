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
        /// <summary>
        /// Initialise Action Executed Contextn for Action Executed base controller method 
        /// </summary>
        /// <typeparam name="TController">Controller where extends PortfolioBaseController<typeparam>
        /// <param name="controller">Controller where extends PortfolioBaseController</param>
        /// <param name="result">Action Result from controller method being called</param>
        /// <returns>ActionExecutedContext</returns>
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
