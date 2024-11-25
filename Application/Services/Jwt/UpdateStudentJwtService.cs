using MuayThaiClassesApi.Adapters.Repositories;
using MuayThaiClassesApi.Core.UseCases.Jwt;
using MuayThaiClassesApi.Infra.Entities;

namespace MuayThaiClassesApi.Application.Services.Jwt
{
    public class UpdateStudentJwtService(IStudentsRepository studentsRepository) : IUpdateStudentJwtUseCase
    {
        public async Task Execute(StudentsEntity student, string? jwt)
        {
            await studentsRepository.UpdateStudentJwt(student, jwt);
        }
    }
}