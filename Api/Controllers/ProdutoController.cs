using Api.Contracts;
using Api.ErrorHandling;
using Application.Interfaces.Entry;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult CriarProduto(CriarProdutoRequest request)
    {
        var data = mapper.Map<CriarProdutoData>(request);

        var result = produtoServices.CriarProduto(data);

        return result.IsSuccess ?
            CreatedAtAction(nameof(CriarProduto), result.Value!)
            :
            BadRequest(msgErro.GerarErros(result.Errors!));
    }

    [HttpGet("{codigo}")]
    public IActionResult RecuperarProdutoPorCodigo(string codigo)
    {
        var produto = produtoServices.RecuperarPorCodigo(codigo);

        return produto is not null ? Ok(mapper.Map<ProdutoResponse>(produto)) : NotFound();
    }

    [HttpGet]
    public IActionResult RecuperarTodosProdutos()
    {
        var produtos = produtoServices.RecuperarTodos();

        return Ok(produtos.Select(p => mapper.Map<ProdutoResponse>(p)).ToList());
    }

    [HttpDelete("{id:guid}")]
    public IActionResult RemoverProduto(Guid id)
    {
        return Ok(produtoServices.RemoverProduto(id));
    }

    [HttpDelete("{codigo}")]
    public IActionResult RemoverProduto(string codigo)
    {
        return Ok(produtoServices.RemoverProduto(codigo));
    }
}
