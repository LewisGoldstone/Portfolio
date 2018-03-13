using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class PortfolioBase
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public DateTime Created { get; set; }

        public PortfolioBase()
        {
            IsDeleted = false;
            Created = DateTime.Now;
        }
    }
}
