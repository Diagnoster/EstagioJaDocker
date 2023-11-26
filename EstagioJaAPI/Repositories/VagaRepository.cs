using H = NHibernate;
using EstagioJaAPI.Models;
using EstagioJaAPI.Dtos;
using NHibernate.Transform;
using NHibernate;
using System.Collections.Generic;
using EstagioJaAPI.Exceptions;
using System.Transactions;

namespace EstagioJaAPI.Repositories;

public class VagaRepository : IVagaRepository
{
    private readonly H.ISession _session;

    public VagaRepository(H.ISession session)
    {
        _session = session;
    }

    public Vaga BuscarPorId(int id)
    {
        return _session.Get<Vaga>(id);
    }

    public IEnumerable<Vaga> BuscarVagasPorIdLoginEmpresa(int id)
    {
        var sql = _session.CreateSQLQuery(
            "select tv.* from tb_empresas te join " +
            "tb_autenticacao ta on te.email_empresa = ta.email_autenticacao " +
            "join tb_vagas tv on tv.id_empresa_vaga = te.id_empresa " +
            "where ta.id_autenticacao = ? and tv.status_vaga = 'ABERTO'"
        );
        sql.AddEntity(typeof(Vaga));
        sql.SetInt32(0, id);

        return sql.List<Vaga>();
    }

    public IEnumerable<Vaga> BuscarVagasFinalizadasPorIdLoginEmpresa(int id)
    {
        var sql = _session.CreateSQLQuery(
            "select tv.* from tb_empresas te join " +
            "tb_autenticacao ta on te.email_empresa = ta.email_autenticacao " +
            "join tb_vagas tv on tv.id_empresa_vaga = te.id_empresa " +
            "where ta.id_autenticacao = ? and (tv.status_vaga = 'FINALIZADO' or tv.status_vaga = 'CONCLUIDO')" +
            "order by tv.status_vaga"
        );
        sql.AddEntity(typeof(Vaga));
        sql.SetInt32(0, id);

        return sql.List<Vaga>();
    }

    public void Inserir(Vaga vaga)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Save(vaga);
            transaction.Commit();
        }    
    }

    public void Atualizar(Vaga vaga)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Update(vaga);
            transaction.Commit();
        }
    }

    public void Candidatar(CandidaturaDto candidatura)
    {
        using (var transaction = _session.BeginTransaction())
        {
            var sql = _session.CreateSQLQuery("insert into tb_vagas_estudante(id_vaga, id_estudante)  values(?, ?)");
            sql.SetInt32(0, candidatura.idVaga);
            sql.SetInt32(1, candidatura.idEstudante);
            sql.ExecuteUpdate();

            transaction.Commit();
        }
    }

    public void Remover(Vaga vaga)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Delete(vaga);
            transaction.Commit();
        }
    }

    public IEnumerable<Vaga> BuscarTodos()
    {
        return _session.QueryOver<Vaga>().List();
    }

    public IEnumerable<Estudante> BuscarCandidatos(int idVaga)
    {
        try
        {
            return _session.Get<Vaga>(idVaga).estudantes;
        }
        catch (Exception)
        {
            throw new RegistroNaoEncontradoException("Vaga " + idVaga + " não encontrada!");
        }
    }

    public void AprovarCandidato(CandidaturaDto candidatura)
    {
        using (var transaction = _session.BeginTransaction())
        {
            var sql = _session.CreateSQLQuery("delete from tb_vagas_estudante where id_vaga = ? and id_estudante <> ?");
            sql.SetInt32(0, candidatura.idVaga);
            sql.SetInt32(1, candidatura.idEstudante);
            sql.ExecuteUpdate();
            transaction.Commit();
        }
        Vaga vaga = BuscarPorId(candidatura.idVaga);
        vaga.status = "CONCLUIDO";
        Atualizar(vaga);
    }

    public void RejeitarCandidato(CandidaturaDto candidatura)
    {
        using (var transaction = _session.BeginTransaction())
        {
            var sql = _session.CreateSQLQuery("delete from tb_vagas_estudante where id_vaga = ? and id_estudante = ?");
            sql.SetInt32(0, candidatura.idVaga);
            sql.SetInt32(1, candidatura.idEstudante);
            sql.ExecuteUpdate();
            transaction.Commit();
        }
    }

    public void finalizarVaga(int id)
    {
        using (var transaction = _session.BeginTransaction())
        {
            var sql = _session.CreateSQLQuery("update tb_vagas set status_vaga = 'FINALIZADO' where id_vaga = ?");
            sql.SetInt32(0, id);
            sql.ExecuteUpdate();
            transaction.Commit();
        }
    }

}
