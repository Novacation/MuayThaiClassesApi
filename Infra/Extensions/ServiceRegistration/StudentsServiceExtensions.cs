using MuayThaiClassesApi.Adapters.Repositories;
using MuayThaiClassesApi.Application.Services.Students;
using MuayThaiClassesApi.Core.UseCases.Students;
using MuayThaiClassesApi.Infra.Repositories;

namespace MuayThaiClassesApi.Infra.Extensions.ServiceRegistration;

public static class StudentsServiceExtensions
{
    public static IServiceCollection AddStudentsServices(this IServiceCollection services)
    {
        AddRepository(services);
        AddUseCases(services);

        return services;
    }

    private static IServiceCollection AddRepository(IServiceCollection services)
    {
        services.AddTransient<IStudentsRepository, StudentsRepository>();

        return services;
    }

    private static IServiceCollection AddUseCases(IServiceCollection services)
    {
        services.AddTransient<ICreateStudentUseCase, CreateStudentService>();
        services.AddTransient<IGetStudentByEmailUseCase, GetStudentByEmailService>();
        services.AddTransient<IGetStudentByEmailAndPasswordUseCase, GetStudentByEmailAndPasswordService>();
        services.AddTransient<ILoginStudentUseCase, LoginStudentService>();

        return services;
    }
}
