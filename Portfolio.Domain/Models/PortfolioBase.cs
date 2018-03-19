using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Domain.Models
{
    public abstract class PortfolioBase
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }

        public PortfolioBase()
        {
            IsDeleted = false;
            Created = DateTime.Now;
        }
    }
}
