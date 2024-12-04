using Microsoft.EntityFrameworkCore;
using PedidoFornecedorAPI.Models;

namespace PedidoFornecedorAPI.Data
{
    public class AppDbContext : DbContext
    {
        // Configura o contexto do banco de dados com a string de conexão.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; } = null!;   // Tabela de pedidos.
        public DbSet<Fornecedor> Fornecedores { get; set; } = null!;  // Tabela de fornecedores.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais para mapeamento, se necessário.
        }
    }
}