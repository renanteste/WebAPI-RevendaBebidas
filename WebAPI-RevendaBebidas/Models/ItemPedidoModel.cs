﻿namespace WebAPI_RevendaBebidas.Models
{
    public class ItemPedidoModel
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
