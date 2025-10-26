using System.ComponentModel.DataAnnotations;

namespace PaginacaoEFiltros.Application.DTOs
{
    /// <summary>
    /// Requisição simplificada de pesquisa de pedidos
    /// </summary>
    public class PedidoSearchRequest
    {
        /// <summary>
        /// Número do pedido
        /// </summary>
        public string? NumeroPedido { get; set; }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string? NomeCliente { get; set; }

        /// <summary>
        /// UF do cliente
        /// </summary>
        public string? UF { get; set; }

        /// <summary>
        /// Página inicial (começando em 1)
        /// </summary>
        [Range(1, int.MaxValue)]
        public int PaginaInicial { get; set; } = 1;

        /// <summary>
        /// Total de itens por página
        /// </summary>
        [Range(1, 1000)]
        public int TotalItensPagina { get; set; } = 10;

        /// <summary>
        /// Valida se a requisição está correta
        /// </summary>
        public bool IsValid()
        {
            return PaginaInicial >= 1 && TotalItensPagina >= 1 && TotalItensPagina <= 1000;
        }
    }
}
