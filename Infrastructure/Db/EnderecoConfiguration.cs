using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Db;

public class EnderecoConfiguration : EntityConfiguration<Endereco>
{
    public override void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.Property(e => e.Logradouro).HasMaxLength(60);

        builder.Property(e => e.Numero).HasMaxLength(10);

        builder.Property(e => e.Complemento).HasMaxLength(30);

        builder.Property(e => e.Bairro).HasMaxLength(30);

        builder.ComplexProperty(e => e.Cep);

        builder.HasOne(e => e.UF).WithMany().OnDelete(DeleteBehavior.Restrict);

        // É importante chamar por último, porque o configurador base vai usar o nome da tabela
        // para gerar o trigger de update
        base.Configure(builder);
    }
}
