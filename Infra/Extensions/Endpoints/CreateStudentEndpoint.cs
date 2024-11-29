using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MuayThaiClassesApi.Application.Common.Responses;
using MuayThaiClassesApi.Application.Dtos.Students;
using MuayThaiClassesApi.Core.UseCases.Jwt;
using MuayThaiClassesApi.Core.UseCases.Students;
using MuayThaiClassesApi.Infra.Entities;
using MuayThaiClassesApi.Infra.Extensions.ApiResponse;

namespace MuayThaiClassesApi.Infra.Extensions.Endpoints;

public static class CreateStudentEndpoint
{
    public static void MapEndpoint(RouteGroupBuilder app)
    {
        app.MapPost("/create", async Task<IResult> (ICreateStudentUseCase createStudentUseCase,
            IGenerateJwtUseCase generateJwtUseCase, IGetStudentByEmailUseCase getStudentByEmailUseCase,
            [FromBody] CreateStudentDto student) =>
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(student, new ValidationContext(student), validationResults, true))
                {
                    var validationErrors = validationResults.Select(x => x.ErrorMessage).Where(x => x != null)
                        .ToList();

                    return ApiResponse<object>.Failure(new Error("Invalid request data",
                        validationErrors.Count > 0 ? validationErrors[0]! : "")).ToHttpResponse();
                }

                var existingStudent = await getStudentByEmailUseCase.Execute(student.Email);
                if (existingStudent != null)
                    return ApiResponse<object>.Failure(
                        new Error("Email conflict", "Email already in use"), StatusCodes
                            .Status409Conflict).ToHttpResponse();

                var jwtVal = generateJwtUseCase.Execute(student.Email);

                await createStudentUseCase.Execute(new StudentsEntity
                {
                    Name = student.Name,
                    Email = student.Email,
                    Password = student.Password,
                    RankId = 1,
                    Jwt = jwtVal
                });

                return ApiResponse<object>.Success(jwtVal, StatusCodes.Status201Created).ToHttpResponse();
            }
            catch (Exception)
            {
                return ApiResponse<object>.Failure(
                    new Error("Internal server error", "An unexpected error ocurred"),
                    StatusCodes.Status500InternalServerError).ToHttpResponse();
            }
        });
    }
}
