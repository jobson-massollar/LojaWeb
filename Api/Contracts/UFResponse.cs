namespace Api.Contracts;

public class UFResponse
{
    public Guid Id { get; private set; }

    public string Sigla { get; private set; }

    public string Nome { get; private set; }

    public UFResponse() { }
}