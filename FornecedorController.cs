using Microsoft.AspNetCore.Mvc;
using PedidoFornecedorAPI.Models;
using PedidoFornecedorAPI.Repositories;

namespace PedidoFornecedorAPI.Controllers
{
    [ApiController] // Indica que essa classe é um controlador da API.
    [Route("api/[controller]")] 
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        // Construtor que injeta a dependência do repositório de fornecedores.
        public FornecedoresController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        [HttpGet] // Define a rota para obter todos os fornecedores.
        public async Task<IActionResult> GetAll() =>
            Ok(await _fornecedorRepository.GetAllAsync()); // Retorna todos os fornecedores.

        [HttpGet("{id}")] // Define a rota para obter um fornecedor específico pelo ID.
        public async Task<IActionResult> GetById(int id)
        {
            var fornecedor = await _fornecedorRepository.GetByIdAsync(id);
            // Se o fornecedor existir, retorna com status 200; caso contrário, retorna 404.
            return fornecedor != null ? Ok(fornecedor) : NotFound();
        }

        [HttpPost] // Define a rota para criar um novo fornecedor.
        public async Task<IActionResult> Create(Fornecedor fornecedor)
        {
            await _fornecedorRepository.AddAsync(fornecedor); // Adiciona o fornecedor no banco de dados.
            // Retorna o fornecedor criado com o status 201 Created.
            return CreatedAtAction(nameof(GetById), new { id = fornecedor.Id }, fornecedor);
        }

        [HttpPut("{id}")] // Define a rota para atualizar um fornecedor específico.
        public async Task<IActionResult> Update(int id, Fornecedor fornecedor)
        {
            // Valida se o ID da rota corresponde ao ID do objeto.
            if (id != fornecedor.Id) return BadRequest();
            await _fornecedorRepository.UpdateAsync(fornecedor); // Atualiza o fornecedor.
            return NoContent(); // Retorna status 204 sem conteúdo.
        }

        [HttpDelete("{id}")] // Define a rota para deletar um fornecedor.
        public async Task<IActionResult> Delete(int id)
        {
            await _fornecedorRepository.DeleteAsync(id); // Remove o fornecedor.
            return NoContent(); // Retorna status 204 sem conteúdo.
        }
    }
}