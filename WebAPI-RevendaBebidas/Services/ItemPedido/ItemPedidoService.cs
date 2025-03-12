using WebAPI_RevendaBebidas.Data;
using WebAPI_RevendaBebidas.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI_RevendaBebidas.Services.ItemPedido
{
    public class ItemPedidoService : IItemPedidoInterface
    {
        private readonly AppDbContext _context;

        public ItemPedidoService(AppDbContext context)
        {
            _context = context;
        }

        // Adicionar item ao pedido
        public ItemPedidoModel AdicionarItemPedido(ItemPedidoModel item)
        {
            _context.ItensPedido.Add(item);
            _context.SaveChanges();
            return item;
        }

        // Obter itens de um pedido específico
        public IEnumerable<ItemPedidoModel> ObterItensPorPedido(int pedidoId)
        {
            return _context.ItensPedido
                .Where(i => i.PedidoId == pedidoId)
                .ToList();
        }

        // Remover um item do pedido
        public bool RemoverItemPedido(int id)
        {
            var item = _context.ItensPedido.Find(id);
            if (item == null) return false;

            _context.ItensPedido.Remove(item);
            _context.SaveChanges();
            return true;
        }
    }
}

