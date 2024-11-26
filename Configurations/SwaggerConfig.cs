using Microsoft.Extensions.DependencyInjection;

namespace AirportRoutingAPI.Configurations
{
    public static class SwaggerConfig
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Airport Routing API",
                    Version = "v1",
                    Description = "An API for fetching airport routes."
                });
            });
        }
    }
}
