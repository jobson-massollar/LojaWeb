using Api.Contracts;
using Api.ErrorHandling;
using Application.Interfaces.Entry;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Api.Controllers;

[Route("api/preferencia")]
[ApiController]
public class PreferenciaController : Controller
{
    private readonly IPreferenciaServices prefServices;
    private readonly IMapper mapper;
    private MensagemErro msgErro;

    public PreferenciaController(IPreferenciaServices prefServices, IMapper mapper, MensagemErro msgErro)
    {
        this.prefServices = prefServices;
        this.mapper = mapper;
        this.msgErro = msgErro;
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType<List<Erro>>(StatusCodes.Status400BadRequest)]
    public IActionResult CriarPreferencia(CriarPreferenciaRequest request)
    {
        var result = prefServices.CriarPreferencia(request.Descricao);

        return result.IsSuccess ?
            Ok(mapper.Map<PreferenciaResponse>(result.Value!))
            :
            BadRequest(msgErro.GerarErros(result.Errors!));
    }

    [HttpGet("{descricao}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<PreferenciaResponse>(StatusCodes.Status200OK)]
    public IActionResult RecuperarPreferenciaPorDescricao(string descricao)
    {
        var preferencia = prefServices.RecuperarPorDescricao(descricao);

        return preferencia is not null ? Ok(mapper.Map<PreferenciaResponse>(preferencia)) : NotFound();
    }

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<List<PreferenciaResponse>>(StatusCodes.Status200OK)]
    public IActionResult RecuperarTodasPreferencias()
    {
        var preferencias = prefServices.RecuperarTodas();

        return Ok(preferencias.Select(p => mapper.Map<PreferenciaResponse>(p)).ToList());
    }

    [HttpDelete("{id:guid}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<List<Erro>>(StatusCodes.Status400BadRequest)]
    public IActionResult RemoverPreferencia(Guid id)
    {
        var result = prefServices.Remover(id);

        if (result.IsSuccess)
            return result.Value! == 1 ? NoContent() : NotFound();
        else
            return BadRequest(msgErro.GerarErros(result.Errors!));
    }

    [HttpDelete("{descricao}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<List<Erro>>(StatusCodes.Status400BadRequest)]
    public IActionResult RemoverPreferencia(string descricao)
    {
        var result = prefServices.Remover(descricao);

        if (result.IsSuccess)
            return result.Value! == 1 ? NoContent() : NotFound();
        else
            return BadRequest(msgErro.GerarErros(result.Errors!));
    }
}
