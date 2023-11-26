using EstagioJaAPI.Models;
using EstagioJaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using EstagioJaAPI.Exceptions;
using EstagioJaAPI.Utils;
using EstagioJaAPI.Dtos;

namespace EstagioJaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{

    private readonly IAuthService _authService;
    private readonly IEnderecoService _enderecoService;

    public AuthController(IAuthService authService, IEnderecoService enderecoService)
    {
        _authService = authService;
        _enderecoService = enderecoService;
    }

    [HttpPost("logar")]
    public ActionResult<Auth> Logar([FromBody] AuthRequestDto loginDto)
    {
        try {
            loginDto.senha = EncriptadorDeSenha.Criptografar(loginDto.senha);
            Auth login = Auth.FromAuthRequestDto(loginDto);
            login = _authService.Logar(login);
            AuthResponseDto response = Auth.ToAuthResponseDto(login); 
            return Ok(response);
        } catch (RegistroNaoEncontradoException) {
            return NotFound();
        }
    }


    [HttpPost("cadastrar-estudante")]
    public IActionResult CadastrarEstudante([FromBody] EstudanteCadastroDto estudanteDto)
    {
        Estudante estudante = Estudante.FromEstudanteCadastroDto(estudanteDto);
        Auth novoLogin = new Auth(estudante.email, estudanteDto.senha, PerfilAcesso.ESTUDANTE);
        novoLogin.senha = EncriptadorDeSenha.Criptografar(novoLogin.senha);
        _enderecoService.Inserir(estudante.endereco);
        _authService.CadastrarLogin(novoLogin);
        _authService.CadastrarEstudante(estudante);
        Console.WriteLine(estudante);
        return CreatedAtAction(nameof(CadastrarEstudante), new { id = estudante.id }, estudanteDto);  
    }

    [HttpPost("cadastrar-empresa")]
    public IActionResult CadastrarEmpresa([FromBody] EmpresaDto empresaDto)
    {
        Empresa empresa = Empresa.FromEmpresaCadastroDto(empresaDto);
        Auth novoLogin = new Auth(empresa.email, empresaDto.senha, PerfilAcesso.EMPRESA);
        novoLogin.senha = EncriptadorDeSenha.Criptografar(novoLogin.senha);
        _enderecoService.Inserir(empresa.endereco);
        _authService.CadastrarLogin(novoLogin);
        _authService.CadastrarEmpresa(empresa);
        Console.WriteLine(empresa);
        return CreatedAtAction(nameof(CadastrarEmpresa), new { id = empresa.id }, empresaDto);  
    }

    [HttpPost("alterar-senha")]
    public IActionResult AlterarLogin(AuthRequestDto authDto)
    {
        Auth auth = Auth.FromAuthRequestDto(authDto);
        auth.senha = EncriptadorDeSenha.Criptografar(auth.senha);
        _authService.AlterarLogin(auth);
        return CreatedAtAction(nameof(AlterarLogin), Auth.ToAuthResponseDto(auth));
    }

    [HttpGet("notificacoes/{idLogin}")]
    public IActionResult BuscarNotificacoes(int idLogin)
    {
        IEnumerable<Notificacao> notificacoes = _authService.BuscarNotificacoes(idLogin);
        List<NotificacaoDto> dtoList = new List<NotificacaoDto>();
        foreach (Notificacao notificacao in notificacoes)
        {
            dtoList.Add(Notificacao.ToNotificacaoDto(notificacao));
        }
        return Ok(dtoList);
    }

    [HttpGet("recuperar-senha/{email}")]
    public IActionResult BuscarEmail(string email)
    {
        return Ok(_authService.BuscarEmail(email));
    }

}