using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Media : PortfolioBase
    {
        [Display(Name = "File Name"), Required]
        public string FileName { get; set; }
        [Required]
        public string Directory { get; set; }
    }
}
