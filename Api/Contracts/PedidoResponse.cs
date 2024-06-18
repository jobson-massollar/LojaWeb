namespace Api.Contracts;

public class PedidoResponse
{
    public Guid Id { get; private set; }

    public List<ItemPedidoResponse> itens { get; private set; }

    public PedidoResponse() { }
}
