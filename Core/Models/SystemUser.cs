using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public partial class SystemUser : PortfolioBase
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MinLength(6), DataType(DataType.Password)]
        public string Password { get; set; }
        public int? DisplayPictureId { get; set; }
        public bool IsSuperUser { get; set; }

        [ForeignKey("DisplayPictureId")]
        public virtual Media DisplayPicture { get; set; }

        public SystemUser()
        {
            IsSuperUser = false;
        }
    }
}
