using Application.Interfaces.Entry;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IClienteServices, ClienteServices>();
        services.AddScoped<IUFServices, UFServices>();
        services.AddScoped<IProdutoServices, ProdutoServices>();
        services.AddScoped<IPreferenciaServices, PreferenciaServices>();
        services.AddScoped<IPedidoServices, PedidoServices>();

        return services;
    }
}
