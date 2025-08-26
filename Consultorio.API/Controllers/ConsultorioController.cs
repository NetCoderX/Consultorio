using Consultorio.API.DTOs.Consultorios;
using Consultorio.Application.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using Consultorio.Application.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;
using Consultorio.Application.Utilidades.Mediador;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.API.Controllers;
[Route("api/consultorios")]
[ApiController]
public class ConsultorioController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultorioController(IMediator mediator)
    {
        _mediator = mediator;   
    }

    [HttpPost]
    public async Task<IActionResult> Post(CrearConsultorioDTO crearConsultorioDTO)
    {
        var comando = new ComandoCrearConsultorio { Nombre = crearConsultorioDTO.Nombre};
        var resultado = await _mediator.Send(comando);
        return Ok(resultado);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new ConsultaObtenerDetalleConsultorio { Id = id };
        var resultado = await _mediator.Send(query);
        return Ok(resultado);
    }
}
