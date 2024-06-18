﻿using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Db;

public class ItemConfiguration : EntityConfiguration<Item>
{
    public override void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Itens");
        builder.ComplexProperty(it => it.Preco);

        builder.HasOne(it => it.Produto).WithMany().OnDelete(DeleteBehavior.Restrict);

        // É importante chamar por último, porque o configurador base vai usar o nome da tabela
        // para gerar o trigger de update
        base.Configure(builder);
    }
}
