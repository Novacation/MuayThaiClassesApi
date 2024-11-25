using Microsoft.EntityFrameworkCore;
using MuayThaiClassesApi.Adapters.Repositories;
using MuayThaiClassesApi.Infra.Entities;

namespace MuayThaiClassesApi.Infra.Repositories
{
    public class StudentsRepository(AppDbContext dbContext) : IStudentsRepository
    {
        public async Task CreateStudent(StudentsEntity student)
        {
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
        }

        public async Task<StudentsEntity?> GetStudentByEmail(string email)
        {
            return await dbContext.Students.FirstOrDefaultAsync(student => student.Email == email);
        }

        public async Task<StudentsEntity?> GetStudentByEmailAndPassword(string email, string password)
        {
            return await dbContext.Students.FirstOrDefaultAsync(student => student.Email == email && student.Password == password);
        }

        public async Task UpdateStudentJwt(StudentsEntity student, string? jwt)
        {
            student.Jwt = jwt;
            await dbContext.SaveChangesAsync();
        }
    }
}