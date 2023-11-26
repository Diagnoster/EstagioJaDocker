using EstagioJaAPI.Dtos;
using EstagioJaAPI.Exceptions;
using EstagioJaAPI.Models;
using EstagioJaAPI.Repositories;

namespace EstagioJaAPI.Services;

public class AuthService : IAuthService {

    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public Auth Logar(Auth auth) {
        try {
           return _authRepository.Logar(auth);
        } catch (RegistroNaoEncontradoException e) {
            throw e;
        }
    }

    public void CadastrarEstudante(Estudante auth) {
        _authRepository.CadastrarEstudante(auth);
    }

    public void CadastrarEmpresa(Empresa auth) {
        _authRepository.CadastrarEmpresa(auth);
    }

    public void CadastrarLogin(Auth auth) {
        _authRepository.CadastrarLogin(auth);
    }

    public IEnumerable<Notificacao> BuscarNotificacoes(int idLogin)
    {
        return _authRepository.BuscarNotificacoes(idLogin);
    }

    public EmailDto BuscarEmail(string email)
    {
        return _authRepository.BuscarEmail(email);
    }

    public void AlterarLogin(Auth auth)
    {
        _authRepository.AlterarLogin(auth);
    }

}