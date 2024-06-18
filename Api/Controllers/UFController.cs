using Api.Contracts;
using Api.ErrorHandling;
using Application.Interfaces.Entry;
using Application.Services;
using AutoMapper;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Api.Controllers;

[Route("api/uf")]
[ApiController]

public class UFController : Controller
{
    private IUFServices ufServices;
    private readonly IMapper mapper;
    private readonly MensagemErro msgErro = null!;

    public UFController(IUFServices ufServices, IMapper mapper, MensagemErro msgErro)
    {
        this.ufServices = ufServices;
        this.mapper = mapper;
        this.msgErro = msgErro;
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType<List<Erro>>(StatusCodes.Status400BadRequest)]
    public IActionResult CriarUF(CriarUFRequest request)
    {
        var result = ufServices.CriarUF(request.Sigla, request.Nome);

        return result.IsSuccess ?
            CreatedAtAction(nameof(CriarUF), mapper.Map<UFResponse>(result.Value!))
            :
            BadRequest(msgErro.GerarErros(result.Errors!));
    }

    [HttpGet("{sigla}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<List<UFResponse>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult RecuperarUFPorSigla(string sigla)
    {
        var uf = ufServices.RecuperarPorSigla(sigla);

        return uf is not null ? Ok(mapper.Map<UFResponse>(uf)) : NotFound();
    }

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<List<UFResponse>>(StatusCodes.Status200OK)]
    public IActionResult RecuperarTodasUFs()
    {
        return Ok(ufServices.RecuperarTodas().Select(uf => mapper.Map<UFResponse>(uf)));
    }

    [HttpDelete("{id:Guid}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    public IActionResult RemoverUF(Guid id)
    {
        return Ok(ufServices.Remover(id));
    }

    [HttpDelete("{sigla}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    public IActionResult RemoverUF(string sigla)
    {
        return Ok(ufServices.Remover(sigla));
    }
}
