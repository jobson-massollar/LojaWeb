﻿using Domain.Model.Errors;

namespace Domain.Model;

/// <summary>
/// Builder para o Endereço
/// </summary>
public class EnderecoBuilder
{
    protected string? logradouro;
    protected string? numero;
    protected string? complemento;
    protected string? bairro;
    protected int? numeroCEP;
    protected UF? uf;

    /// <summary>
    /// Construtor que permite definir os dados do endereço de forma individual
    /// </summary>
    public EnderecoBuilder() { }

    /// <summary>
    /// Construtor que recebe os dados obrigatórios do endereço
    /// </summary>
    /// <param name="logradouro">Logradouro</param>
    /// <param name="numero">Número</param>
    /// <param name="complemento">Complemento</param>
    /// <param name="bairro">Bairro</param>
    /// <param name="numeroCEP">CEP</param>
    /// <param name="uf">UF (esse objeto vem 'pronto' porque ele é recuperado do repositório)</param>
    public EnderecoBuilder(string logradouro, string numero, string complemento, string bairro, int numeroCEP, UF uf)
    {
        this.logradouro = logradouro;
        this.numero = numero;
        this.complemento = complemento;
        this.bairro = bairro;
        this.numeroCEP = numeroCEP;
        this.uf = uf;
    }

    public EnderecoBuilder ComLogradouro(string logradouro)
    {
        this.logradouro = logradouro;
        return this;
    }

    public EnderecoBuilder ComNumero(string numero)
    {
        this.numero = numero;
        return this;
    }

    public EnderecoBuilder ComComplemento(string complemento)
    {
        this.complemento = complemento;
        return this;
    }

    public EnderecoBuilder ComBairro(string bairro)
    {
        this.bairro = bairro;
        return this;
    }

    public EnderecoBuilder ComCEP(int cep)
    {
        numeroCEP = cep;
        return this;
    }

    /// <summary>
    /// Define a UF do endereço. Diferentemente dos demais, esse objeto já vem construído porque ele
    /// deve ser gerado fora do builder.
    /// </summary>
    /// <param name="uf">UF do endereço</param>
    /// <returns>ClienteBuilder para poder implementar a fluent API</returns>
    public EnderecoBuilder ComUF(UF uf)
    {
        this.uf = uf;
        return this;
    }

    /// <summary>
    /// Cria o endereço com os dados definidos
    /// </summary>
    /// <returns>Endereço ou lista de erros</returns>
    public Result<Endereco> Build()
    {
        // Constroi o value object
        var cep = numeroCEP is int _cep ? CEP.Create(_cep) : null;

        // Constroi o endereço
        var result = Endereco.Create(logradouro, numero, complemento, bairro, cep, uf);

        return result;
    }
}
