using H = NHibernate;
using EstagioJaAPI.Models;

namespace EstagioJaAPI.Repositories;

public class EnderecoRepository : IEnderecoRepository
{

    private readonly H.ISession _session;

    public EnderecoRepository(H.ISession session)
    {
        _session = session;
    }

    public void Atualizar(Endereco endereco)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Update(endereco);
            transaction.Commit();
        }
    }

    public Endereco BuscarPorId(int id)
    {
        return _session.Get<Endereco>(id);
    }

    public void Inserir(Endereco endereco)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Save(endereco);
            transaction.Commit();
        }
    }

    public void Remover(int id)
    {
        throw new NotImplementedException();
    }
}