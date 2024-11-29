namespace MuayThaiClassesApi.Infra.Extensions.Endpoints.Students;

public static class MapStudentsEndpoints
{
    public static void Execute(RouteGroupBuilder routeGroupBuilder)
    {
        CreateStudentEndpoint.MapEndpoint(routeGroupBuilder);

        LoginStudentEndpoint.MapEndpoint(routeGroupBuilder);
    }
}
