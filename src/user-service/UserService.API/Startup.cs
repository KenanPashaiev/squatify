using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserService.BL.Abstractions;
using UserService.DAL;
using UserService.DAL.Repositories;
using UserService.DAL.Abstractions;
using FluentValidation.AspNetCore;
using FluentValidation;
using UserService.BL.Models.User;
using UserService.API.Validators;
using UserService.BL.Managers;
using UserService.BL.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace UserService.API
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

            services.AddTransient<IValidator<UserRegisterDto>, UserRegisterDtoValidator>();
            services.AddTransient<IValidator<UserLoginDto>, UserLoginDtoValidator>();
            services.AddTransient<IValidator<UserUpdateDto>, UserUpdateDtoValidator>();

            services.AddTransient<IUserManager, UserManager>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddTransient<JwtService>();
            services.AddTransient<PasswordHasher<object>>();

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
            services.AddDbContext<UserContext>(
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Service API V1");
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
