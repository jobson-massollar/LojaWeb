namespace Api.Contracts;

public record CriarPedidoRequest(long Cpf, string Logradouro, string Numero, string Complemento, string Bairro, int Cep, string Uf, List<ItemPedidoRequest> Itens)
{
}
