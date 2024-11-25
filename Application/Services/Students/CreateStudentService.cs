using MuayThaiClassesApi.Adapters.Repositories;
using MuayThaiClassesApi.Core.UseCases.Students;
using MuayThaiClassesApi.Infra.Entities;

namespace MuayThaiClassesApi.Application.Services.Students
{
    public class CreateStudentService(IStudentsRepository studentsRepository) : ICreateStudentUseCase
    {
        public async Task Execute(StudentsEntity newStudent)
        {
            await studentsRepository.CreateStudent(newStudent);
        }
    }
}