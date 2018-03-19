using System.Security.Principal;

namespace Portfolio.WebUI.ViewModels
{
    public abstract class BaseViewModel
    {
        public IIdentity CurrentUser { get; set; }
    }
}