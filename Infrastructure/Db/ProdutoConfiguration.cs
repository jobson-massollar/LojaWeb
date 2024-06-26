﻿using Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Db;

public class ProdutoConfiguration : EntityConfiguration<Produto>
{
    public override void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.Property(p => p.Descricao).HasMaxLength(50);

        builder.OwnsOne(p => p.CodigoBarras, cbBuilder =>
        {
            cbBuilder.Property(cb => cb.Valor);
            cbBuilder.HasIndex(cb => cb.Valor).IsUnique();
        });

        builder.ComplexProperty(p => p.Preco);

        // É importante chamar por último, porque o configurador base vai usar o nome da tabela
        // para gerar o trigger de update
        base.Configure(builder);
    }
}
