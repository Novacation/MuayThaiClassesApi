namespace MuayThaiClassesApi.Application.Common.Responses;

public class ApiResponse<T>
{
    public bool IsSuccess { get; }
    public Error? Error { get; }
    public int StatusCode { get; }
    public T? Data { get; }

    private ApiResponse(bool isSuccess, T? data, Error? error, int statusCode)
    {
        IsSuccess = isSuccess;
        Data = data;
        Error = error;
        StatusCode = statusCode;
    }

    public static ApiResponse<T> Success(T data, int statusCode = 200)
    {
        return new ApiResponse<T>(data: data, isSuccess: true, error: null, statusCode: statusCode);
    }

    public static ApiResponse<T> Failure(Error error, int statusCode = 400)
    {
        return new ApiResponse<T>(data: default, isSuccess: false, error: error, statusCode: statusCode);
    }
}
