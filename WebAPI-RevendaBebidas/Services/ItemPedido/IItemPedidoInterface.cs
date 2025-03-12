using WebAPI_RevendaBebidas.Models;

namespace WebAPI_RevendaBebidas.Services.ItemPedido
{
    public interface IItemPedidoInterface
    {
        ItemPedidoModel AdicionarItemPedido(ItemPedidoModel item);
        IEnumerable<ItemPedidoModel> ObterItensPorPedido(int pedidoId);
        bool RemoverItemPedido(int id);
    }
}

