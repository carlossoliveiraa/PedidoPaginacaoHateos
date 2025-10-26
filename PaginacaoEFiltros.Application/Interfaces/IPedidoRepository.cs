using PaginacaoEFiltros.Application.DTOs;
using PaginacaoEFiltros.Application.Entities;

namespace PaginacaoEFiltros.Application.Interfaces
{
    /// <summary>
    /// Interface para repositório de pedidos simplificado
    /// </summary>
    public interface IPedidoRepository
    {
        /// <summary>
        /// Pesquisa pedidos com filtros e paginação simplificada
        /// </summary>
        /// <param name="request">Requisição de pesquisa simplificada</param>
        /// <returns>Tupla com itens e total de registros</returns>
        Task<(IEnumerable<Pedido> Items, int TotalCount)> SearchAsync(PedidoSearchRequest request);
    }
}
