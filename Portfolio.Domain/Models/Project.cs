using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Domain.Models
{
    public partial class Project : PortfolioBase
    {
        public int SystemUserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Slug { get; set; }
        public string Description { get; set; }
        [Display(Name = "Visibility")]
        public bool IsVisible { get; set; }
        [Display(Name = "Order By")]
        public int? OrderBy { get; set; }
        [Display(Name = "Feature Image")]
        public int? FeatureImageId { get; set; }

        [ForeignKey("SystemUserId")]
        public virtual SystemUser SystemUser { get; set; }
        [ForeignKey("FeatureImageId")]
        public virtual Media FeatureImage { get; set; }
        public virtual ICollection<Media> Media { get; set; }
    }
}
