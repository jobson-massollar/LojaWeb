namespace Api.Contracts;

public record ProdutoResponse
{
    public string Id { get; private set; }
    public string Descricao { get; private set; }
    public string Moeda {  get; private set; }
    public float Preco {  get; private set; }

    public ProdutoResponse() { }
}
