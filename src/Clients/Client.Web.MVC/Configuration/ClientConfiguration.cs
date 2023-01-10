namespace Client.Web.MVC.Configuration
{
    public class ClientConfiguration
    {
        public string Authority { get; set; }
        public bool SaveTokens { get; set; }
        public string OidcResponseType { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public string ClientRedirectUri { get; set; }
        public double CookieExpiresUtcHours { get; set; }

        public string TokenValidationClaimName { get; set; }
        public string TokenValidationClaimRole { get; set; }
        public double IdentityClientCookieExpiresUtcHours { get; set; }
        public bool ClaimsFromUserInfoEndpoint { get; set; }
        public string[] Scopes { get; set; }
    }
}
