using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Db;

public class LojaDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Produto> Produtos { get; set; }

    public DbSet<Pedido> Pedidos { get; set; }

    public DbSet<Item> Items { get; set; }

    public DbSet<Endereco> Enderecos { get; set; }

    public DbSet<UF> UFs { get; set; }

    public DbSet<Preferencia> Preferencias { get; set; }

    public LojaDbContext(DbContextOptions<LojaDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // USAR ESSE COMANDO PARA SUBSTITUIR OS DEMAIS!
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext));

        new ProdutoConfiguration().Configure(modelBuilder.Entity<Produto>());
        new ClienteConfiguration().Configure(modelBuilder.Entity<Cliente>());
        new ItemConfiguration().Configure(modelBuilder.Entity<Item>());
        new PedidoConfiguration().Configure(modelBuilder.Entity<Pedido>());
        new EnderecoConfiguration().Configure(modelBuilder.Entity<Endereco>());
        new UFConfiguration().Configure(modelBuilder.Entity<UF>());
        new PreferenciaConfiguration().Configure(modelBuilder.Entity<Preferencia>());

    }
}
