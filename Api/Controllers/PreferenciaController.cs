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
    public IActionResult CriarPreferencia(string descricao)
    {
        var result = prefServices.CriarPreferencia(descricao);

        return result.IsSuccess ? 
            Ok(mapper.Map<PreferenciaResponse>(result.Value!))
            :
            BadRequest(result.Errors!);
    }

    [HttpGet("{descricao}")]
    public IActionResult RecuperarPreferenciaPorDescricao(string descricao)
    {
        var preferencia = prefServices.RecuperarPorDescricao(descricao);

        return preferencia is not null ? Ok(mapper.Map<PreferenciaResponse>(preferencia)) : NotFound();
    }

    [HttpGet("{clienteId}")]
    public IActionResult RecuperarPorCliente(Guid clienteId)
    {
        var preferencias = prefServices.RecuperarPorCliente(clienteId);

        return Ok(preferencias.Select(p => mapper.Map<PreferenciaResponse>(p)).ToList());
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
