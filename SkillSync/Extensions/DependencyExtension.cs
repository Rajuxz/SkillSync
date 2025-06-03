using SkillSync.Services.Interfaces;
using SkillSync.Services;

namespace SkillSync.Extensions
{
    public static class DependencyExtension
    {
        /// <summary>
        /// This Extension is for dependency injection for services and repositories.
        /// Add your Services in AddServicesDependency method.
        /// Add repositories in AddRepositoryDependency method.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceCollection(this IServiceCollection services) 
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAuthService, AuthService>();
            
            return services;
        }
    }
}
