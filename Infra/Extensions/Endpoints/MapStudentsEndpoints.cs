namespace MuayThaiClassesApi.Infra.Extensions.Endpoints
{
    public static class MapStudentsEndpoints
    {
        public static void Execute(RouteGroupBuilder routeGroupBuilder)
        {
            CreateStudentEndpoint.MapEndpoint(routeGroupBuilder);
        }
    }
}