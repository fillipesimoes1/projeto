using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PessoaController.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;
        private readonly IPessoaService _pessoaService; 

        public PessoaController(ILogger<PessoaController> logger, IPessoaService pessoaService)
        {
            _logger = logger;
            _pessoaService = pessoaService;
        }

        [HttpGet("salarios")]
        public async Task<IActionResult> GetSalarios()
        {
            try
            {
                var salarios = await _pessoaService.ObterSalariosAsync();
                return Ok(salarios);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao obter salários", ex);
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        
        [HttpPost("recalcular-salarios")]
        public async Task<IActionResult> RecalcularSalarios()
        {
            try
            {
                await _pessoaService.CalcularSalariosAsync();
                return Ok("Salários recalculados com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao recalcular salários", ex);
                return StatusCode(500, "Erro interno no servidor");
            }
        }

       
        [HttpGet("pessoas")]
        public async Task<IActionResult> GetPessoas()
        {
            try
            {
                var pessoas = await _pessoaService.ObterPessoasAsync();
                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao obter lista de pessoas", ex);
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CriarPessoa([FromBody] Pessoa novaPessoa)
        {
            try
            {
                await _pessoaService.CriarPessoaAsync(novaPessoa);
                return Ok("Pessoa criada com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao criar pessoa", ex);
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        
        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> AtualizarPessoa(int id, [FromBody] Pessoa pessoaAtualizada)
        {
            try
            {
                await _pessoaService.AtualizarPessoaAsync(id, pessoaAtualizada);
                return Ok("Pessoa atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao atualizar pessoa", ex);
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        
        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirPessoa(int id)
        {
            try
            {
                await _pessoaService.ExcluirPessoaAsync(id);
                return Ok("Pessoa excluída com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao excluir pessoa", ex);
                return StatusCode(500, "Erro interno no servidor");
            }
        }
    }
}
