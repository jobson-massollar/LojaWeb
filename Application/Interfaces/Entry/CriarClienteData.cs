namespace Application.Interfaces.Entry;

public record CriarClienteData
{
    public long Cpf { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Logradouro { get; private set; }
    public string Numero { get; private set; }
    public string Complemento { get; private set; }
    public string Bairro { get; private set; }
    public int Cep { get; private set; }
    public string Uf { get; private set; }

    public CriarClienteData() { }
}
