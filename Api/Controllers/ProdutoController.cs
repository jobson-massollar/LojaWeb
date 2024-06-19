using Api.Contracts;
using Api.ErrorHandling;
using Application.Interfaces.Entry;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Api.Controllers;

[Route("api/produto")]
[ApiController]
public class ProdutoController : Controller
{
    private readonly IProdutoServices produtoServices;
    private readonly IMapper mapper;
    private readonly MensagemErro msgErro;

    public ProdutoController(IProdutoServices produtoServices, IMapper mapper, MensagemErro msgErro)
    {
        this.produtoServices = produtoServices;
        this.mapper = mapper;
        this.msgErro = msgErro;
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType<List<Erro>>(StatusCodes.Status422UnprocessableEntity)]
    public IActionResult CriarProduto(CriarProdutoRequest request)
    {
        var data = mapper.Map<CriarProdutoData>(request);

        var result = produtoServices.CriarProduto(data);

        return result.IsSuccess ?
            CreatedAtAction(nameof(CriarProduto), result.Value!)
            :
            UnprocessableEntity(msgErro.GerarErros(result.Errors!));
    }

    [HttpGet("{codigo}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<ProdutoResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult RecuperarProdutoPorCodigo(string codigo)
    {
        var produto = produtoServices.RecuperarPorCodigo(codigo);

        return produto is not null ? Ok(mapper.Map<ProdutoResponse>(produto)) : NotFound();
    }

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<List<ProdutoResponse>>(StatusCodes.Status200OK)]
    public IActionResult RecuperarTodosProdutos()
    {
        var produtos = produtoServices.RecuperarTodos();

        return Ok(produtos.Select(p => mapper.Map<ProdutoResponse>(p)).ToList());
    }

    [HttpDelete("{id:guid}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<List<Erro>>(StatusCodes.Status409Conflict)]
    public IActionResult RemoverProduto(Guid id)
    {
        var result = produtoServices.Remover(id);

        if (result.IsSuccess)
            return result.Value! == 1 ? NoContent() : NotFound();
        else
            return Conflict(msgErro.GerarErros(result.Errors!));
    }

    [HttpDelete("{codigo}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<List<Erro>>(StatusCodes.Status409Conflict)]
    public IActionResult RemoverProduto(string codigo)
    {
        var result = produtoServices.Remover(codigo);

        if (result.IsSuccess)
            return result.Value! == 1 ? NoContent() : NotFound();
        else
            return Conflict(msgErro.GerarErros(result.Errors!));
    }
}
