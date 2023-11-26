using EstagioJaAPI.Dtos;
using EstagioJaAPI.Models;
using EstagioJaAPI.Services;
using EstagioJaAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace EstagioJaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EstudanteController : ControllerBase
{

    private readonly IEstudanteService _estudanteService;
    private readonly IEnderecoService _enderecoService;

    public EstudanteController(IEstudanteService estudanteService, IEnderecoService enderecoService)
    {
        _estudanteService = estudanteService;
        _enderecoService = enderecoService;
    }

    [HttpGet("{id}")]
    public ActionResult<EstudanteCandidatoDto> BuscarPorId(int id)
    {
        var estudante = _estudanteService.BuscarPorId(id);
        EstudanteCandidatoDto dto = Estudante.ToEstudanteCandidatoDto(estudante);
        if (dto == null)
        {
            return NotFound();
        }

        return Ok(dto);
    }

    [HttpGet("perfil/{id}")]
    public ActionResult<EstudanteCompletoDto> BuscarDadosPerfilPorId(int id)
    {
        var estudante = _estudanteService.BuscarPorId(id);
        EstudanteCompletoDto dto = Estudante.ToEstudanteCompletoDto(estudante);
        if (dto == null)
        {
            return NotFound();
        }

        return Ok(dto);
    }

    [HttpPut]
    public IActionResult Atualizar([FromBody] EstudanteCompletoDto estudanteDto)
    {
        Estudante estudante = _estudanteService.BuscarPorId(estudanteDto.id ?? 0);
        IEnumerable<Vaga> vagas = estudante.vagas;
        int id = estudante.id;
        string email = estudante.email;
        string cpf = estudante.cpf;
        int numeroEndereco = estudante.endereco.id;
        estudanteDto.endereco.id = numeroEndereco;
        estudanteDto.cpf = cpf;
        estudante = Estudante.FromEstudanteCompletoDto(estudanteDto);
        estudante.id = id;
        estudante.vagas = vagas;
        estudante.email = email;
        _estudanteService.Atualizar(estudante);
        return CreatedAtAction(nameof(BuscarPorId), new { estudante.id }, estudanteDto);
    }

}