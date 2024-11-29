using MuayThaiClassesApi.Application.Common.Responses;

namespace MuayThaiClassesApi.Infra.Extensions.ApiResponse;

public static class ApiResponseExtensions
{
    public static IResult ToHttpResponse<T>(this ApiResponse<T> apiResponse)
    {
        return TypedResults.Json(new
        {
            apiResponse.Data,
            apiResponse.Error,
            apiResponse.IsSuccess
        }, statusCode: apiResponse.StatusCode);
    }
}
