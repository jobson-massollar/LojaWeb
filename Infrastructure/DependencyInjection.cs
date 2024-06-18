using Application.Interfaces.Infrastructure.Repository;
using Infrastructure.Db;
using Infrastructure.MigrationUtils;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager config)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IUFRepository, UFRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IPreferenciaRepository, PreferenciaRepository>();
        services.AddScoped<IPedidoRepository, PedidoRepository>();

        services.AddDbContext<LojaDbContext>(options =>
        {
            /* 
             * Na linha ReplaceService abaixo eu criei um serviço para gerar as triggers de 
             * atualização do campo UpdatedAt da tabelas, mas está na sintaxe do SQLite.
             * Se rodar no PostgreSQL deve dar pau, então eu comentei.
             * Não sei se a gente vai usar isso no sistema da Go Bee.
             */
            options
                //.UseLazyLoadingProxies()
                .ReplaceService<IMigrationsModelDiffer, InsertSqlCommands>()
                .UseSqlite(config.GetConnectionString("StoreDatabase"));
        });
        return services;
    }
}
