using System.Security.Principal;

namespace Portfolio.WebUI.Models
{
    public abstract class PortfolioBaseViewModel
    {
        public IIdentity CurrentUser { get; set; }
    }
}