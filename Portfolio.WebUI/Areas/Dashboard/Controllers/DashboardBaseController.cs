using Portfolio.WebUI.Controllers;
using System.Web.Mvc;

namespace Portfolio.WebUI.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "User")]
    public class DashboardBaseController : PortfolioBaseController
    {

    }
}