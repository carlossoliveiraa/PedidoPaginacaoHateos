using System.ComponentModel.DataAnnotations;

namespace PaginacaoEFiltros.Application.Domain.Entities
{
    /// <summary>
    /// Entidade Item do Pedido
    /// </summary>
    public class ItemPedido
    {
        /// <summary>
        /// Identificador único do item
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador do pedido
        /// </summary>
        public int PedidoId { get; set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string ProdutoNome { get; set; } = string.Empty;

        /// <summary>
        /// Código do produto
        /// </summary>
        [MaxLength(50)]
        public string? ProdutoCodigo { get; set; }

        /// <summary>
        /// Quantidade do item
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Valor unitário do item
        /// </summary>
        public decimal ValorUnitario { get; set; }

        /// <summary>
        /// Valor total do item (Quantidade * ValorUnitario)
        /// </summary>
        public decimal ValorTotal => Quantidade * ValorUnitario;

        /// <summary>
        /// Pedido relacionado
        /// </summary>
        public Pedido? Pedido { get; set; }
    }
}
