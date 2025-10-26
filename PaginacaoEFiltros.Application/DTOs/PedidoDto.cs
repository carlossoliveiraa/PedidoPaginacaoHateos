namespace PaginacaoEFiltros.Application.DTOs
{
    /// <summary>
    /// DTO simplificado para Pedido
    /// </summary>
    public class PedidoDto
    {
        /// <summary>
        /// Identificador único do pedido
        /// </summary>
        public int PedidoId { get; set; }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Cliente { get; set; } = string.Empty;

        /// <summary>
        /// UF do cliente
        /// </summary>
        public string UF { get; set; } = string.Empty;

        /// <summary>
        /// Valor total do pedido
        /// </summary>
        public decimal Valor { get; set; }
    }
}
