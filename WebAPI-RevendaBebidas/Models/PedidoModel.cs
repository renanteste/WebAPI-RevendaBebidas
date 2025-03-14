using WebAPI_RevendaBebidas.Models;

public class PedidoModel
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int RevendaId { get; set; }
    public DateTime DataPedido { get; set; } = DateTime.Now;
    public List<ItemPedidoModel> ItensPedido { get; set; } = new List<ItemPedidoModel>();

    // 🔹 Novo campo para rastrear pedidos enviados para AMBEV
    public bool EnviadoParaAmbev { get; set; } = false;
}

