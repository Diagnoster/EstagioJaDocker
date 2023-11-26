using EstagioJaAPI.Dtos;
using EstagioJaAPI.Models;

namespace EstagioJaAPI.Services;

public interface IVagaService {
    public IEnumerable<Vaga> BuscarTodos();
    public Vaga BuscarPorId(int id);
    public void Inserir(Vaga vaga);
    public void Atualizar(Vaga vaga);
    public void Remover(int id);
    public void Candidatar(CandidaturaDto candidatura);
    public IEnumerable<Estudante> BuscarCandidatos(int idVaga);
    public void AprovarCandidato(CandidaturaDto candidatura);
    public void RejeitarCandidato(CandidaturaDto candidatura);
    public IEnumerable<Vaga> BuscarVagasPorIdLoginEmpresa(int id);
    public IEnumerable<Vaga> BuscarVagasFinalizadasPorIdLoginEmpresa(int id);
    public void finalizarVaga(int id);
}