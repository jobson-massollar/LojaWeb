using Domain.Model;
using Domain.Model.Errors;
using Infrastructure.Db;

namespace Infrastructure.Repository;

public class ClienteRGRepository : Repositorio<ClienteRG>
{
    public ClienteRGRepository(LojaDbContext db) : base(db)
    {
    }

    public override Result<int> RemoverPorId(Guid id) => RemoverPorId(id, ErroEntidade.CLIENTE_NAO_ENCONTRADO);
}
