using MuayThaiClassesApi.Adapters.Repositories;
using MuayThaiClassesApi.Core.UseCases.Students;
using MuayThaiClassesApi.Infra.Entities;

namespace MuayThaiClassesApi.Application.Services.Students;

public class LoginStudentService(IStudentsRepository studentsRepository) : ILoginStudentUseCase
{
    public async Task Execute(StudentsEntity student, string jwt)
    {
        await studentsRepository.UpdateStudentJwt(student, jwt);
    }
}