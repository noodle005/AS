using Microsoft.EntityFrameworkCore;
using PedidoFornecedorAPI.Data;
using PedidoFornecedorAPI.Models;

namespace PedidoFornecedorAPI.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context; // Injeta o contexto do banco de dados.
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync() =>
            await _context.Pedidos.ToListAsync(); // Obtém todos os pedidos.

        public async Task<Pedido> GetByIdAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id); // Busca o pedido pelo ID.
            if (pedido == null)
            {
                throw new KeyNotFoundException($"Pedido com ID {id} não encontrado.");
            }
            return pedido;
        }

        public async Task AddAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido); // Adiciona um novo pedido.
            await _context.SaveChangesAsync(); // Salva as mudanças no banco.
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido); // Atualiza o pedido.
            await _context.SaveChangesAsync(); // Salva as mudanças no banco.
        }

        public async Task DeleteAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id); // Busca o pedido pelo ID.
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido); // Remove o pedido.
                await _context.SaveChangesAsync(); // Salva as mudanças no banco.
            }
        }
    }
}