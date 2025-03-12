using WebAPI_RevendaBebidas.Models;

namespace WebAPI_RevendaBebidas.Services.Produto
{
    public interface IProdutoInterface
    {
        ProdutoModel CriarProduto(ProdutoModel produto);
        ProdutoModel ObterProdutoPorId(int id);
        IEnumerable<ProdutoModel> ObterTodosProdutos();
        ProdutoModel AtualizarProduto(int id, ProdutoModel produtoAtualizado);
        bool ExcluirProduto(int id);
    }
}
