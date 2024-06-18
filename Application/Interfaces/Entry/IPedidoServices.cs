using Api.Contracts;
using Domain.Model;
using Domain.Model.Errors;

namespace Application.Interfaces.Entry;

public interface IPedidoServices
{
    Result<Pedido> CriarPedido(CriarPedidoData dados);

    List<Pedido> RecuperarTodos();

    Result<int> Remover(Guid id);
}
