using Api.ErrorHandling;
using Api.Mapping;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddAutoMapper(typeof(AutoMapperProfile));

        services.AddScoped<MensagemErro>();

        return services;
    }
}
