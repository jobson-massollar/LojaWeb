using Domain.Model;
using Domain.Model.Errors;

namespace Application.Interfaces.Entry;

public interface IClienteServices
{
    Result<Cliente> CriarCliente(CriarClienteData dadosCliente);

    Cliente? RecuperarPorCPF(long cpf);

    List<Cliente> RecuperarTodos();

    int Remover(Guid id);

    int Remover(long cpf);
}
