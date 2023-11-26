using EstagioJaAPI.Models;

namespace EstagioJaAPI.Repositories;
public interface IEmpresaRepository
{
    public Empresa BuscarPorId(int id);
    public Empresa BuscarPorEmail(string email);
    public Empresa BuscarPorIdEmpresa(int id);
    public void Atualizar(Empresa empresa);

}