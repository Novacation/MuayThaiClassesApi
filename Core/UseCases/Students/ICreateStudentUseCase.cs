using MuayThaiClassesApi.Infra.Entities;

namespace MuayThaiClassesApi.Core.UseCases.Students
{
    public interface ICreateStudentUseCase
    {
        Task Execute(StudentsEntity newStudent);
    }
}