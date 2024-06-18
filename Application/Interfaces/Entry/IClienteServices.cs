using Domain.Model;
using Domain.Model.Errors;

namespace Application.Interfaces.Entry;

public interface IClienteServices
{
    Result<Cliente> CriarCliente(CriarClienteData dadosCliente);

    Cliente? RecuperarPorCPF(long cpf);

    List<Cliente> RecuperarTodos();

    Result<List<Preferencia>?> RecuperarPreferencias(Guid clienteId);

    Result<List<Pedido>?> RecuperarPedidos(Guid clienteId);

    Result<int> Remover(Guid id);

    Result<int> Remover(long cpf);
}
