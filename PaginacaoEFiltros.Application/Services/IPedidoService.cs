using PaginacaoEFiltros.Application.Domain.DTOs;

namespace PaginacaoEFiltros.Application.Services
{
    /// <summary>
    /// Interface para serviço de Pedidos
    /// </summary>
    public interface IPedidoService
    {
        /// <summary>
        /// Pesquisa pedidos com filtros e paginação (versão simplificada)
        /// </summary>
        /// <param name="request">Requisição de pesquisa simplificada</param>
        /// <param name="baseUrl">URL base para geração de links HATEOAS</param>
        /// <returns>Resposta simplificada com pedidos paginados</returns>
        Task<PedidoSearchResponse> SearchSimplifiedAsync(PedidoSearchRequest request, string baseUrl);
    }
}
