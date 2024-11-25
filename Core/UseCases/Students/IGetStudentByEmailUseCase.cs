using MuayThaiClassesApi.Infra.Entities;

namespace MuayThaiClassesApi.Core.UseCases.Students
{
    public interface IGetStudentByEmailUseCase
    {
        Task<StudentsEntity?> Execute(string email);
    }
}