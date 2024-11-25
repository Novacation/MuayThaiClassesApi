using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MuayThaiClassesApi.Application.Dtos.Students;
using MuayThaiClassesApi.Core.UseCases.Jwt;
using MuayThaiClassesApi.Core.UseCases.Students;
using MuayThaiClassesApi.Infra.Extensions.Results;

namespace MuayThaiClassesApi.Infra.Extensions.Endpoints
{
    public static class CreateStudentEndpoint
    {
        public static void MapEndpoint(RouteGroupBuilder app)
        {
            app.MapPost("/create", async Task<IResult> (ICreateStudentUseCase createStudentUseCase, IGenerateJwtUseCase generateJwtUseCase, IGetStudentByEmailUseCase getStudentByEmailUseCase, [FromBody] CreateStudentDto student) =>
            {
                try
                {
                    var validationResults = new List<ValidationResult>();
                    if (!Validator.TryValidateObject(student, new ValidationContext(student), validationResults, true))
                    {
                        return validationResults.Select(x => x.ErrorMessage).Where(x => x != null).ToList()!.ToApiError(StatusCodes.Status400BadRequest);
                    }

                    var existingStudent = await getStudentByEmailUseCase.Execute(student.Email);
                    if (existingStudent != null)
                    {
                        return new List<string> { "Email already in use" }.ToApiError(StatusCodes.Status409Conflict);
                    }

                    await createStudentUseCase.Execute(new()
                    {
                        Name = student.Name,
                        Email = student.Email,
                        Password = student.Password,
                        RankId = 1,
                        Jwt = generateJwtUseCase.Execute(student.Email)
                    });

                    return new { }.ToApiResponse(StatusCodes.Status201Created);
                }
                catch (Exception)
                {
                    return new List<string> { "Internal server error" }.ToApiError(StatusCodes.Status500InternalServerError);
                }
            });
        }
    }
}