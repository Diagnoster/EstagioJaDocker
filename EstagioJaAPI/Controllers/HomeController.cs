using EstagioJaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstagioJaAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet("index.html")]
        public IActionResult Up() 
        {
            return Ok("up");
        }
    }
}
