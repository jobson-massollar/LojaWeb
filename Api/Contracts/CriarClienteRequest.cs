namespace Api.Contracts;

public record CriarClienteRequest(long Cpf, string Nome, string Email, string Password, string Logradouro, string Numero, string Complemento, string Bairro, int Cep, string Uf, int? ddd, int? telefone)
{
}
