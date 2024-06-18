﻿using Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Db;

public class UFConfiguration : EntityConfiguration<UF>
{
    public override void Configure(EntityTypeBuilder<UF> builder)
    {
        builder.HasIndex(uf => uf.Sigla).IsUnique();

        // É importante chamar por último, porque o configurador base vai usar o nome da tabela
        // para gerar o trigger de update
        base.Configure(builder);
    }
}
