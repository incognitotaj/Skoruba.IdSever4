using Client.Web.MVC.Configuration;
using Client.Web.MVC.Handlers;
using Common.Core.Services;
using Common.Infrastructure.Servces;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

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

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(name: "user_read_policy",
                    policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        //policy.RequireClaim(claimType: "role", allowedValues: new[] { "admin", "manager" });
                    });


                //options.AddPolicy(name: "admin_policy",
                //    policy =>
                //    {
                //        policy.RequireAuthenticatedUser();
                //        policy.RequireClaim(claimType: "role", allowedValues: new[] { "admin" });
                //    });


                //options.AddPolicy(name: "manager_policy",
                //    policy =>
                //    {
                //        policy.RequireAuthenticatedUser();
                //        policy.RequireClaim(claimType: "role", allowedValues: new[] { "manager" });
                //    });


                options.AddPolicy(name: "admin_policy",
                    policy =>
                        policy.RequireAssertion(context => context.User.HasClaim(
                            c =>
                            {
                                return c.Type == JwtClaimTypes.Role && c.Value.Contains("admin");
                            })
                        ));

                //options.AddPolicy(name: "write_policy",
                //    policy =>
                //        policy.RequireAssertion(context => context.User.HasClaim(
                //            c =>
                //            {
                //                return c.Type == JwtClaimTypes.Role && c.Value.Contains("admin");
                //            })
                //        ));
            });

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

                options.ClaimActions.MapUniqueJsonKey(
                    clientConfiguration.TokenValidationClaimRole,
                    clientConfiguration.TokenValidationClaimRole,
                    clientConfiguration.TokenValidationClaimRole);

                options.GetClaimsFromUserInfoEndpoint = clientConfiguration.ClaimsFromUserInfoEndpoint;

                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    NameClaimType = clientConfiguration.TokenValidationClaimName,
                    RoleClaimType = clientConfiguration.TokenValidationClaimRole
                };

                options.Events = new OpenIdConnectEvents
                {
                    OnMessageReceived = context => OnMessageReceived(context, clientConfiguration),
                    OnRedirectToIdentityProvider = context => OnRedirectToIdentityProvider(context, clientConfiguration),
                };
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


            builder.Services.AddTransient<IProductsService, ProductService>();
            builder.Services.AddTransient<IProductBrandsService, ProductBrandService>();
            builder.Services.AddTransient<IProductTypesService, ProductTypeService>();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static Task OnMessageReceived(MessageReceivedContext context, ClientConfiguration clientConfiguration)
        {
            context.Properties.IsPersistent = true;
            context.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(clientConfiguration.CookieExpiresUtcHours));

            return Task.CompletedTask;
        }

        private static Task OnRedirectToIdentityProvider(RedirectContext context, ClientConfiguration clientConfiguration)
        {
            if (!string.IsNullOrEmpty(clientConfiguration.ClientRedirectUri))
            {
                context.ProtocolMessage.RedirectUri = clientConfiguration.ClientRedirectUri;
            }

            return Task.CompletedTask;
        }
    }
}