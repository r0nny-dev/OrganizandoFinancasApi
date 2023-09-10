using Microsoft.AspNetCore.Mvc;
using OrganizingFinances.DTOs;
using OrganizingFinances.Entities;
using OrganizingFinances.Repositories;
using OrganizingFinances.Repositories.Interfaces;

namespace OrganizingFinances.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RegistroDividaController : ControllerBase
{
    private readonly IRegistroDividaRepository _repository;

    public RegistroDividaController(IRegistroDividaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("/")]
    public ActionResult<IEnumerable<RegistroDividaDTO>> GetAll()
    {
        var registroDividas = _repository.GetAll();

        if (registroDividas is null)
            return NotFound("Nenhum cadastrado.");

        return Ok(registroDividas);
    }

    [HttpGet("/{IdRegistro}")]
    public ActionResult<RegistroDividaDTO> GetById(Guid IdRegistro)
    {
        var registroDividaDTO = _repository.GetById(IdRegistro);

        if (registroDividaDTO == null)
            return NotFound("Registro Dívida não encontrado.");
    
        return Ok(registroDividaDTO);
    }

    [HttpPost("/cadastro")]
    public IActionResult CreateRegistro([FromBody] RegistroDividaDTO registroDividaDTO)
    {
        if (registroDividaDTO == null)
            return BadRequest();

        _repository.Insert(registroDividaDTO);

        return CreatedAtAction(nameof(CreateRegistro),registroDividaDTO);
    }

    [HttpPut("/atualizar/{IdRegistro}")]
    public IActionResult UpdateRegistro(Guid IdRegistro, [FromBody] RegistroDividaDTO registroDividaDTO)
    {
        if ((IdRegistro != registroDividaDTO.IdRegistro) || (registroDividaDTO == null))
            return BadRequest();
        
        _repository.Update(registroDividaDTO);

        return NoContent();
    }

    [HttpDelete("/remover/{IdRegistro}")]
    public IActionResult DeleteRegistro(Guid IdRegistro)
    {
        var registroDividaDTO = _repository.GetById(IdRegistro);

        if (registroDividaDTO is null)
            return NotFound("Registro Dívida não encontrado.");

        _repository.Delete(IdRegistro);

        return NoContent();
    }
}
