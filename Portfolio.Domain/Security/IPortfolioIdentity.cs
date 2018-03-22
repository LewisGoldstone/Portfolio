using System.Security.Principal;

namespace Portfolio.Domain.Security
{
    public interface IPortfolioIdentity : IIdentity
    {
        int Id { get; set; }
    }
}
