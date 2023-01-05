using Microsoft.IdentityModel.Tokens;

namespace API.Catalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var config = builder.Configuration;

            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    options.Authority = config["IdentityServer:Authority"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(name: "read_access", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "catalog.read");
                });

                options.AddPolicy(name: "write_access", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "catalog.write");
                });
            });

            // Configure the HTTP request pipeline.

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}