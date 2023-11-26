using H = NHibernate;
using EstagioJaAPI.Models;
using NHibernate;
using NHibernate.Transform;

namespace EstagioJaAPI.Repositories;

public class EmpresaRepository: IEmpresaRepository {

    private readonly H.ISession _session;

    public EmpresaRepository(H.ISession session)
    {
        _session = session;
    }

    public Empresa BuscarPorEmail(string email)
    {
        ISQLQuery sql = _session.CreateSQLQuery(
            "select * from tb_empresas te join " +
            "tb_autenticacao ta on te.email_empresa = ta.email_autenticacao " + 
            "where te.email_empresa = 'empresa@estagioja.com'"
        );

        return sql.SetResultTransformer(Transformers.AliasToBean<Empresa>()).UniqueResult<Empresa>();
    }

    public Empresa BuscarPorId(int id)
    {
        var sql = _session.CreateSQLQuery(
            "select * from tb_empresas te join " +
            "tb_autenticacao ta on te.email_empresa = ta.email_autenticacao " +
            "where ta.id_autenticacao = ?"
        );
        sql.AddEntity(typeof(Empresa));
        sql.SetInt32(0, id);

        return sql.UniqueResult<Empresa>();
    }

    public Empresa BuscarPorIdEmpresa(int id)
    {
        return _session.Get<Empresa>(id);
    }

    public void Atualizar(Empresa empresa)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Merge(empresa.endereco);
            _session.Merge(empresa);
            transaction.Commit();
        }
    }

}