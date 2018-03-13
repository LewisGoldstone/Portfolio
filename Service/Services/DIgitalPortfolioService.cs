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
        private IRepository<DigitalPortfolio> _dpRepo;

        public DigitalPortfolioService(IRepository<DigitalPortfolio> dpRepo)
        {
            _dpRepo = dpRepo;
        }

        public DigitalPortfolio GetDigitalPortfolio(int id)
        {
            return _dpRepo.GetById(id);
        }
    }
}
