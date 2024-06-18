namespace Api.Contracts;

public class ItemPedidoResponse
{
    public Guid Id { get; private set; }

    public int Quantidade { get; private set; }

    public string Moeda { get; private set; }

    public float Preco { get; private set; }

    public string Produto { get; private set; }

    public ItemPedidoResponse() { }
}
