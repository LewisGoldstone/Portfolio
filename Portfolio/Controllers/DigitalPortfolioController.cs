using Core.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class DigitalPortfolioController : Controller
    {
        private readonly IDigitalPortfolioService _digitalPortfolioService;

        public DigitalPortfolioController (
            IDigitalPortfolioService digitalPortfolioService
            )
        {
            _digitalPortfolioService = digitalPortfolioService;
        }

        // GET: DigitalPortfolio
        public ActionResult Index(int id)
        {
            var portfolio = _digitalPortfolioService.GetDigitalPortfolio(id);
            return View(portfolio);
        }
    }
}
