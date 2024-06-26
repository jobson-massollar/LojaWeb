﻿using Application.Interfaces.Entry;
using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Domain.Model.Errors;

namespace Application.Services;

public class ClienteServices : IClienteServices
{
    private IClienteRepository clienteRepository;
    private IUFRepository ufRepository;
    private IPreferenciaRepository prefRepository;

    public ClienteServices(IClienteRepository clienteRepository, IUFRepository ufRepository, IPreferenciaRepository prefRepository)
    {
        this.clienteRepository = clienteRepository;
        this.ufRepository = ufRepository;
        this.prefRepository = prefRepository;
    }

    public Result<Cliente> CriarCliente(CriarClienteData dados)
    {
        List<ErroEntidade> erros = [];

        var uf = ufRepository.RecuperarPorSigla(dados.Uf);

        // Verifica ducplicidade de CPF
        if (clienteRepository.JaExisteCPF(dados.Cpf))
            erros.Add(ErroEntidade.CLIENTE_CPF_JA_EXISTE);

        // Verifica ducplicdade de e-mail
        if (clienteRepository.JaExisteEmail(dados.Email))
            erros.Add(ErroEntidade.CLIENTE_EMAIL_JA_EXISTE);

        // Tenta construir o cliente mesmo se houver erro de CPF ou e-mail duplicado,
        // porque podem haver outros erros de validação
        var result = new ClienteBuilder(dados.Cpf,
                                        dados.Nome,
                                        dados.Email,
                                        dados.Logradouro,
                                        dados.Numero,
                                        dados.Complemento,
                                        dados.Bairro,
                                        dados.Cep,
                                        uf)
                                .ComTelefone(dados.DDD, dados.Telefone)
                                .Build();

        // Junta os erros da validação do cliente com os demais
        if (result.hasErrors)
            erros = erros.Concat(result.Errors!).ToList();

        if (erros.Count == 0)
        {
            clienteRepository.Adicionar(result.Value!);

            return result;
        }
        else
            return erros;
    }

    public Result<List<Pedido>?> RecuperarPedidos(Guid clienteId)
    {
        return clienteRepository.RecuperarPedidos(clienteId);
    }

    public Cliente? RecuperarPorCPF(long cpf) => clienteRepository.RecuperarPorCPF(cpf);

    public Result<List<Preferencia>?> RecuperarPreferencias(Guid clienteId)
    {
        return clienteRepository.RecuperarPreferencias(clienteId);
    }

    public List<Cliente> RecuperarTodos() => clienteRepository.RecuperarTodos();

    public Result<int> Remover(Guid id) => clienteRepository.RemoverPorId(id);

    public Result<int> Remover(long cpf) => clienteRepository.RemoverPorCpf(cpf);

    public Result<bool> DefinirPreferencias(Guid clienteId, List<Guid> preferencias)
    {
        List<ErroEntidade> erros = [];

        var cliente = clienteRepository.RecuperarPorIdComPreferencias(clienteId);

        if (cliente is null)
            erros.Add(ErroEntidade.CLIENTE_NAO_ENCONTRADO);

        var prefs = prefRepository.RecuperarPorId(preferencias);

        if (prefs is null || prefs.Count != preferencias.Count)
            erros.Add(ErroEntidade.PREFERENCIA_NAO_ENCONTRADA);

        if (erros.Count == 0)
        {
            cliente!.Preferencias.Clear();
            cliente.Preferencias.AddRange(prefs!);

            clienteRepository.Atualizar(cliente);

            return true;
        }
        else
            return erros;
    }
}
