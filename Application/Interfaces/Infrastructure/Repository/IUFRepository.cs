using Domain.Model;
using Domain.Model.Errors;

namespace Application.Interfaces.Infrastructure.Repository;

public interface IUFRepository
{
    void Adicionar(UF uf);

    void Remover(UF uf);

    UF? RecuperarPorId(Guid id);

    Result<UF> RecuperarPorId(Guid id, ErroEntidade erro);

    List<UF> RecuperarTodos();

    Result<int> RemoverPorId(Guid id);

    Result<int> RemoverPorId(Guid id, ErroEntidade erro);

    UF? RecuperarPorSigla(string siglaUF);

    bool JaExisteUF(string sigla);

    Result<int> RemoverPorSigla(String sigla);
}
