using Domain.Model;

namespace Application.Interfaces.Infrastructure.Repository;

public interface IClienteRepository
{
    Cliente? RecuperarPorCPF(long cpf);

    Cliente? RecuperarPorId(Guid id);

    List<Cliente> RecuperarTodos();

    bool JaExisteCPF(long cpf);

    bool JaExisteEmail(string email);

    void Add(Cliente cliente);

    int Remove(Guid Id);

    int Remove(long cpf);
}
