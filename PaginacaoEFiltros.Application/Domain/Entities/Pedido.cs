using System.ComponentModel.DataAnnotations;

namespace PaginacaoEFiltros.Application.Domain.Entities
{
    /// <summary>
    /// Entidade Pedido
    /// </summary>
    public class Pedido
    {
        /// <summary>
        /// Identificador único do pedido
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Número do pedido
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Numero { get; set; } = string.Empty;

        /// <summary>
        /// Data de criação do pedido
        /// </summary>
        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Status do pedido
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Nome do cliente
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string ClienteNome { get; set; } = string.Empty;

        /// <summary>
        /// Email do cliente
        /// </summary>
        [MaxLength(200)]
        public string? ClienteEmail { get; set; }

        /// <summary>
        /// UF do cliente
        /// </summary>
        [MaxLength(2)]
        public string? UF { get; set; }

        /// <summary>
        /// Valor total do pedido
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Observações do pedido
        /// </summary>
        [MaxLength(1000)]
        public string? Observacoes { get; set; }

        /// <summary>
        /// Itens do pedido
        /// </summary>
        public List<ItemPedido> Itens { get; set; } = new();
    }
}
