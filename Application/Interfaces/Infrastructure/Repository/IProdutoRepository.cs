using Domain.Model;
using Domain.Model.Errors;

namespace Application.Interfaces.Infrastructure.Repository;

public interface IProdutoRepository
{
    void Adicionar(Produto produto);

    void Atualizar(Produto produto);

    void Remover(Produto produto);

    Produto? RecuperarPorId(Guid id);

    Result<Produto> RecuperarPorId(Guid id, ErroEntidade erro);

    List<Produto> RecuperarTodos();

    Result<int> RemoverPorId(Guid id);

    Result<int> RemoverPorId(Guid id, ErroEntidade erro);

    Produto? RecuperarPorCodigo(string codigo);

    Result<int> RemoverPorCodigo(string codigoBarras);
}
