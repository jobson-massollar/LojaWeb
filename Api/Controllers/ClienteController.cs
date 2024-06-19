using Api.Contracts;
using Api.ErrorHandling;
using Application.Interfaces.Entry;
using AutoMapper;
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
    [ProducesResponseType<List<Erro>>(StatusCodes.Status422UnprocessableEntity)]
    public IActionResult CriarCliente(CriarClienteRequest request)
    {
        var data = mapper.Map<CriarClienteData>(request);

        var result = clienteServices.CriarCliente(data);

        return result.IsSuccess ?
            CreatedAtAction(nameof(CriarCliente), mapper.Map<ClienteResponse>(result.Value!))
            :
            UnprocessableEntity(msgErro.GerarErros(result.Errors!));
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<List<Erro>>(StatusCodes.Status409Conflict)]
    public IActionResult RemoverCliente(Guid id)
    {
        var result = clienteServices.Remover(id);

        if (result.IsSuccess)
            return result.Value! == 1 ? NoContent() : NotFound();
        else
            return Conflict(msgErro.GerarErros(result.Errors!));
    }

    [HttpDelete("{cpf:long}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<List<Erro>>(StatusCodes.Status409Conflict)]
    public IActionResult RemoverCliente(long cpf)
    {
        var result = clienteServices.Remover(cpf);

        if (result.IsSuccess)
            return result.Value! == 1 ? NoContent() : NotFound();
        else
            return Conflict(msgErro.GerarErros(result.Errors!));
    }

    [HttpGet("{clienteId:guid}/preferencias")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<List<PreferenciaResponse>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult RecuperarPreferencias(Guid clienteId)
    {
        var result = clienteServices.RecuperarPreferencias(clienteId);

        return result.IsSuccess ?
            Ok(result.Value!.Select(p => mapper.Map<PreferenciaResponse>(p)))
            :
            NotFound(msgErro.GerarErros(result.Errors!));
    }

    [HttpPost("{clienteId:guid}/preferencias")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<List<Erro>>(StatusCodes.Status422UnprocessableEntity)]
    public IActionResult DefinirPreferencias(Guid clienteId, DefinirPreferenciasRequest request)
    {
        var result = clienteServices.DefinirPreferencias(clienteId, request.preferencias);

        return result.IsSuccess ?
            Ok()
            :
            UnprocessableEntity(msgErro.GerarErros(result.Errors!));
    }

    [HttpGet("{clienteId:guid}/pedidos")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<List<PedidoResponse>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult RecuperarPedidos(Guid clienteId)
    {
        var result = clienteServices.RecuperarPedidos(clienteId);

        return result.IsSuccess ?
            Ok(result.Value!.Select(p => mapper.Map<PedidoResponse>(p)))
            :
            NotFound(msgErro.GerarErros(result.Errors!));
    }
}
