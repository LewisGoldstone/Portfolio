using Portfolio.Security.WebUI;

namespace Portfolio.WebUI.Models
{
    public abstract class PortfolioBaseViewModel
    {
        public PortfolioIdentity CurrentUser { get; set; }
    }
}