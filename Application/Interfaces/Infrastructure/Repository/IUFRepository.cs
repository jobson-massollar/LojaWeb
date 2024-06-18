using Domain.Model;

namespace Application.Interfaces.Infrastructure.Repository;

public interface IUFRepository
{
    UF? RecuperarPorSigla(string siglaUF);

    List<UF> RecuperarTodas();

    bool JaExisteUF(string sigla);

    void Add(UF uf);

    int Remove(Guid id);

    int Remove(String sigla);
}
