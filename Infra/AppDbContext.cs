using Microsoft.EntityFrameworkCore;
using MuayThaiClassesApi.Infra.Entities;

namespace MuayThaiClassesApi.Infra
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public required DbSet<StudentsEntity> Students { get; set; }

        public required DbSet<RanksEntity> Ranks { get; set; }

        public required DbSet<ClassesEntity> Classes { get; set; }
    }
}