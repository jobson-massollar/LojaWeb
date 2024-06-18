using Api.Contracts;
using Api.ErrorHandling;
using Application.Interfaces.Entry;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult CriarPedido(CriarPedidoRequest request)
    {
        var data = mapper.Map<CriarPedidoData>(request);

        var result = pedidoServices.CriarPedido(data);

        return result.IsSuccess ?
            CreatedAtAction(nameof(CriarPedido), mapper.Map<PedidoResponse>(result.Value!)) 
            : 
            BadRequest(msgErro.GerarErros(result.Errors!));
    }
}
