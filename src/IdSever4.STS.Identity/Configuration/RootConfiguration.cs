using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;
using IdSever4.STS.Identity.Configuration.Interfaces;

namespace IdSever4.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}







