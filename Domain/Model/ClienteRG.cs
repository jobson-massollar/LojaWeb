using Domain.Model.Errors;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model;

public class ClienteRG : Cliente
{
    public string RG { get; private set; } = null!;

    protected ClienteRG() { }

    public static Result<ClienteRG> Create(string rg, CPF cpf, string nome, string email, Endereco endereco, Telefone telefone)
    {
        var erros = valida(cpf, nome, email, endereco, telefone);

        if (string.IsNullOrWhiteSpace(rg))
            erros.Add(ErroEntidade.CLIENTE_RG_INVALIDO);

        return erros.Count == 0 ? new ClienteRG
        {
            Id = Guid.NewGuid(),
            CPF = cpf,
            Nome = nome,
            Email = email,
            Endereco = endereco,
            Telefone = telefone,
            RG = rg
        } :
        erros;
    }
}
