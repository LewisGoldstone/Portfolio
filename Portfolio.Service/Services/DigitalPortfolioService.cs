using Portfolio.Domain.Models;
using Portfolio.Domain.Repositories;
using Portfolio.Domain.Services;

namespace Portfolio.Service
{
    public class DigitalPortfolioService : IDigitalPortfolioService
    {
        private IRepository<DigitalPortfolio> _dpRepository;

        public DigitalPortfolioService(IRepository<DigitalPortfolio> dpRepository)
        {
            _dpRepository = dpRepository;
        }

        public DigitalPortfolio GetDigitalPortfolio(int id)
        {
            return _dpRepository.GetById(id);
        }
    }
}
