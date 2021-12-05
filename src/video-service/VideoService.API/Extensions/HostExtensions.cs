using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace VideoService.API.Extensions
{
    public static class HostExtensions
    {
        /// <summary>  
        /// Migrates the database.  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="host">The host.</param>  
        /// <returns>IHost.</returns>  
        public static IHost CreateDatabase<T>(this IHost host) where T : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var db = services.GetRequiredService<T>();
                    db.Database.Migrate();
                    db.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Database Creation/Migrations failed!");
                }
            }
            return host;
        }
    }
}