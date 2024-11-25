using MuayThaiClassesApi.Infra.Entities;

namespace MuayThaiClassesApi.Adapters.Repositories
{
    public interface IStudentsRepository
    {
        Task<StudentsEntity?> GetStudentByEmailAndPassword(string email, string password);

        Task<StudentsEntity?> GetStudentByEmail(string email);

        Task CreateStudent(StudentsEntity student);

        Task UpdateStudentJwt(StudentsEntity student, string? jwt);

    }
}