using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Domain.Model.Errors;
using Infrastructure.Db;

namespace Infrastructure.Repository;

public class UFRepository : Repositorio<UF>, IUFRepository
{
    public UFRepository(LojaDbContext db) : base(db) { }

    public UF? RecuperarPorSigla(string sigla) => db.UFs.SingleOrDefault(uf => uf.Sigla == sigla);

    public bool JaExisteUF(string siglaUF) => db.UFs.SingleOrDefault(uf => uf.Sigla == siglaUF) is UF;

    public override Result<int> RemoverPorId(Guid id) => RemoverPorId(id, ErroEntidade.UF_NAO_PODE_EXCLUIR);

    public Result<int> RemoverPorSigla(string sigla) => Remover(uf => uf.Sigla == sigla, ErroEntidade.UF_NAO_PODE_EXCLUIR);
}
