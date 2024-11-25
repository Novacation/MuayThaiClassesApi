using MuayThaiClassesApi.Adapters.Repositories;
using MuayThaiClassesApi.Core.UseCases.Students;
using MuayThaiClassesApi.Infra.Entities;

namespace MuayThaiClassesApi.Application.Services.Students
{
    public class GetStudentByEmailService(IStudentsRepository studentsRepository) : IGetStudentByEmailUseCase
    {
        public async Task<StudentsEntity?> Execute(string email)
        {
            return await studentsRepository.GetStudentByEmail(email);
        }
    }
}