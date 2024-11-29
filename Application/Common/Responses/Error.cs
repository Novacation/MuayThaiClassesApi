namespace MuayThaiClassesApi.Application.Common.Responses;

public record Error(string code, string message)
{
    public static Error None=> new(code: string.Empty, message: string.Empty);

    public static Error NullValue=> new (code: "Error.NullValue", message: "Um valor nulo foi fornecido.");
}
