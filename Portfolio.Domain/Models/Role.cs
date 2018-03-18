using System.Collections.Generic;

namespace Portfolio.Domain.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<SystemUser> SystemUsers { get; set; }
    }
}
