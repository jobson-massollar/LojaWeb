using Domain.Model;
using Domain.Model.Errors;

namespace Application.Interfaces.Entry;

public interface IProdutoServices
{
    Result<Produto> CriarProduto(CriarProdutoData data);

    Produto? RecuperarPorCodigo(string codigo);

    List<Produto> RecuperarTodos();

    int RemoverProduto(string codigo);

    int RemoverProduto(Guid id);
}
