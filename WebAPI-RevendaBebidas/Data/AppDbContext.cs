using Microsoft.EntityFrameworkCore;
using WebAPI_RevendaBebidas.Models;

namespace WebAPI_RevendaBebidas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets correspondentes aos models
        public DbSet<RevendaModel> Revendas { get; set; }
        public DbSet<TelefoneModel> Telefones { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<ItemPedidoModel> ItensPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definições para garantir integridade referencial
            modelBuilder.Entity<TelefoneModel>()
                .HasOne<RevendaModel>()
                .WithMany(r => r.Telefones)
                .HasForeignKey(t => t.RevendaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EnderecoModel>()
                .HasOne<RevendaModel>()
                .WithMany(r => r.Enderecos)
                .HasForeignKey(e => e.RevendaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PedidoModel>()
                .HasOne<ClienteModel>()
                .WithMany()
                .HasForeignKey(p => p.ClienteId);

            modelBuilder.Entity<PedidoModel>()
                .HasOne<RevendaModel>()
                .WithMany()
                .HasForeignKey(p => p.RevendaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemPedidoModel>()
                .HasOne<PedidoModel>()
                .WithMany(p => p.ItensPedido)
                .HasForeignKey(i => i.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemPedidoModel>()
                .HasOne<ProdutoModel>()
                .WithMany()
                .HasForeignKey(i => i.ProdutoId);
        }
    }
}
