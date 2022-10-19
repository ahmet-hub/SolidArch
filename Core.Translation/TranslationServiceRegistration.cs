using Core.Translation.Context;
using Core.Translation.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Translation
{
    public static class TranslationServiceRegistration
    {
        public static IServiceCollection AddTranslationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<TranslateService>();
            services.AddScoped<ContentContext>();
            return services;
        }
    }
}
