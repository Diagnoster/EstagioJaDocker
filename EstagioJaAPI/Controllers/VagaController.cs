using System.Collections.Generic;
using System.Collections.Immutable;
using EstagioJaAPI.Dtos;
using EstagioJaAPI.Exceptions;
using EstagioJaAPI.Models;
using EstagioJaAPI.Services;
using EstagioJaAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace EstagioJaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class VagaController : ControllerBase
{

    private readonly IVagaService _vagaService;
    private readonly IEmpresaService _empresaService;
    private readonly IEstudanteService _estudanteService;
    private readonly INotificacaoService _notificacaoService;

    public VagaController(IVagaService vagaService, IEmpresaService empresaService, IEstudanteService estudanteService, INotificacaoService notificacaoService)
    {
        _vagaService = vagaService;
        _empresaService = empresaService;
        _estudanteService = estudanteService;
        _notificacaoService = notificacaoService;
    }

    [HttpPut]
    public IActionResult Atualizar([FromBody] VagaDto vagaDto)
    {
        Vaga vaga = Vaga.FromVagaDto(vagaDto);
        vaga.empresa = _empresaService.BuscarPorId(vagaDto.idEmpresa);
        _vagaService.Atualizar(vaga);
        return CreatedAtAction(nameof(BuscarPorId), new { vaga.id }, vaga);
    }

    [HttpGet("{id}")]
    public ActionResult<VagaDto> BuscarPorId(int id)
    {
        var vaga = _vagaService.BuscarPorId(id);
        VagaDto dto = Vaga.ToVagaDto(vaga);
        if (dto == null)
        {
            return NotFound();
        }

        return Ok(dto);
    }

    [HttpGet("by-id-empresa/{id}")]
    public ActionResult<IEnumerable<VagaCandidaturaDto>> BuscarVagasPorIdLoginEmpresa(int id)
    {
        var vagas = _vagaService.BuscarVagasPorIdLoginEmpresa(id);

        IList<VagaCandidaturaDto> vagasDto = new List<VagaCandidaturaDto>();
        foreach (Vaga vaga in vagas)
        {
            vagasDto.Add(Vaga.ToVagaCandidaturaDto(vaga));
        }

        return Ok(vagasDto);
    }

    [HttpGet("finalizadas-by-id-empresa/{id}")]
    public ActionResult<IEnumerable<VagaCandidaturaDto>> BuscarVagasFinalizadasPorIdLoginEmpresa(int id)
    {
        var vagas = _vagaService.BuscarVagasFinalizadasPorIdLoginEmpresa(id);

        IList<VagaCandidaturaDto> vagasDto = new List<VagaCandidaturaDto>();
        foreach (Vaga vaga in vagas)
        {
            vagasDto.Add(Vaga.ToVagaCandidaturaDto(vaga));
        }

        return Ok(vagasDto);
    }

    [HttpGet("visualizar-vaga/{id}")]
    public ActionResult<VagaCandidaturaDto> BuscarVagaParaCandidatura(int id)
    {
        var vaga = _vagaService.BuscarPorId(id);
        VagaCandidaturaDto dto = Vaga.ToVagaCandidaturaDto(vaga);
        if (dto == null)
        {
            return NotFound();
        }

        return Ok(dto);
    }

    [HttpPost("candidatar")]
    public IActionResult RegistrarCandidatura([FromBody] CandidaturaDto dto)
    {
        Estudante estudante = _estudanteService.BuscarPorId(dto.idEstudante);
        Vaga vaga = _vagaService.BuscarPorId(dto.idVaga);
        dto.idEstudante = estudante.id;
        _vagaService.Candidatar(dto);
        NotificacaoDto notificacaoDto = new NotificacaoDto(null, "Sua candidatura na vaga " + vaga.descricao + " foi registrada!", dto.idEstudante);
        Notificacao notificacao = Notificacao.FromNotificacaoDto(notificacaoDto);
        notificacao.usuario = new Auth();
        notificacao.usuario.id = _estudanteService.BuscarLoginEstudante(dto.idEstudante).id;
        _notificacaoService.Inserir(notificacao);

        return StatusCode(201);
    }

    [HttpGet]
    public ActionResult<IEnumerable<VagaCandidaturaDto>> BuscarTodos()
    {
        IEnumerable<Vaga> vagas = _vagaService.BuscarTodos();
        IList<VagaCandidaturaDto> vagasDto = new List<VagaCandidaturaDto>();
        foreach (Vaga vaga in vagas)
        {
            vagasDto.Add(Vaga.ToVagaCandidaturaDto(vaga));
        }
        return Ok(vagasDto);
    }

    [HttpPost]
    public IActionResult Inserir([FromBody] VagaDto vagaDto)
    {
        Vaga vaga = Vaga.FromVagaDto(vagaDto);
        vaga.empresa = _empresaService.BuscarPorId(vagaDto.idEmpresa);
        _vagaService.Inserir(vaga);
        return CreatedAtAction(nameof(BuscarPorId), new { vaga.id }, vaga);
    }

    [HttpDelete("{id}")]
    public IActionResult Remover(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("candidatos-vaga/{idVaga}")]
    public ActionResult<IEnumerable<EstudanteCandidatoDto>> BuscarCandidatos(int idVaga)
    {
        try
        {
            IEnumerable <Estudante> candidatos = _vagaService.BuscarCandidatos(idVaga);
            IEnumerable<EstudanteCandidatoDto> response = Estudante.ToEstudanteCandidatoDtoList(candidatos);
            return Ok(response);
        }
        catch (RegistroNaoEncontradoException)
        {
            return NotFound();
        }
    }

    [HttpPost("aprovar-candidato")]
    public IActionResult AprovarCandidato([FromBody] CandidaturaComEmpresaDto dto)
    {
        Estudante estudante = _estudanteService.BuscarPorIdEstudante(dto.idEstudante);
        Vaga vaga = _vagaService.BuscarPorId(dto.idVaga);
        dto.idEstudante = estudante.id;
        NotificacaoDto notificacaoDto = new NotificacaoDto(null, "Você foi aprovado na vaga " + vaga.descricao + " !. Aguarde o Contato da empresa por email ou telefone.", dto.idEstudante);
        Notificacao notificacao = Notificacao.FromNotificacaoDto(notificacaoDto);
        notificacao.usuario = new Auth();
        notificacao.usuario.id = _estudanteService.BuscarLoginEstudante(dto.idEstudante).id;
        _notificacaoService.Inserir(notificacao);

        notificacaoDto = new NotificacaoDto(null, "O estudante " + estudante.nome + 
            " foi aprovado na vaga " + vaga.descricao + ". Entre em contato pelo email " + estudante.email + " ou telefone " + estudante.telefone, dto.idEmpresa);
        Notificacao notificacaoEmpresa = Notificacao.FromNotificacaoDto(notificacaoDto);
        notificacaoEmpresa.usuario = new Auth();
        notificacaoEmpresa.usuario.id = notificacaoDto.idUsuario;
        _notificacaoService.Inserir(notificacaoEmpresa);

        _vagaService.AprovarCandidato(new CandidaturaDto(dto.idVaga, dto.idEstudante));
        return Ok();
    }

    [HttpPost("rejeitar-candidato")]
    public IActionResult RejeitarCandidato([FromBody] CandidaturaDto dto)
    {
        Estudante estudante = _estudanteService.BuscarPorIdEstudante(dto.idEstudante);
        Vaga vaga = _vagaService.BuscarPorId(dto.idVaga);
        dto.idEstudante = estudante.id;
        NotificacaoDto notificacaoDto = new NotificacaoDto(null, "Infelizmente sua candidatura na vaga " + vaga.descricao + " foi rejeitada. Não desista! Continue aprimorando suas habilidades!", dto.idEstudante);
        Notificacao notificacao = Notificacao.FromNotificacaoDto(notificacaoDto);
        notificacao.usuario = new Auth();
        notificacao.usuario.id = _estudanteService.BuscarLoginEstudante(dto.idEstudante).id;
        _notificacaoService.Inserir(notificacao);
        _vagaService.RejeitarCandidato(dto);
        return Ok();
    }

    [HttpPost("retirar-candidatura")]
    public IActionResult RetirarCandidatura([FromBody] CandidaturaDto dto)
    {
        Estudante estudante = _estudanteService.BuscarPorId(dto.idEstudante);
        Vaga vaga = _vagaService.BuscarPorId(dto.idVaga);
        dto.idEstudante = estudante.id;
        NotificacaoDto notificacaoDto = new NotificacaoDto(null, "Sua candidatura na vaga " + vaga.descricao + " foi retirada.", dto.idEstudante);
        Notificacao notificacao = Notificacao.FromNotificacaoDto(notificacaoDto);
        notificacao.usuario = new Auth();
        notificacao.usuario.id = _estudanteService.BuscarLoginEstudante(dto.idEstudante).id;
        _notificacaoService.Inserir(notificacao);
        _vagaService.RejeitarCandidato(dto);
        return Ok();
    }

    [HttpGet("buscar-por-candidato/{id}")]
    public ActionResult<IEnumerable<VagaCandidaturaDto>> BuscarVagas(int id)
    {
        var estudante = _estudanteService.BuscarPorId(id);

        if (estudante == null)
        {
            return NotFound();
        }

        IList<VagaCandidaturaDto> vagasDto = new List<VagaCandidaturaDto>();
        foreach (Vaga vaga in estudante.vagas)
        {
            vagasDto.Add(Vaga.ToVagaCandidaturaDto(vaga));
        }

        return Ok(vagasDto);
    }

    [HttpGet("finalizar-vaga/{id}")]
    public IActionResult finalizarVaga(int id)
    {
        _vagaService.finalizarVaga(id);
        return StatusCode(201, id);
    }

    [HttpGet("recomendadas/{id}")]
    public ActionResult<IEnumerable<VagaCandidaturaDto>> BuscarVagasRecomendadas(int id)
    {
        Estudante estudante = _estudanteService.BuscarPorId(id);
        IEnumerable<Vaga> vagas = _vagaService.BuscarTodos();
        IList<VagaCandidaturaDto> vagasDto = new List<VagaCandidaturaDto>();
        IList<VagaCandidaturaDto> response = new List<VagaCandidaturaDto>();
        foreach (Vaga vaga in vagas)
        {
            vagasDto.Add(Vaga.ToVagaCandidaturaDto(vaga));
        }
        foreach (VagaCandidaturaDto vaga in vagasDto)
        {
            if (!vaga.idEstudantes.Contains(estudante.id))
                response.Add(vaga);
        }
        return Ok(response);
    }
}