using Application.Interfaces.Entry;
using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Domain.Model.Errors;

namespace Application.Services;

public class ClienteServices : IClienteServices
{
    private IClienteRepository clienteRepository;
    private IUFRepository ufRepository;

    public ClienteServices(IClienteRepository clienteRepository, IUFRepository ufRepository)
    {
        this.clienteRepository = clienteRepository;
        this.ufRepository = ufRepository;
    }

    public Result<Cliente> CriarCliente(CriarClienteData dadosCliente)
    {
        List<ErroEntidade> erros = [];

        var uf = ufRepository.RecuperarPorSigla(dadosCliente.Uf);

        // Verifica ducplicidade de CPF
        if (clienteRepository.JaExisteCPF(dadosCliente.Cpf))
            erros.Add(ErroEntidade.CLIENTE_CPF_JA_EXISTE);

        // Verifica ducplicdade de e-mail
        if (clienteRepository.JaExisteEmail(dadosCliente.Email))
            erros.Add(ErroEntidade.CLIENTE_EMAIL_JA_EXISTE);

        // Tenta construir o cliente mesmo se houver erro de CPF ou e-mail duplicado,
        // porque podem haver outros erros de validação
        var resultCliente = new ClienteBuilder(dadosCliente.Cpf,
                                               dadosCliente.Nome,
                                               dadosCliente.Email,
                                               dadosCliente.Logradouro,
                                               dadosCliente.Numero,
                                               dadosCliente.Complemento,
                                               dadosCliente.Bairro,
                                               dadosCliente.Cep,
                                               uf).Build();

        // Junta os erros da validação do cliente com os demais
        if (resultCliente.hasErrors)
            erros = erros.Concat(resultCliente.Errors!).ToList();


        if (erros.Count == 0)
        {
            clienteRepository.Add(resultCliente.Value!);

            return resultCliente.Value!;
        }
        else
            return erros;
    }

    public Cliente? RecuperarPorCPF(long cpf) => clienteRepository.RecuperarPorCPF(cpf);

    public List<Cliente> RecuperarTodos() => clienteRepository.RecuperarTodos();

    public int Remover(Guid id) => clienteRepository.Remove(id);

    public int Remover(long cpf) => clienteRepository.Remove(cpf);
}
