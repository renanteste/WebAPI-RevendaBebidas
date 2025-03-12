using WebAPI_RevendaBebidas.Data;
using WebAPI_RevendaBebidas.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_RevendaBebidas.Services.Pedido
{
    public class PedidoService : IPedidoInterface
    {
        private readonly AppDbContext _context;

        public PedidoService(AppDbContext context)
        {
            _context = context;
        }

        // Criar um novo pedido
        public PedidoModel CriarPedido(PedidoModel pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return pedido;
        }

        // Obter um pedido pelo ID
        public PedidoModel ObterPedidoPorId(int id)
        {
            return _context.Pedidos
                .Include(p => p.ItensPedido)
                .FirstOrDefault(p => p.Id == id);
        }

        // Listar todos os pedidos
        public IEnumerable<PedidoModel> ObterTodosPedidos()
        {
            return _context.Pedidos
                .Include(p => p.ItensPedido)
                .ToList();
        }

        // Atualizar um pedido existente
        public PedidoModel AtualizarPedido(int id, PedidoModel pedidoAtualizado)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido == null) return null;

            pedido.ClienteId = pedidoAtualizado.ClienteId;
            pedido.RevendaId = pedidoAtualizado.RevendaId;
            pedido.ItensPedido = pedidoAtualizado.ItensPedido;

            _context.SaveChanges();
            return pedido;
        }

        // Excluir um pedido
        public bool ExcluirPedido(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido == null) return false;

            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
            return true;
        }

        // Verificar se o pedido atende o mínimo de 1000 unidades
        public bool PedidoAtendeQuantidadeMinima(PedidoModel pedido)
        {
            return pedido.ItensPedido.Sum(i => i.Quantidade) >= 1000;
        }

        // Enviar pedido para a API da AMBEV
        public async Task<bool> EnviarPedidoParaAmbev(PedidoModel pedido)
        {
            if (!PedidoAtendeQuantidadeMinima(pedido))
                return false;

            try
            {
                // Simulação do envio do pedido (substituir por chamada real à API AMBEV)
                await Task.Delay(1000); // Simulando latência da requisição
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Reprocessar pedidos falhos
        public async Task<bool> ReprocessarPedidosFalhos()
        {
            var pedidosFalhos = _context.Pedidos
                .Where(p => !PedidoAtendeQuantidadeMinima(p))
                .ToList();

            bool sucesso = true;
            foreach (var pedido in pedidosFalhos)
            {
                sucesso &= await EnviarPedidoParaAmbev(pedido);
            }

            return sucesso;
        }
    }
}
