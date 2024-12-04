using PedidoFornecedorAPI.Models;

namespace PedidoFornecedorAPI.Repositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetAllAsync(); // Obtém todos os pedidos.
        Task<Pedido> GetByIdAsync(int id); // Busca um pedido pelo ID.
        Task AddAsync(Pedido pedido); // Adiciona um pedido.
        Task UpdateAsync(Pedido pedido); // Atualiza um pedido.
        Task DeleteAsync(int id); // Remove um pedido.
    }
}