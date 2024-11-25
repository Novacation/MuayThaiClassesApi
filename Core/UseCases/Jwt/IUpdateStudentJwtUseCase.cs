using MuayThaiClassesApi.Infra.Entities;

namespace MuayThaiClassesApi.Core.UseCases.Jwt
{
    public interface IUpdateStudentJwtUseCase
    {
        Task Execute(StudentsEntity student, string? jwt);
    }
}