using Domain.Model;
using Domain.Model.Errors;

namespace Application.Interfaces.Entry;

public interface IPreferenciaServices
{
    Result<Preferencia> CriarPreferencia(string descricao);

    Preferencia? RecuperarPorDescricao(string descricao);

    List<Preferencia> RecuperarTodas();

    Result<int> Remover(Guid id);

    Result<int> Remover(string descricao);
}
