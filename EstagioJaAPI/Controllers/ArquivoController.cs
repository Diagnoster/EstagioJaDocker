using Microsoft.AspNetCore.Mvc;
namespace EstagioJaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ArquivoController : ControllerBase
{
    [HttpPost]
    public IActionResult UploadFoto([FromForm] IFormCollection form)
    {
        try
        {
            var arquivo = form.Files["arquivo"];

            if (arquivo != null && arquivo.Length > 0)
            {
                string filePath = Path.Combine("arquivos", arquivo.FileName);

                if (!Directory.Exists("arquivos"))
                {
                    // Cria a pasta se não existir
                    Directory.CreateDirectory("arquivos");
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    arquivo.CopyTo(stream);
                }

                return Ok(new { arquivo.FileName });
            }

            return BadRequest("Arquivo inválido");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    [HttpGet("{nomeArquivo}")]
    public IActionResult ObterArquivo(string nomeArquivo)
    {
        try
        {
            // Certifique-se de que o diretório de destino existe
            string uploadPath = Path.Combine("arquivos");

            // Caminho completo do arquivo no servidor
            string filePath = Path.Combine(uploadPath, nomeArquivo);

            // Verifica se o arquivo existe
            if (System.IO.File.Exists(filePath))
            {
                // Retorna o arquivo como FileStreamResult
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return File(fileStream, "application/octet-stream", nomeArquivo);
            }

            return NotFound("Arquivo não encontrado");
        }
        catch (Exception ex)
        {
            // Lide com exceções conforme necessário
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

}