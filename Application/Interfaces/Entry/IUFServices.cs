using Domain.Model;
using Domain.Model.Errors;

namespace Application.Interfaces.Entry;

public interface IUFServices
{
    Result<UF> CriarUF(string sigla, string nome);

    List<UF> RecuperarTodas();

    UF? RecuperarPorSigla(string sigla);

    Result<int> Remover(Guid id);

    Result<int> Remover(string sigla);
}
