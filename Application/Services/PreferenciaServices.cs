using Application.Interfaces.Entry;
using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Domain.Model.Errors;

namespace Application.Services;

public class PreferenciaServices : IPreferenciaServices
{
    private readonly IPreferenciaRepository preferenciaRepository;

    public PreferenciaServices(IPreferenciaRepository preferenciaRepository)
    {
        this.preferenciaRepository = preferenciaRepository;
    }

    public Result<Preferencia> CriarPreferencia(string descricao)
    {
        var preferencia = preferenciaRepository.RecuperarPorDescricao(descricao);

        if (preferencia is not null)
            return (List<ErroEntidade>)[ErroEntidade.PREFERENCIA_DESCRICAO_JA_EXISTE];

        var result = Preferencia.Create(descricao);

        if (result.IsSuccess)
            preferenciaRepository.Add(result.Value!);

        return result;
    }

    public Preferencia? RecuperarPorDescricao(string descricao)
    {
        return preferenciaRepository.RecuperarPorDescricao(descricao);
    }

    public Result<List<Preferencia>?> RecuperarPorCliente(Guid clienteId)
    {
        return preferenciaRepository.RecuperarPorCliente(clienteId);
    }

    public List<Preferencia> RecuperarTodas()
    {
        return preferenciaRepository.RecuperarTodas();
    }

    public int RemoverPreferencia(Guid id)
    {
       return preferenciaRepository.Remove(id);
    }

    public int RemoverPreferencia(string descricao)
    {
        return preferenciaRepository.Remove(descricao);
    }
}
