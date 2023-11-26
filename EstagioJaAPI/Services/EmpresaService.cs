using EstagioJaAPI.Models;
using EstagioJaAPI.Repositories;
using EstagioJaAPI.Services;
namespace EstagioJaAPI.Services;

public class EmpresaService: IEmpresaService {

    private readonly IEmpresaRepository _empresaRepository;

    public EmpresaService(IEmpresaRepository empresaRepository)
    {
        _empresaRepository = empresaRepository;
    }

    public Empresa BuscarPorEmail(string email)
    {
        return _empresaRepository.BuscarPorEmail(email);
    }

    public Empresa BuscarPorId(int id)
    {
        return _empresaRepository.BuscarPorId(id);
    }

    public Empresa BuscarPorIdEmpresa(int id)
    {
        return _empresaRepository.BuscarPorIdEmpresa(id);
    }

    public void Atualizar(Empresa empresa)
    {
        _empresaRepository.Atualizar(empresa);
    }

}