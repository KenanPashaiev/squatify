using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VideoService.API.Services.Abstractions;
using VideoService.API.HealthChecks;
using VideoService.API.Services;
using VideoService.BL.Utilities;
using VideoService.BL.Abstractions;
using VideoService.BL.Managers;
using VideoService.DAL;
using VideoService.DAL.Repositories;
using VideoService.DAL.Abstractions;
using Microsoft.EntityFrameworkCore;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Downloader;
using Mono.Unix.Native;

namespace VideoService.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            InstallFFmpeg();
            services.AddControllers();

            services.AddTransient<IVideoManager, VideoManager>();

            services.AddTransient<IVideoRepository, VideoRepository>();
            services.AddTransient<IVideoUploader, VideoUploader>();

            services.AddHttpClient<IUserService, UserService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = AuthOptions.ISSUER,

                            ValidateAudience = true,
                            ValidAudience = AuthOptions.AUDIENCE,
                            ValidateLifetime = true,

                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.AddHttpContextAccessor();
            services.AddSwaggerGen();
            services.AddDbContext<VideoContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddHealthChecks()
		        .AddCheck<DbMigrationHealthCheck<VideoContext>>("db-migration-check");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exercise Service API V1");
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/");
            });
        }

        private void InstallFFmpeg()
        {
            FFmpegDownloader.GetLatestVersion(FFmpegVersion.Official, FFmpeg.ExecutablesPath).Wait();
            Syscall.chmod("ffmpeg", FilePermissions.S_IRUSR | FilePermissions.S_IWUSR | FilePermissions.S_IXUSR);
            Syscall.chmod("ffprobe", FilePermissions.S_IRUSR | FilePermissions.S_IWUSR | FilePermissions.S_IXUSR);
            FFmpeg.SetExecutablesPath(FFmpeg.ExecutablesPath);
        }
    }
}
