using H = NHibernate;
using EstagioJaAPI.Models;
using NHibernate;
using NHibernate.Transform;

namespace EstagioJaAPI.Repositories;

public class EstudanteRepository : IEstudanteRepository
{

    private readonly H.ISession _session;

    public EstudanteRepository(H.ISession session)
    {
        _session = session;
    }

    public Estudante BuscarPorEmail(string email)
    {
        ISQLQuery sql = _session.CreateSQLQuery(
            "select * from tb_estudantes te join " +
            "tb_autenticacao ta on te.email_estudante = ta.email_autenticacao " +
            "where te.email_empresa = 'empresa@estagioja.com'"
        );

        return sql.SetResultTransformer(Transformers.AliasToBean<Estudante>()).UniqueResult<Estudante>();
    }

    public Estudante BuscarPorId(int id)
    {
        var sql = _session.CreateSQLQuery(
            "select * from tb_estudantes te join " +
            "tb_autenticacao ta on te.email_estudante = ta.email_autenticacao " +
            "where ta.id_autenticacao = ?"
        );
        sql.AddEntity(typeof(Estudante));
        sql.SetInt32(0, id);

        return sql.UniqueResult<Estudante>();
    }

    public Estudante BuscarPorIdEstudante(int id)
    {
        return _session.Get<Estudante>(id);
    }

    public void Atualizar(Estudante estudante)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Merge(estudante.endereco);
            _session.Merge(estudante);
            transaction.Commit();
        }
    }

    public Auth BuscarLoginEstudante(int idEstudante)
    {
        var sql = _session.CreateSQLQuery(
            "SELECT a.* FROM tb_estudantes e JOIN " +
            "tb_autenticacao a ON e.email_estudante = a.email_autenticacao " +
            "WHERE e.id_estudante = ?"
        );
        sql.AddEntity(typeof(Auth));
        sql.SetInt32(0, idEstudante);

        return sql.UniqueResult<Auth>();
    }

}
