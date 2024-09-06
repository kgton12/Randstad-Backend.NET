using EmployeeRegistrationSystem.API.Endpoint.Employees;

namespace EmployeeRegistrationSystem.API.Common.Extensions
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints
                .MapGroup("/")
                .WithTags("Healt Check")
                .MapGet("/", () => new { message = "OK" });

            endpoints
               .MapGroup("/employee")
               .WithTags("employee")
               .MapEndpoint<EmployeeEndpoint>();
        }
        private static IEndpointRouteBuilder MapEndpoint<T>(this IEndpointRouteBuilder app) where T : IEndpoint
        {
            T.Map(app);
            return app;
        }
    }
}
