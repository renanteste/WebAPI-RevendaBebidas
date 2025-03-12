using Microsoft.AspNetCore.Mvc;
using WebAPI_RevendaBebidas.Models;
using System.Collections.Generic;
using WebAPI_RevendaBebidas.Data;

namespace WebAPI_RevendaBebidas.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        // Criar um novo cliente
        [HttpPost]
        public IActionResult CriarCliente([FromBody] ClienteModel cliente)
        {
            if (cliente == null)
                return BadRequest("Dados inválidos.");

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterClientePorId), new { id = cliente.Id }, cliente);
        }

        // Obter todos os clientes
        [HttpGet]
        public ActionResult<IEnumerable<ClienteModel>> ObterTodosClientes()
        {
            return Ok(_context.Clientes.ToList());
        }

        // Obter cliente por ID
        [HttpGet("{id}")]
        public ActionResult<ClienteModel> ObterClientePorId(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            return Ok(cliente);
        }

        // Atualizar um cliente existente
        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, [FromBody] ClienteModel clienteAtualizado)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            cliente.Name = clienteAtualizado.Name;
            _context.SaveChanges();
            return Ok(cliente);
        }

        // Excluir um cliente
        [HttpDelete("{id}")]
        public IActionResult ExcluirCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
