using Microsoft.AspNetCore.Mvc;

namespace EstagioJaAPI.Controllers;

public interface IController<T> {

    public ActionResult<IEnumerable<T>> BuscarTodos();

    public ActionResult<T> BuscarPorId(int id);

    public IActionResult Inserir([FromBody] T entidade);

    public IActionResult Atualizar([FromBody] T entidade);

    public IActionResult Remover(int id);
}