using Domain.Model;
using Domain.Model.Errors;

namespace Application.Interfaces.Entry;

public interface IProdutoServices
{
    Result<Produto> CriarProduto(CriarProdutoData data);

    Produto? RecuperarPorCodigo(string codigo);

    List<Produto> RecuperarTodos();

    Result<int> Remover(string codigoBarras);

    Result<int> Remover(Guid id);
}
