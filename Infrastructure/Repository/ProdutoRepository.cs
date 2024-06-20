using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Domain.Model.Errors;
using Infrastructure.Db;

namespace Infrastructure.Repository;

public class ProdutoRepository : Repositorio<Produto>, IProdutoRepository
{
    public ProdutoRepository(LojaDbContext db) : base(db) { }

    public Produto? RecuperarPorCodigo(string codigo) => db.Produtos.SingleOrDefault(p => p.CodigoBarras.Valor == codigo);

    public override Result<int> RemoverPorId(Guid id) => RemoverPorId(id, ErroEntidade.PRODUTO_NAO_PODE_EXCLUIR);

    public Result<int> RemoverPorCodigo(string codigoBarras) => Remover(p => p.CodigoBarras.Valor == codigoBarras, ErroEntidade.PRODUTO_NAO_PODE_EXCLUIR);
}
