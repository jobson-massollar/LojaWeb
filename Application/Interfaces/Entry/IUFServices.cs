using Domain.Model;
using Domain.Model.Errors;

namespace Application.Interfaces.Entry;

public interface IUFServices
{
    Result<UF> CriarUF(string sigla, string nome);

    List<UF> RecuperarTodas();

    UF? RecuperarPorSigla(string sigla);

    int Remover(Guid id);

    int Remover(string sigla);
}
