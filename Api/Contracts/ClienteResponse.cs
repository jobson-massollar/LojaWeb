namespace Api.Contracts;

public class ClienteResponse
{
    public Guid Id { get; private set; }
    public string Cpf { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Logradouro { get; private set; }
    public string Numero { get; private set; }
    public string Complemento { get; private set; }
    public string Bairro { get; private set; }
    public string Cep { get; private set; }
    public string Uf { get; private set; }
    public string DDD { get; private set; }
    public string Telefone { get; private set; }

    public ClienteResponse() { }
}
