using System.ComponentModel.DataAnnotations;

namespace Portfolio.Domain.Models
{
    public class Media : PortfolioBase
    {
        [Display(Name = "File Name"), Required]
        public string FileName { get; set; }
        [Required]
        public string Directory { get; set; }
    }
}
