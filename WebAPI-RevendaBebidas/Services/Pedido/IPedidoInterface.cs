using WebAPI_RevendaBebidas.Data;
using WebAPI_RevendaBebidas.Models;

namespace WebAPI_RevendaBebidas.Services.Pedido
{
    public interface IPedidoInterface
    {
        
        // Criar um novo pedido
        PedidoModel CriarPedido(PedidoModel pedido);

        // Obter um pedido pelo ID
        PedidoModel ObterPedidoPorId(int id);

        // Listar todos os pedidos
        IEnumerable<PedidoModel> ObterTodosPedidos();

        // Atualizar um pedido existente
        PedidoModel AtualizarPedido(int id, PedidoModel pedidoAtualizado);

        // Excluir um pedido
        bool ExcluirPedido(int id);

        // Verificar se um pedido atinge o mínimo exigido pela AMBEV (1000 unidades)
        bool PedidoAtendeQuantidadeMinima(PedidoModel pedido);

        // Enviar o pedido para a API da AMBEV
        Task<bool> EnviarPedidoParaAmbev(PedidoModel pedido);

        // Lidar com falhas no envio do pedido (por exemplo, reenvio automático)
        Task<bool> ReprocessarPedidosFalhos();
    }
}
