using Microsoft.AspNetCore.Mvc;
using WebAPI_RevendaBebidas.Models;
using WebAPI_RevendaBebidas.Services.Revenda;
using System.Collections.Generic;

namespace WebAPI_RevendaBebidas.Controllers
{
    [Route("api/revendas")]
    [ApiController]
    public class RevendaController : ControllerBase
    {
        private readonly IRevendaInterface _revendaService;

        public RevendaController(IRevendaInterface revendaService)
        {
            _revendaService = revendaService;
        }

        // Criar uma nova revenda
        [HttpPost]
        public IActionResult CriarRevenda([FromBody] RevendaModel revenda)
        {
            if (revenda == null)
                return BadRequest("Dados inválidos.");

            var novaRevenda = _revendaService.CriarRevenda(revenda);
            return CreatedAtAction(nameof(ObterRevendaPorId), new { id = novaRevenda.Id }, novaRevenda);
        }

        // Obter todas as revendas
        [HttpGet]
        public ActionResult<IEnumerable<RevendaModel>> ObterTodasRevendas()
        {
            var revendas = _revendaService.ObterTodasRevendas();
            return Ok(revendas);
        }

        // Obter revenda por ID
        [HttpGet("{id}")]
        public ActionResult<RevendaModel> ObterRevendaPorId(int id)
        {
            var revenda = _revendaService.ObterRevendaPorId(id);
            if (revenda == null)
                return NotFound("Revenda não encontrada.");

            return Ok(revenda);
        }

        // Obter revenda por CNPJ
        [HttpGet("cnpj/{cnpj}")]
        public ActionResult<RevendaModel> ObterRevendaPorCNPJ(string cnpj)
        {
            var revenda = _revendaService.ObterRevendaPorCNPJ(cnpj);
            if (revenda == null)
                return NotFound("Revenda não encontrada.");

            return Ok(revenda);
        }

        // Atualizar uma revenda
        [HttpPut("{id}")]
        public IActionResult AtualizarRevenda(int id, [FromBody] RevendaModel revendaAtualizada)
        {
            if (revendaAtualizada == null)
                return BadRequest("Dados inválidos.");

            var revenda = _revendaService.AtualizarRevenda(id, revendaAtualizada);
            if (revenda == null)
                return NotFound("Revenda não encontrada.");

            return Ok(revenda);
        }

        // Excluir uma revenda
        [HttpDelete("{id}")]
        public IActionResult ExcluirRevenda(int id)
        {
            var sucesso = _revendaService.ExcluirRevenda(id);
            if (!sucesso)
                return NotFound("Revenda não encontrada.");

            return NoContent();
        }
    }
}
