using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Portfolio.Security.WebUI
{
    public class PortfolioIdentity : IIdentity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public PortfolioIdentity(IIdentity identity, IEnumerable<Claim> claims)
        {
            Id = Convert.ToInt32(claims.Single(i => i.Type == ClaimTypes.NameIdentifier).Value);
            Name = identity.Name;
            AuthenticationType = identity.AuthenticationType;
            IsAuthenticated = identity.IsAuthenticated;
            FirstName = claims.Single(i => i.Type == ClaimTypes.Name).Value;
            LastName = claims.Single(i => i.Type == ClaimTypes.Surname).Value;
            Email = claims.Single(i => i.Type == ClaimTypes.Email).Value;
        }
    }
}