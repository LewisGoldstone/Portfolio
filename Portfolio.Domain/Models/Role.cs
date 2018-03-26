using System.Collections.Generic;

namespace Portfolio.Domain.Models
{
    public class Role : PortfolioBase
    {
        public string Name { get; set; }

        public virtual ICollection<SystemUser> SystemUsers { get; set; }
    }
}
