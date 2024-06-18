namespace Api.Contracts;

public record PreferenciaResponse
{
    public string Id { get; private set; }

    public string Descricao { get; private set; }

    public PreferenciaResponse() { }
}
