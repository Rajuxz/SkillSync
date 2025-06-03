using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using SkillSync.Data;
using SkillSync.Models;
using System.Text;

namespace SkillSync.Extensions
{
    public static class ServiceExtension
    {
        /// <summary>
        /// Configuration of PostgreSQL Database with NpgSql package.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddIdentity<UserModel, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        /// <summary>
        /// onfigures JWT-based authentication, specifying how to validate the token and customizing token retrieval to pull the JWT from a cookie rather than the Authorization header.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureJwt(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                //checks if user is authenticated or not
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //if not, it will execute, showing unauthorized status (401)
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var token = context.HttpContext.Request.Cookies["Jwt"];
                        context.Token = token;
                        return Task.CompletedTask;
                    }
                };

            });
            return services;
        }

        //Cors configuration
        /// <summary>
        /// This method configure Application to be used by third party users, includes frontend applications.
        /// </summary>
        /// <param name="services"></param>
        /// Not Required.
        /// <returns></returns>
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                builder.WithOrigins("http://localhost:5173")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                );
            });
            return services;
        }
        /// <summary>
        /// This method configures the serilog logging.
        /// Just pass Builder object from your program.cs file.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="builder"></param>
        /// <returns>services</returns>
        public static IServiceCollection ConfigureSerilog(this IServiceCollection services,WebApplicationBuilder builder)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Logs/SkillSync.txt", rollingInterval: RollingInterval.Day)
                .MinimumLevel.Warning()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            return services;
        }
    }
}
