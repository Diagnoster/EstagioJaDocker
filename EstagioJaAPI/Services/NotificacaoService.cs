using EstagioJaAPI.Models;
using EstagioJaAPI.Repositories;

namespace EstagioJaAPI.Services
{
    public class NotificacaoService: INotificacaoService
    {

        private readonly INotificacaoRepository _notificacaoRepository;

        public NotificacaoService(INotificacaoRepository notificacaoRepository)
        {
            _notificacaoRepository = notificacaoRepository;
        }

        public void Inserir(Notificacao notificacao)
        {
            _notificacaoRepository.Inserir(notificacao);
        }

    }
}
