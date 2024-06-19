using Api.Contracts;
using Api.ErrorHandling;
using Application.Interfaces.Entry;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Api.Controllers;

[Route("api/pedido")]
[ApiController]
public class PedidoController : Controller
{
    private readonly IPedidoServices pedidoServices;
    private readonly IMapper mapper;
    private readonly MensagemErro msgErro;

    public PedidoController(IPedidoServices pedidoServices, IMapper mapper, MensagemErro msgErro)
    {
        this.pedidoServices = pedidoServices;
        this.mapper = mapper;
        this.msgErro = msgErro;
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType<List<Erro>>(StatusCodes.Status422UnprocessableEntity)]
    public IActionResult CriarPedido(CriarPedidoRequest request)
    {
        var data = mapper.Map<CriarPedidoData>(request);

        var result = pedidoServices.CriarPedido(data);

        return result.IsSuccess ?
            CreatedAtAction(nameof(CriarPedido), mapper.Map<PedidoResponse>(result.Value!))
            :
            UnprocessableEntity(msgErro.GerarErros(result.Errors!));
    }

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<List<PedidoResponse>>(StatusCodes.Status200OK)]
    public IActionResult RecuperarTodosPedidoss()
    {
        var pedidos = pedidoServices.RecuperarTodos();

        return Ok(pedidos.Select(p => mapper.Map<PedidoResponse>(p)).ToList());
    }

    [HttpDelete("{id:Guid}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<List<Erro>>(StatusCodes.Status409Conflict)]
    public IActionResult RemoverPedido(Guid id)
    {
        var result = pedidoServices.Remover(id);

        if (result.IsSuccess)
            return result.Value! == 1 ? NoContent() : NotFound();
        else
            return Conflict(msgErro.GerarErros(result.Errors!));
    }
}
