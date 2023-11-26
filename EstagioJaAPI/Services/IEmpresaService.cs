using EstagioJaAPI.Models;

namespace EstagioJaAPI.Services;

public interface IEmpresaService {
    public Empresa BuscarPorId(int id);
    public Empresa BuscarPorEmail(string email);
    public Empresa BuscarPorIdEmpresa(int id);
    public void Atualizar(Empresa empresa);
}