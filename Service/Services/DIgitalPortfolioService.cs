using Core.Models;
using Core.Repositories;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
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
