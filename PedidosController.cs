using Microsoft.AspNetCore.Mvc;
using PedidoFornecedorAPI.Models;
using PedidoFornecedorAPI.Repositories;

namespace PedidoFornecedorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet] // Retorna todos os pedidos.
        public async Task<IActionResult> GetAll() =>
            Ok(await _pedidoRepository.GetAllAsync());

        [HttpGet("{id}")] // Retorna um pedido específico pelo ID.
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            return pedido != null ? Ok(pedido) : NotFound(); // Retorna 200 ou 404.
        }

        [HttpPost] // Cria um novo pedido.
        public async Task<IActionResult> Create(Pedido pedido)
        {
             if (pedido.ValorTotal <= 0)
                return BadRequest("Valor total deve ser maior que zero.");
            await _pedidoRepository.AddAsync(pedido); // Adiciona o pedido ao banco.
            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")] // Atualiza um pedido.
        public async Task<IActionResult> Update(int id, Pedido pedido)
        {
            if (id != pedido.Id) return BadRequest(); // Valida o ID.
            await _pedidoRepository.UpdateAsync(pedido); // Atualiza no banco.
            return NoContent(); // Retorna 204.
        }

        [HttpDelete("{id}")] // Deleta um pedido.
        public async Task<IActionResult> Delete(int id)
        {
            await _pedidoRepository.DeleteAsync(id); // Remove o pedido.
            return NoContent(); // Retorna 204.
        }
    }
}