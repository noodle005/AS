namespace PedidoFornecedorAPI.Models
{
    public class Pedido
    {
        public int Id { get; set; } // ID único do pedido.
        public DateTime Data { get; set; } // Data do pedido.
        public decimal ValorTotal { get; set; } // Valor total do pedido.
        public string Status { get; set; } // Status do pedido (ex.: "Pendente", "Concluído").
        public string Descricao { get; set; } // Descrição do pedido.

        // Construtor para inicializar as propriedades não anuláveis.
        public Pedido()
        {
            Status = string.Empty;
            Descricao = string.Empty;
        }
    }
}