using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Domain.Model.Errors;
using Infrastructure.Db;

namespace Infrastructure.Repository;

public class PedidoRepository : Repositorio<Pedido>, IPedidoRepository
{
    public PedidoRepository(LojaDbContext db) : base(db)
    {
    }

    public override Result<int> RemoverPorId(Guid id) => RemoverPorId(id, ErroEntidade.PEDIDO_NAO_ENCONTRADO);
}
