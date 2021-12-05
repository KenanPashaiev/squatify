using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using VideoService.API.Extensions;
using VideoService.DAL;

namespace VideoService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().CreateDatabase<VideoContext>().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
