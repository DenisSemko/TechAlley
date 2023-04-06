namespace Catalog.API.Extensions;

public static class HostExtensions
{
    public static WebApplication MigrateDatabase(this WebApplication app, Action<IUnitOfWork, IServiceProvider> seeder, int? retry = 0)
    {
        int retryForAvailability = retry.Value;

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<Program>>();
            var database = services.GetService<IUnitOfWork>();

            try
            {
                InvokeSeeder(seeder, database, services);
            }
            catch (MongoCommandException ex)
            {
                if (retryForAvailability < 50)
                {
                    retryForAvailability++;
                    System.Threading.Thread.Sleep(2000);
                    MigrateDatabase(app, seeder, retryForAvailability);
                }
            }
        }

        return app;
    }

    private static void InvokeSeeder(Action<IUnitOfWork, IServiceProvider> seeder, IUnitOfWork database, IServiceProvider services)
    {
        seeder(database, services);
    }
}
