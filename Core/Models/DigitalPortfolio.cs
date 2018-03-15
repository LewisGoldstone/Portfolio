using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class DigitalPortfolio : PortfolioBase
    {
        public int SystemUserId { get; set; }
        public int ImageId { get; set; }
        [Display(Name = "Visibility")]
        public bool IsVisible { get; set; }
        [Display(Name = "Order By")]
        public int? OrderBy { get; set; }

        [ForeignKey("SystemUserId")]
        public virtual SystemUser SystemUser { get; set; }
        [ForeignKey("ImageId")]
        public virtual Media Image { get; set; }
    }
}
