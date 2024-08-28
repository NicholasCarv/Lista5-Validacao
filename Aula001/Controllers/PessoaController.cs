using Microsoft.AspNetCore.Mvc;
using SeuProjeto.Models; // Substitua pelo namespace real
using System.Collections.Generic;
using System.Linq;

namespace SeuProjeto.Controllers // Substitua pelo namespace real
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();

        [HttpPost("adicionar")]
        public IActionResult AdicionarPessoa([FromBody] Pessoa pessoa)
        {
            if (pessoas.Any(p => p.Cpf == pessoa.Cpf))
            {
                return BadRequest("Pessoa já existente com o mesmo CPF.");
            }
            pessoas.Add(pessoa);
            return Ok(pessoa);
        }

        [HttpPut("atualizar/{cpf}")]
        public IActionResult AtualizarPessoa(string cpf, [FromBody] Pessoa pessoaAtualizada)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Cpf == cpf);
            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada.");
            }
            pessoa.Nome = pessoaAtualizada.Nome;
            pessoa.Peso = pessoaAtualizada.Peso;
            pessoa.Altura = pessoaAtualizada.Altura;
            return Ok(pessoa);
        }

        [HttpDelete("remover/{cpf}")]
        public IActionResult RemoverPessoa(string cpf)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Cpf == cpf);
            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada.");
            }
            pessoas.Remove(pessoa);
            return Ok();
        }

        [HttpGet("todas")]
        public IActionResult BuscarTodasPessoas()
        {
            return Ok(pessoas);
        }

        [HttpGet("buscar/{cpf}")]
        public IActionResult BuscarPessoaPorCpf(string cpf)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Cpf == cpf);
            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada.");
            }
            return Ok(pessoa);
        }

        [HttpGet("imc-bom")]
        public IActionResult BuscarPessoasIMCBom()
        {
            var pessoasImcBom = pessoas.Where(p =>
                p.CalcularIMC() >= 18 && p.CalcularIMC() <= 24).ToList();
            return Ok(pessoasImcBom);
        }

        [HttpGet("buscar-por-nome")]
        public IActionResult BuscarPessoasPorNome([FromQuery] string nome)
        {
            var pessoasPorNome = pessoas.Where(p =>
                p.Nome.Contains(nome, System.StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(pessoasPorNome);
        }
    }
}
