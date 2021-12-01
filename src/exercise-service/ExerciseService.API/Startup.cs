using ExerciseService.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using ExerciseService.BL.Models.ExerciseSet;
using ExerciseService.API.Validators;
using ExerciseService.BL.Models.ExerciseType;
using ExerciseService.BL.Managers;
using ExerciseService.DAL.Abstractions;
using ExerciseService.DAL.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using UserService.BL.Utils;
using ExerciseService.API.Services.Abstractions;

namespace ExerciseService.API
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
            services.AddControllers()
                .AddFluentValidation();
                
            services.AddTransient<IValidator<ExerciseSetCreateUpdateDto>, ExerciseSetCreateUpdateDtoValidator>();
            services.AddTransient<IValidator<ExerciseTypeCreateUpdateDto>, ExerciseTypeCreateUpdateDtoValidator>();

            services.AddTransient<IExerciseSetManager, ExerciseSetManager>();
            services.AddTransient<IExerciseTypeManager, ExerciseTypeManager>();

            services.AddScoped<IExerciseSetRepository, ExerciseSetRepository>();
            services.AddScoped<IExerciseTypeRepository, ExerciseTypeRepository>();

            services.AddHttpClient<IUserService, Services.UserService>();

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

            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen();
            services.AddDbContext<ExerciseContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
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
            });
        }
    }
}
