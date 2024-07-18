using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Db;

public class ClienteRGConfiguration : EntityConfiguration<ClienteRG>
{
    public override void Configure(EntityTypeBuilder<ClienteRG> builder)
    {
        builder.ToTable("ClienteRGs");

        // É importante chamar por último, porque o configurador base vai usar o nome da tabela
        // para gerar o trigger de update
        base.Configure(builder);
    }
}
