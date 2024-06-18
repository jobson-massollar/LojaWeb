namespace Api.Contracts;

public record UFResponse
{
    public Guid Id { get; private set; }

    public string Sigla { get; private set; }

    public string Nome { get; private set; }

    public UFResponse() { }
}