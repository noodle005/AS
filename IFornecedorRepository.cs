using PedidoFornecedorAPI.Models;

namespace PedidoFornecedorAPI.Repositories
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<Fornecedor>> GetAllAsync(); // Obtém todos os fornecedores.
        Task<Fornecedor> GetByIdAsync(int id); // Busca um fornecedor pelo ID.
        Task AddAsync(Fornecedor fornecedor); // Adiciona um fornecedor.
        Task UpdateAsync(Fornecedor fornecedor); // Atualiza um fornecedor.
        Task DeleteAsync(int id); // Remove um fornecedor.
    }
}