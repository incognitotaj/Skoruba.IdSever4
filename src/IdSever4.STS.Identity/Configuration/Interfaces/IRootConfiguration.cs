using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;

namespace IdSever4.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}







