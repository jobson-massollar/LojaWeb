using Api.Contracts;
using Api.ErrorHandling;
using Application.Interfaces.Entry;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult CriarPreferencia(CriarPreferenciaRequest request)
    {
        var result = prefServices.CriarPreferencia(request.Descricao);

        return result.IsSuccess ? 
            Ok(mapper.Map<PreferenciaResponse>(result.Value!))
            :
            BadRequest(msgErro.GerarErros(result.Errors!));
    }

    [HttpGet("{descricao}")]
    public IActionResult RecuperarPreferenciaPorDescricao(string descricao)
    {
        var preferencia = prefServices.RecuperarPorDescricao(descricao);

        return preferencia is not null ? Ok(mapper.Map<PreferenciaResponse>(preferencia)) : NotFound();
    }

    [HttpGet("{clienteId:guid}")]
    public IActionResult RecuperarPorCliente(Guid clienteId)
    {
        var result = prefServices.RecuperarPorCliente(clienteId);

        if (result.IsSuccess)
        {
            return result.Value is not null ? 
                Ok(result.Value.Select(p => mapper.Map<PreferenciaResponse>(p)))
                :
                NotFound();
        }
        else
            return BadRequest(msgErro.GerarErros(result.Errors!));
    }

    [HttpGet]
    public IActionResult RecuperarTodasPreferencias()
    {
        var preferencias = prefServices.RecuperarTodas();

        return Ok(preferencias.Select(p => mapper.Map<PreferenciaResponse>(p)).ToList());
    }

    [HttpDelete("{id:guid}")]
    public IActionResult RemoverPreferencia(Guid id)
    {
        return Ok(prefServices.RemoverPreferencia(id));
    }

    [HttpDelete("{descricao}")]
    public IActionResult RemoverPreferencia(string descricao)
    {
        return Ok(prefServices.RemoverPreferencia(descricao));
    }
}
