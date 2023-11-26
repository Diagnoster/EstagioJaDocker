using EstagioJaAPI.Dtos;
using EstagioJaAPI.Models;

namespace EstagioJaAPI.Repositories;
public interface IAuthRepository
{    
    //public void Logar(IUsuario Auth);
    public void CadastrarEstudante(Estudante auth);
    public void CadastrarEmpresa(Empresa auth);
    public void CadastrarLogin(Auth auth);
    public Auth Logar(Auth auth);
    public IEnumerable<Notificacao> BuscarNotificacoes(int idLogin);
    public EmailDto BuscarEmail(string email);
    public void AlterarLogin(Auth auth);
}