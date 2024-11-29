using MuayThaiClassesApi.Infra.Entities;

namespace MuayThaiClassesApi.Core.UseCases.Students;

public interface ILoginStudentUseCase
{
    Task Execute(StudentsEntity student, string jwt);
}
