using PaginacaoEFiltros.Application.Common;

namespace PaginacaoEFiltros.Application.DTOs
{
    /// <summary>
    /// Resposta simplificada de pesquisa de pedidos
    /// </summary>
    public class PedidoSearchResponse
    {
        /// <summary>
        /// Página atual
        /// </summary>
        public int Pagina { get; set; }

        /// <summary>
        /// Total de registros encontrados
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Links HATEOAS para navegação
        /// </summary>
        public List<LinkDto> Links { get; set; } = new();

        /// <summary>
        /// Lista de pedidos encontrados
        /// </summary>
        public List<PedidoDto> Pedidos { get; set; } = new();
    }
}
