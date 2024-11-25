using MuayThaiClassesApi.Adapters.Repositories;
using MuayThaiClassesApi.Core.UseCases.Students;
using MuayThaiClassesApi.Infra.Entities;

namespace MuayThaiClassesApi.Application.Services.Students
{
    public class GetStudentByEmailAndPasswordService(IStudentsRepository studentsRepository) : IGetStudentByEmailAndPasswordUseCase
    {
        public async Task<StudentsEntity?> Execute(string email, string password)
        {
            return await studentsRepository.GetStudentByEmailAndPassword(email, password);
        }
    }
}