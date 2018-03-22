using Portfolio.Domain.Models;
using Portfolio.Domain.Repositories;
using Portfolio.Domain.Services;

namespace Portfolio.Service
{
    public class DigitalPortfolioService : IDigitalPortfolioService
    {
        private IDigitalPortfolioRepository _dpRepository;

        public DigitalPortfolioService(IDigitalPortfolioRepository dpRepository)
        {
            _dpRepository = dpRepository;
        }
    }
}
