namespace MuayThaiClassesApi.Core.UseCases.Jwt
{
    public interface IGenerateJwtUseCase
    {
        string Execute(string email);
    }
}