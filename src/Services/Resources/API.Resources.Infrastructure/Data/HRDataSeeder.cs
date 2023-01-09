using API.Resources.Core.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace API.Resources.Infrastructure.Data
{
    public class HRDataSeeder
    {
        public static async Task SeedAsync(HRContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Employees.Any())
                {
                    var entitiesData = File.ReadAllText("../API.Resources.Infrastructure/Data/SeedData/employees.json");
                    var entities = JsonSerializer.Deserialize<List<Employee>>(entitiesData);

                    await context.Employees.AddRangeAsync(entities);
                    await context.SaveChangesAsync();
                }

                if (!context.Subscriptions.Any())
                {
                    var entitiesData = File.ReadAllText("../API.Resources.Infrastructure/Data/SeedData/subscriptions.json");
                    var entities = JsonSerializer.Deserialize<List<Subscription>>(entitiesData);

                    await context.Subscriptions.AddRangeAsync(entities);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<HRDataSeeder>();

                logger.LogError(ex.Message);
            }
        }
    }
}
