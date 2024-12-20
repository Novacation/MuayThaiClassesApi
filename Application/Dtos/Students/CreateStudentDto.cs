using System.ComponentModel.DataAnnotations;

namespace MuayThaiClassesApi.Application.Dtos.Students;

public class CreateStudentDto
{
    [Required] public required string Name { get; init; }

    [Required] public required string Email { get; init; }

    [Required] public required string Password { get; init; }
}
