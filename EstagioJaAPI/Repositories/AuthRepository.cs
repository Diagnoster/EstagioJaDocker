using EstagioJaAPI.Dtos;
using EstagioJaAPI.Exceptions;
using EstagioJaAPI.Models;
using EstagioJaAPI.Repositories;
using NHibernate.Mapping.Attributes;
using static NHibernate.Engine.Query.CallableParser;
using H = NHibernate;

namespace EstagioJaAPI.Services;

public class AuthRepository : IAuthRepository {

    private readonly H.ISession _session;

    public AuthRepository(H.ISession session)
    {
        _session = session;
    }

    public Auth Logar(Auth auth) {
        try {
            return _session.Query<Auth>().First(
                login => login.email.Equals(auth.email) && login.senha.Equals(auth.senha)
            );
        } catch (Exception) {
            throw new RegistroNaoEncontradoException("Login não encontrado!");
        }
    }

    public void CadastrarEstudante(Estudante auth) {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Save(auth);
            transaction.Commit();
        }    
    }

    public void CadastrarEmpresa(Empresa auth) {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Save(auth);
            transaction.Commit();
        }    
    }

    public void CadastrarLogin(Auth auth) {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Save(auth);
            transaction.Commit();
        }  
    }

    public void AlterarLogin(Auth auth)
    {
        using (var transaction = _session.BeginTransaction())
        {
            var sql = _session.CreateSQLQuery(@"
                update tb_autenticacao set senha_autenticacao = ?
                where email_autenticacao = ?
            ");

            sql.SetString(0, auth.senha);
            sql.SetString(1, auth.email);
            sql.ExecuteUpdate();
            transaction.Commit();
        }
    }

    public IEnumerable<Notificacao> BuscarNotificacoes(int idLogin)
    {
        try
        {
            return _session.Query<Notificacao>().Where(
                notificacao => notificacao.usuario.id == idLogin
            ).ToList();
        }
        catch (Exception)
        {
            throw new RegistroNaoEncontradoException("Login não encontrado!");
        }
    }

    public EmailDto BuscarEmail(string email)
    {
        var sql = _session.CreateSQLQuery(
            @"select 
	            ta.email_autenticacao as email, 
	            case
		            when ta.perfil_autenticacao = 1 then te.fantasia_empresa
		            when ta.perfil_autenticacao = 0 then te2.nome_estudante
		            else 'E-mail não encontrado'
	            end as nome_completo
            from 
	            tb_autenticacao ta
            left join 
	            tb_empresas te on ta.perfil_autenticacao = 1 and te.email_empresa  = ta.email_autenticacao
            left join 
	            tb_estudantes te2 on ta.perfil_autenticacao = 0 and te2.email_estudante = ta.email_autenticacao
            where 
	            email_autenticacao = ?");

        sql.SetString(0, email);
        Object[] result = (object[])sql.UniqueResult();

        string emailResult = result != null ? result[0].ToString() : "E-mail não encontrado";
        string nomeResult = result != null ? result[1].ToString() : "Nome não encontrado";

        return new EmailDto(
            emailResult,
            nomeResult
        );
    }

}