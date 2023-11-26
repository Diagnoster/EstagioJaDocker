using H = NHibernate;
using EstagioJaAPI.Models;

namespace EstagioJaAPI.Repositories;

public class CursoRepository : ICursoRepository
{
    private readonly H.ISession _session;

    public CursoRepository(H.ISession session)
    {
        _session = session;
    }

    public Curso BuscarPorId(int id)
    {
        return _session.Get<Curso>(id);
    }

    public void Inserir(Curso curso)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Save(curso);
            transaction.Commit();
        }    
    }

    public void Atualizar(Curso curso)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Update(curso);
            transaction.Commit();
        }    
    }

    public void Remover(Curso curso)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Delete(curso);
            transaction.Commit();
        }
    }

    public IEnumerable<Curso> BuscarTodos()
    {
        return _session.QueryOver<Curso>().List();
    }
    
}
