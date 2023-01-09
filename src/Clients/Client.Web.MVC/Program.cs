using Client.Web.MVC.Configuration;
using Client.Web.MVC.Handlers;

namespace Client.Web.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var clientConfiguration = builder.Configuration
                .GetSection(nameof(ClientConfiguration))
                .Get<ClientConfiguration>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = clientConfiguration.Authority;

                options.ClientId = clientConfiguration.ClientId;
                options.ClientSecret = clientConfiguration.ClientSecret;
                options.ResponseType = clientConfiguration.OidcResponseType;

                options.SaveTokens = clientConfiguration.SaveTokens;
                options.Scope.Clear();
                foreach (var scope in clientConfiguration.Scopes)
                {
                    options.Scope.Add(scope);
                }

                options.GetClaimsFromUserInfoEndpoint = clientConfiguration.ClaimsFromUserInfoEndpoint;
            });


            builder.Services.AddTransient<AuthenticationDelegatingHandler>();
            builder.Services.AddHttpClient(name: "CatalogApiClient", options =>
            {
                options.BaseAddress = new Uri("https://localhost:44353");
                options.DefaultRequestHeaders.Clear();
                options.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddHttpMessageHandler<AuthenticationDelegatingHandler>();

            builder.Services.AddHttpClient(name: "HRApiClient", options =>
            {
                options.BaseAddress = new Uri("https://localhost:44354");
                options.DefaultRequestHeaders.Clear();
                options.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddHttpMessageHandler<AuthenticationDelegatingHandler>();

            builder.Services.AddHttpClient(name: "IDPClient", options =>
            {
                options.BaseAddress = new Uri("https://localhost:44310");
                options.DefaultRequestHeaders.Clear();
                options.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}