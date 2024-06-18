using Application.Interfaces.Entry;
using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Domain.Model.Errors;

namespace Application.Services;

public class UFServices : IUFServices
{
    private IUFRepository ufRepository;

    public UFServices(IUFRepository ufRepository) => this.ufRepository = ufRepository;

    public Result<UF> CriarUF(string sigla, string nome)
    {
        List<ErroEntidade> erros = [];

        if (ufRepository.JaExisteUF(sigla))
            erros.Add(ErroEntidade.UF_SIGLA_JA_EXISTE);

        var result = UF.Create(sigla, nome);

        if (result.hasErrors)
            erros = erros.Concat(result.Errors!).ToList();


        if (erros.Count == 0)
        {
            ufRepository.Adicionar(result.Value!);

            return result;
        }
        else
            return erros;
    }

    public UF? RecuperarPorSigla(string sigla) => ufRepository.RecuperarPorSigla(sigla);

    public List<UF> RecuperarTodas() => ufRepository.RecuperarTodos();

    public Result<int> Remover(Guid id) => ufRepository.RemoverPorId(id);

    public Result<int> Remover(string sigla) => ufRepository.RemoverPorSigla(sigla);
}
