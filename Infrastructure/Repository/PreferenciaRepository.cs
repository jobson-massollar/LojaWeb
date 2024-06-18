using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Domain.Model.Errors;
using Infrastructure.Db;

namespace Infrastructure.Repository;

public class PreferenciaRepository : Repositorio<Preferencia>, IPreferenciaRepository
{
    public PreferenciaRepository(LojaDbContext db) : base(db) { }

    public Preferencia? RecuperarPorDescricao(string descricao) => db.Preferencias.FirstOrDefault(p => p.Descricao == descricao);

    public override Result<int> RemoverPorId(Guid id) => RemoverPorId(id, ErroEntidade.PREFERENCIA_NAO_PODE_EXCLUIR);

    public Result<int> RemoverPorDescricao(string descricao) => Remover(p => p.Descricao == descricao, ErroEntidade.PREFERENCIA_NAO_PODE_EXCLUIR);
}
