using Portfolio.Domain.Security;

namespace Portfolio.WebUI
{
    public class PortfolioIdentity : IPortfolioIdentity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}