using MuayThaiClassesApi.Application.Services.Jwt;
using MuayThaiClassesApi.Core.UseCases.Jwt;

namespace MuayThaiClassesApi.Infra.Extensions.ServiceRegistration
{
    public static class AuthServiceExtensions
    {
        public static IServiceCollection AddAuthServices(
       this IServiceCollection services)
        {
            AddUseCases(services);
            return services;
        }

        private static void AddUseCases(
            IServiceCollection services)
        {
            services.AddTransient<IGenerateJwtUseCase, GenerateJwtService>();
        }
    }
}