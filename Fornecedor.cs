namespace PedidoFornecedorAPI.Models
{
    public class Fornecedor
    {
        public int Id { get; set; } // ID único do fornecedor.
        public string Nome { get; set; } // Nome do fornecedor.
        public string CNPJ { get; set; } // Cadastro Nacional de Pessoa Jurídica.
        public float Telefone { get; set; } // Telefone do fornecedor.
        public string Email { get; set; } // Email do fornecedor.
        public string Endereco { get; set; } // Endereço do fornecedor.

        // Construtor para garantir que as propriedades não sejam nulas.
        public Fornecedor()
        {
            Nome = string.Empty;
            CNPJ = string.Empty;
            Email = string.Empty;
            Endereco = string.Empty;
        }
    }
}