using System.Collections.Generic;

namespace Portfolio.Domain.Models
{
    public class Role : PortfolioBase
    {
        public string Name { get; set; }

        public virtual IEnumerable<SystemUser> SystemUsers { get; set; }
    }
}
