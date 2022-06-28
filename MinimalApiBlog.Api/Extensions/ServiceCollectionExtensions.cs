namespace MinimalApiBlog.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            WebApplicationBuilder builder )
        {

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            return services;
        }

    }
}
