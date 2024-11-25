using MuayThaiClassesApi.Infra.Entities;

namespace MuayThaiClassesApi.Core.UseCases.Students
{
    public interface IGetStudentByEmailAndPasswordUseCase
    {
        Task<StudentsEntity?> Execute(string email, string password);
    }
}