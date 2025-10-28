using PaginacaoEFiltros.Application.Common;

namespace PaginacaoEFiltros.Application.Domain.DTOs
{
    /// <summary>
    /// Resposta de pesquisa de pedidos com paginação HATEOAS
    /// </summary>
    public class PedidoSearchResponse
    {
        /// <summary>
        /// Links HATEOAS para navegação
        /// </summary>
        public PaginacaoLinksDto Links { get; set; } = new();

        /// <summary>
        /// Informações de paginação
        /// </summary>
        public PaginacaoInfoDto Paginacao { get; set; } = new();

        /// <summary>
        /// Lista de pedidos encontrados
        /// </summary>
        public List<PedidoDto> Pedidos { get; set; } = new();
    }
}
