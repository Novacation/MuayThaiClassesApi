namespace MuayThaiClassesApi.Application.Common
{

    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new();

        public static ApiResponse<T> CreateSuccess(T? data) =>
            new() { Success = true, Data = data };

        public static ApiResponse<T> CreateError(List<string> errors) =>
            new() { Success = false, Errors = errors };
    }
}
