using Microsoft.AspNetCore.Mvc;
using WebAPI_RevendaBebidas.Models;
using WebAPI_RevendaBebidas.Services.Produto;
using System.Collections.Generic;

namespace WebAPI_RevendaBebidas.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _produtoService;

        public ProdutoController(IProdutoInterface produtoService)
        {
            _produtoService = produtoService;
        }

        // Criar um novo produto
        [HttpPost]
        public IActionResult CriarProduto([FromBody] ProdutoModel produto)
        {
            if (produto == null)
                return BadRequest("Dados inválidos.");

            var novoProduto = _produtoService.CriarProduto(produto);
            return CreatedAtAction(nameof(ObterProdutoPorId), new { id = novoProduto.Id }, novoProduto);
        }

        // Obter todos os produtos
        [HttpGet]
        public ActionResult<IEnumerable<ProdutoModel>> ObterTodosProdutos()
        {
            return Ok(_produtoService.ObterTodosProdutos());
        }

        // Obter produto por ID
        [HttpGet("{id}")]
        public ActionResult<ProdutoModel> ObterProdutoPorId(int id)
        {
            var produto = _produtoService.ObterProdutoPorId(id);
            if (produto == null)
                return NotFound("Produto não encontrado.");

            return Ok(produto);
        }

        // Atualizar um produto existente
        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, [FromBody] ProdutoModel produtoAtualizado)
        {
            if (produtoAtualizado == null)
                return BadRequest("Dados inválidos.");

            var produto = _produtoService.AtualizarProduto(id, produtoAtualizado);
            if (produto == null)
                return NotFound("Produto não encontrado.");

            return Ok(produto);
        }

        // Excluir um produto
        [HttpDelete("{id}")]
        public IActionResult ExcluirProduto(int id)
        {
            var sucesso = _produtoService.ExcluirProduto(id);
            if (!sucesso)
                return NotFound("Produto não encontrado.");

            return NoContent();
        }
    }
}
