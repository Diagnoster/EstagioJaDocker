using EstagioJaAPI.Dtos;
using EstagioJaAPI.Models;
using EstagioJaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstagioJaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificacaoController: ControllerBase
    {

        private readonly INotificacaoService _notificacaoService;

        public NotificacaoController(INotificacaoService notificacaoService)
        {
            _notificacaoService = notificacaoService;
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] NotificacaoDto notificacaoDto)
        {
            Notificacao notificacao = Notificacao.FromNotificacaoDto(notificacaoDto);
            notificacao.usuario = new Auth();
            notificacao.usuario.id = notificacaoDto.idUsuario;
            _notificacaoService.Inserir(notificacao);
            return CreatedAtAction(nameof(Inserir),new { notificacaoDto.id }, notificacaoDto);
        }

    }
}
