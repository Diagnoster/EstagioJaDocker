using EstagioJaAPI.Models;
using H = NHibernate;

namespace EstagioJaAPI.Repositories
{
    public class NotificacaoRepository: INotificacaoRepository
    {

        private readonly H.ISession _session;

        public NotificacaoRepository(H.ISession session)
        {
            _session = session;
        }

        public void Inserir(Notificacao notificacao)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(notificacao);
                transaction.Commit();
            }
        }

    }
}
