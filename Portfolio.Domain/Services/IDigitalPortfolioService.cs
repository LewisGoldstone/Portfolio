﻿using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface IDigitalPortfolioService
    {
        DigitalPortfolio GetDigitalPortfolio(int id);
    }
}