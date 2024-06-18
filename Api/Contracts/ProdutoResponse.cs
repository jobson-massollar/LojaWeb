namespace Api.Contracts;

public class ProdutoResponse
{
    public string Id { get; private set; }
    public string CodigoBarras { get; private set; }

    public string Descricao { get; private set; }
    public string Moeda { get; private set; }
    public float Preco { get; private set; }

    public ProdutoResponse() { }
}
