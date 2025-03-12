using WebAPI_RevendaBebidas.Data;
using WebAPI_RevendaBebidas.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI_RevendaBebidas.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        // Criar um novo produto
        public ProdutoModel CriarProduto(ProdutoModel produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        // Obter um produto pelo ID
        public ProdutoModel ObterProdutoPorId(int id)
        {
            return _context.Produtos.Find(id);
        }

        // Listar todos os produtos
        public IEnumerable<ProdutoModel> ObterTodosProdutos()
        {
            return _context.Produtos.ToList();
        }

        // Atualizar um produto existente
        public ProdutoModel AtualizarProduto(int id, ProdutoModel produtoAtualizado)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null) return null;

            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;

            _context.SaveChanges();
            return produto;
        }

        // Excluir um produto
        public bool ExcluirProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null) return false;

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return true;
        }
    }
}

