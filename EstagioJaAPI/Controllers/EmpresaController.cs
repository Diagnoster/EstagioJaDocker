using EstagioJaAPI.Dtos;
using EstagioJaAPI.Models;
using EstagioJaAPI.Services;
using EstagioJaAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace EstagioJaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EmpresaController : ControllerBase
{

    private readonly IEmpresaService _empresaService;

    public EmpresaController(IEmpresaService empresaService)
    {
        _empresaService = empresaService;
    }

    [HttpGet("{id}")]
    public ActionResult<EmpresaCompletoDto> BuscarPorId(int id)
    {
        var empresa = _empresaService.BuscarPorId(id);

        if (empresa == null)
        {
            return NotFound();
        }

        return Ok(Empresa.ToEmpresaCompletoDto(empresa));
    }

    [HttpGet("empresaId/{id}")]
    public ActionResult<EmpresaCompletoDto> BuscarPorIdEmpresa(int id)
    {
        var empresa = _empresaService.BuscarPorIdEmpresa(id);

        if (empresa == null)
        {
            return NotFound();
        }

        return Ok(Empresa.ToEmpresaCompletoDto(empresa));
    }

    [HttpGet("perfil/{id}")]
    public ActionResult<EmpresaDto> BuscarPerfilCompletoPorId(int id)
    {
        var empresa = _empresaService.BuscarPorId(id);

        if (empresa == null)
        {
            return NotFound();
        }

        return Ok(Empresa.ToEmpresaCompletoDto(empresa));
    }

    [HttpPut]
    public IActionResult Atualizar([FromBody] EmpresaCompletoDto empresaDto)
    {
        Empresa empresa = _empresaService.BuscarPorId(empresaDto.id ?? 0);
        IEnumerable<Vaga> vagas = empresa.vagas;
        int id = empresa.id;
        int enderecoId = empresa.endereco.id;
        empresaDto.endereco.id = enderecoId;
        empresa = Empresa.FromEmpresaCompletoDto(empresaDto);
        empresa.id = id;
        empresa.vagas = vagas;
        _empresaService.Atualizar(empresa);
        return CreatedAtAction(nameof(BuscarPorId), new { empresa.id }, empresaDto);
    }

}