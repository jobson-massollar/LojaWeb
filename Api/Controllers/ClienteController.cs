using Api.Contracts;
using Api.ErrorHandling;
using Application.Interfaces.Entry;
using AutoMapper;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Api.Controllers;

[Route("api/cliente")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteServices clienteServices = null!;
    private readonly IMapper mapper;
    private readonly MensagemErro msgErro = null!;

    public ClienteController(IClienteServices service, IMapper mapper, MensagemErro msgErro)
    {
        this.clienteServices = service;
        this.mapper = mapper;
        this.msgErro = msgErro;
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType<List<Erro>>(StatusCodes.Status400BadRequest)]
    public IActionResult CriarCliente(CriarClienteRequest request)
    {
        var data = mapper.Map<CriarClienteData>(request);

        var result = clienteServices.CriarCliente(data);

        return result.IsSuccess ?
            CreatedAtAction(nameof(CriarCliente), mapper.Map<ClienteResponse>(result.Value!))
            :
            BadRequest(msgErro.GerarErros(result.Errors!));
    }

    [HttpGet("{cpf:long}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<ClienteResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult RecuperarClientePorCPF(long cpf)
    {
        var cliente = clienteServices.RecuperarPorCPF(cpf);

        return cliente is not null ? Ok(mapper.Map<ClienteResponse>(cliente)) : NotFound();
    }

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<List<ClienteResponse>>(StatusCodes.Status200OK)]
    public IActionResult RecuperarTodosClientes()
    {
        var clientes = clienteServices.RecuperarTodos();

        return Ok(clientes.Select(c => mapper.Map<ClienteResponse>(c)).ToList());
    }

    [HttpDelete("{id:Guid}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    public IActionResult RemoverCliente(Guid id)
    {
        return Ok(clienteServices.Remover(id));
    }

    [HttpDelete("{cpf:long}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    public IActionResult RemoverCliente(long cpf)
    {
        return Ok(clienteServices.Remover(cpf));
    }
}
