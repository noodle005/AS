using Microsoft.EntityFrameworkCore;
using PedidoFornecedorAPI.Data;
using PedidoFornecedorAPI.Models;

namespace PedidoFornecedorAPI.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppDbContext _context;

        public FornecedorRepository(AppDbContext context)
        {
            _context = context; // Injeta o contexto do banco de dados.
        }

        public async Task<IEnumerable<Fornecedor>> GetAllAsync() =>
            await _context.Fornecedores.ToListAsync(); // Obtém todos os fornecedores.

        public async Task<Fornecedor> GetByIdAsync(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id); // Busca o fornecedor pelo ID.
            if (fornecedor == null)
            {
                throw new KeyNotFoundException($"Fornecedor com ID {id} não encontrado.");
            }
            return fornecedor;
        }

        public async Task AddAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor); // Adiciona um novo fornecedor.
            await _context.SaveChangesAsync(); // Salva as mudanças no banco.
        }

        public async Task UpdateAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Update(fornecedor); // Atualiza o fornecedor.
            await _context.SaveChangesAsync(); // Salva as mudanças no banco.
        }

        public async Task DeleteAsync(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id); // Busca o fornecedor pelo ID.
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor); // Remove o fornecedor.
                await _context.SaveChangesAsync(); // Salva as mudanças no banco.
            }
        }
    }
}