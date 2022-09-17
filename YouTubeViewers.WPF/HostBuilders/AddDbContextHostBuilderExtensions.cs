using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YouTubeViewers.EntityFramework;

namespace YouTubeViewers.WPF.HostBuilders;
public static class AddDbContextHostBuilderExtensions
{
    public static IHostBuilder AddDbContext(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices((context, services) =>
        {
            var connectionString = context.Configuration.GetConnectionString("sqlite");

            services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder()
                .UseSqlite(connectionString).Options);
            services.AddSingleton<YouTubeViewersDesignTimeDbContextFactory>();
        });

        return hostBuilder;
    }
}
