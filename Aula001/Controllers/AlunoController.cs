using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AlunoController : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult CreateAluno([FromBody] Aluno aluno)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Se as validações passarem, salvar o aluno
        return Ok("Aluno criado com sucesso!");
    }
}
