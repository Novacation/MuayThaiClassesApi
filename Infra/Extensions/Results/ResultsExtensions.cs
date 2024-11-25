using MuayThaiClassesApi.Application.Common;

namespace MuayThaiClassesApi.Infra.Extensions.Results
{
    public static class ResultsExtensions
    {
        public static IResult ToApiResponse<T>(this T data, int statusCode) =>
            TypedResults.Json(ApiResponse<T>.CreateSuccess(data), statusCode: statusCode);

        public static IResult ToApiError(this List<string> errors, int statusCode) =>
            TypedResults.Json(ApiResponse<object>.CreateError(errors), statusCode: statusCode);
    }
}