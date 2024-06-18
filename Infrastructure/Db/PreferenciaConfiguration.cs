using Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Db;

public class PreferenciaConfiguration : EntityConfiguration<Preferencia>
{
    public override void Configure(EntityTypeBuilder<Preferencia> builder)
    {
        builder.HasIndex(p => p.Descricao).IsUnique();

        // É importante chamar por último, porque o configurador base vai usar o nome da tabela
        // para gerar o trigger de update
        base.Configure(builder);
    }
}
