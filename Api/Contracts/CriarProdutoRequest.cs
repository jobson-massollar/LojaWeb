namespace Api.Contracts;

public record CriarProdutoRequest(string CodigoBarras, string Descricao, string Moeda, float Preco)
{
}
