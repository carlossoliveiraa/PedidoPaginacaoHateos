using PaginacaoEFiltros.Application.DTOs;
using PaginacaoEFiltros.Application.Entities;
using PaginacaoEFiltros.Application.Common;
using PaginacaoEFiltros.Application.Interfaces;

namespace PaginacaoEFiltros.Application.Services
{
    /// <summary>
    /// Serviço para operações com Pedidos
    /// </summary>
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;

        public PedidoService(IPedidoRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Pesquisa pedidos com filtros e paginação (versão simplificada)
        /// </summary>
        public async Task<PedidoSearchResponse> SearchSimplifiedAsync(PedidoSearchRequest request)
        {
            var (items, totalCount) = await _repository.SearchAsync(request);

            var response = new PedidoSearchResponse
            {
                Pagina = request.PaginaInicial,
                Total = totalCount,
                Links = GenerateHateoasLinks(request, totalCount),
                Pedidos = items.Select(MapPedidoToDto).ToList()
            };

            return response;
        }

        /// <summary>
        /// Mapeia entidade Pedido para DTO simplificado
        /// </summary>
        private PedidoDto MapPedidoToDto(Pedido pedido)
        {
            return new PedidoDto
            {
                PedidoId = pedido.Id,
                Cliente = pedido.ClienteNome,
                UF = pedido.UF ?? string.Empty,
                Valor = pedido.ValorTotal
            };
        }

        /// <summary>
        /// Gera links HATEOAS para a versão simplificada
        /// </summary>
        private List<LinkDto> GenerateHateoasLinks(PedidoSearchRequest request, int totalCount)
        {
            var links = new List<LinkDto>();
            var baseUrl = "/api/pedidos";
            var totalPages = (int)Math.Ceiling((double)totalCount / request.TotalItensPagina);

            // Gera query string com todos os parâmetros
            var queryParams = BuildQueryString(request);

            // Link para primeira página (sempre presente se não estiver na primeira)
            if (request.PaginaInicial > 1)
            {
                var firstPageParams = BuildQueryString(request, 1);
                links.Add(new LinkDto
                {
                    Rel = "first",
                    Href = $"{baseUrl}?{firstPageParams}",
                    Method = "GET"
                });
            }

            // Link para página anterior
            if (request.PaginaInicial > 1)
            {
                var prevPageParams = BuildQueryString(request, request.PaginaInicial - 1);
                links.Add(new LinkDto
                {
                    Rel = "prev",
                    Href = $"{baseUrl}?{prevPageParams}",
                    Method = "GET"
                });
            }

            // Link para próxima página
            if (request.PaginaInicial < totalPages)
            {
                var nextPageParams = BuildQueryString(request, request.PaginaInicial + 1);
                links.Add(new LinkDto
                {
                    Rel = "next",
                    Href = $"{baseUrl}?{nextPageParams}",
                    Method = "GET"
                });
            }

            // Link para última página
            if (request.PaginaInicial < totalPages && totalPages > 1)
            {
                var lastPageParams = BuildQueryString(request, totalPages);
                links.Add(new LinkDto
                {
                    Rel = "last",
                    Href = $"{baseUrl}?{lastPageParams}",
                    Method = "GET"
                });
            }

            // Link para página atual (self)
            links.Add(new LinkDto
            {
                Rel = "self",
                Href = $"{baseUrl}?{queryParams}",
                Method = "GET"
            });

            return links;
        }

        /// <summary>
        /// Constrói a query string com todos os parâmetros
        /// </summary>
        private string BuildQueryString(PedidoSearchRequest request, int? pageOverride = null)
        {
            var queryParams = new List<string>();
            
            // Página
            var page = pageOverride ?? request.PaginaInicial;
            queryParams.Add($"paginaInicial={page}");
            
            // Total de itens por página
            queryParams.Add($"totalItensPagina={request.TotalItensPagina}");
            
            // Filtros (apenas se não forem nulos/vazios)
            if (!string.IsNullOrWhiteSpace(request.NumeroPedido))
                queryParams.Add($"numeroPedido={Uri.EscapeDataString(request.NumeroPedido)}");
                
            if (!string.IsNullOrWhiteSpace(request.NomeCliente))
                queryParams.Add($"nomeCliente={Uri.EscapeDataString(request.NomeCliente)}");
                
            if (!string.IsNullOrWhiteSpace(request.UF))
                queryParams.Add($"uf={Uri.EscapeDataString(request.UF)}");

            return string.Join("&", queryParams);
        }

    }
}
