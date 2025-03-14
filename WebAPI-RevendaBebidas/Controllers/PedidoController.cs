using Microsoft.AspNetCore.Mvc;
using WebAPI_RevendaBebidas.Models;
using WebAPI_RevendaBebidas.Services.Pedido;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI_RevendaBebidas.Controllers
{
    [Route("api/pedidos")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoInterface _pedidoService;

        public PedidoController(IPedidoInterface pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // Criar um novo pedido
        [HttpPost]
        public IActionResult CriarPedido([FromBody] PedidoModel pedido)
        {
            if (pedido == null)
                return BadRequest("Dados inválidos.");

            var novoPedido = _pedidoService.CriarPedido(pedido);
            return CreatedAtAction(nameof(ObterPedidoPorId), new { id = novoPedido.Id }, novoPedido);
        }

        // Obter todos os pedidos
        [HttpGet]
        public ActionResult<IEnumerable<PedidoModel>> ObterTodosPedidos()
        {
            return Ok(_pedidoService.ObterTodosPedidos());
        }

        // Obter pedido por ID
        [HttpGet("{id}")]
        public ActionResult<PedidoModel> ObterPedidoPorId(int id)
        {
            var pedido = _pedidoService.ObterPedidoPorId(id);
            if (pedido == null)
                return NotFound("Pedido não encontrado.");

            return Ok(pedido);
        }

        // Atualizar um pedido existente
        [HttpPut("{id}")]
        public IActionResult AtualizarPedido(int id, [FromBody] PedidoModel pedidoAtualizado)
        {
            if (pedidoAtualizado == null)
                return BadRequest("Dados inválidos.");

            var pedido = _pedidoService.AtualizarPedido(id, pedidoAtualizado);
            if (pedido == null)
                return NotFound("Pedido não encontrado.");

            return Ok(pedido);
        }

        // Excluir um pedido
        [HttpDelete("{id}")]
        public IActionResult ExcluirPedido(int id)
        {
            var sucesso = _pedidoService.ExcluirPedido(id);
            if (!sucesso)
                return NotFound("Pedido não encontrado.");

            return NoContent();
        }

        // Enviar pedido para AMBEV
        [HttpPost("{id}/enviar")]
        public async Task<IActionResult> EnviarPedidoParaAmbev(int id)
        {
            var pedido = _pedidoService.ObterPedidoPorId(id);
            if (pedido == null)
                return NotFound("Pedido não encontrado.");

            var sucesso = await _pedidoService.EnviarPedidoParaAmbev(pedido);
            if (!sucesso)
                return StatusCode(200, "Pedido mínimo de 1.000 unidades. Seu pedido não foi enviado.");

            return Ok("Pedido enviado com sucesso.");
        }
        //Listar pedidos da AMBEV
        [HttpGet("enviados")]
        public ActionResult<IEnumerable<PedidoModel>> ObterPedidosEnviados()
        {
            var pedidosEnviados = _pedidoService.ObterTodosPedidos()
                .Where(p => p.EnviadoParaAmbev)
                .ToList();

            return Ok(pedidosEnviados);
        }

    }
}
