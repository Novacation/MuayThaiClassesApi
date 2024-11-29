using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MuayThaiClassesApi.Application.Common.Responses;
using MuayThaiClassesApi.Application.Dtos.Students;
using MuayThaiClassesApi.Core.UseCases.Jwt;
using MuayThaiClassesApi.Core.UseCases.Students;
using MuayThaiClassesApi.Infra.Extensions.ApiResponse;

namespace MuayThaiClassesApi.Infra.Extensions.Endpoints.Students;

public static class LoginStudentEndpoint
{
    public static void MapEndpoint(RouteGroupBuilder app)
    {
        app.MapPost("/login",
            async Task<IResult> ([FromBody] LoginStudentDto
                    loginStudentDto, ILoginStudentUseCase loginStudentUseCase,
                IGetStudentByEmailAndPasswordUseCase getStudentByEmailAndPasswordUseCase,
                IGenerateJwtUseCase generateJwtUseCase
            ) =>
            {
                try
                {
                    var validationResults = new List<ValidationResult>();
                    if (!Validator.TryValidateObject(loginStudentDto, new ValidationContext(loginStudentDto),
                            validationResults, true))
                    {
                        var validationErrors = validationResults.Select(x => x.ErrorMessage).Where(x => x != null)
                            .ToList();

                        return ApiResponse<object>.Failure(new Error("Invalid request data",
                            validationErrors.Count > 0 ? validationErrors[0]! : "")).ToHttpResponse();
                    }

                    var existingStudent =
                        await getStudentByEmailAndPasswordUseCase.Execute(loginStudentDto.Email,
                            loginStudentDto.Password);

                    if (existingStudent is null)
                        return ApiResponse<object>.Failure(
                            new Error("Student not found", "Credentials for the student are invalid."),
                            StatusCodes.Status401Unauthorized).ToHttpResponse();

                    var newJwt = generateJwtUseCase.Execute(existingStudent.Email);

                    await loginStudentUseCase.Execute(existingStudent, newJwt);

                    return ApiResponse<object>.Success(newJwt, StatusCodes.Status201Created).ToHttpResponse();
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
