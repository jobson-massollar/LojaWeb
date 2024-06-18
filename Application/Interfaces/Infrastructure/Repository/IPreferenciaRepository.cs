using Domain.Model;
using Domain.Model.Errors;

namespace Application.Interfaces.Infrastructure.Repository;

public interface IPreferenciaRepository
{
    void Adicionar(Preferencia preferencia);

    void Atualizar(Preferencia preferencia);

    void Remover(Preferencia preferencia);

    Preferencia? RecuperarPorId(Guid id);

    Result<Preferencia> RecuperarPorId(Guid id, ErroEntidade erro);

    List<Preferencia> RecuperarTodos();

    Result<int> RemoverPorId(Guid id);

    Result<int> RemoverPorId(Guid id, ErroEntidade erro);

    Preferencia? RecuperarPorDescricao(string descricao);

    List<Preferencia> RecuperarPorId(List<Guid> preferencias);

    Result<int> RemoverPorDescricao(string descricao);
}
