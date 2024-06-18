namespace Api.Contracts;

public record CriarPedidoData(long Cpf, string Logradouro, string Numero, string Complemento, string Bairro, int Cep, string Uf, List<ItemPedidoData> Itens)
{
}
