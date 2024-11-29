using System.ComponentModel.DataAnnotations;

namespace MuayThaiClassesApi.Application.Dtos.Students;

public class LoginStudentDto
{
    [Required] public required string Email { get; init; }

    [Required] public required string Password { get; init; }
}
