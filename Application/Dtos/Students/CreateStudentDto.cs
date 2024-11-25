using System.ComponentModel.DataAnnotations;

namespace MuayThaiClassesApi.Application.Dtos.Students
{
    public class CreateStudentDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}