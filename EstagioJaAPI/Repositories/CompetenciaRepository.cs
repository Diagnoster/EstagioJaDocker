using H = NHibernate;
using EstagioJaAPI.Models;

namespace EstagioJaAPI.Repositories;

public class CompetenciaRepository : ICompetenciaRepository
{
    private readonly H.ISession _session;

    public CompetenciaRepository(H.ISession session)
    {
        _session = session;
    }

    public Competencia BuscarPorId(int id)
    {
        return _session.Get<Competencia>(id);
    }

    public void Inserir(Competencia competencia)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Save(competencia);
            transaction.Commit();
        }
    }

    public void Atualizar(Competencia competencia)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Update(competencia);
            transaction.Commit();
        }
    }

    public void Remover(Competencia competencia)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Delete(competencia);
            transaction.Commit();
        }
    }

    public IEnumerable<Competencia> BuscarTodos()
    {
        return _session.QueryOver<Competencia>().List();
    }
    
}
