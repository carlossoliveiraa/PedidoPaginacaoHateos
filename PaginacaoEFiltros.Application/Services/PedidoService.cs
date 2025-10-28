using PaginacaoEFiltros.Application.Common;
using PaginacaoEFiltros.Application.Interfaces;
using PaginacaoEFiltros.Application.Domain.DTOs;
using PaginacaoEFiltros.Application.Domain.Entities;

namespace PaginacaoEFiltros.Application.Services
{
    /// <summary>
    /// Serviço para operações com Pedidos
    /// </summary>
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;
        private readonly IHateoasLinkService _hateoasLinkService;

        public PedidoService(IPedidoRepository repository, IHateoasLinkService hateoasLinkService)
        {
            _repository = repository;
            _hateoasLinkService = hateoasLinkService;
        }


        /// <summary>
        /// Pesquisa pedidos com filtros e paginação (versão simplificada)
        /// </summary>
        public async Task<PedidoSearchResponse> SearchSimplifiedAsync(PedidoSearchRequest request, string baseUrl)
        {
            var (items, totalCount) = await _repository.SearchAsync(request);

            // Prepara parâmetros de filtro para os links
            var parametrosFiltro = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(request.NumeroPedido))
                parametrosFiltro["numero-pedido"] = request.NumeroPedido;
            if (!string.IsNullOrWhiteSpace(request.NomeCliente))
                parametrosFiltro["nome-cliente"] = request.NomeCliente;
            if (!string.IsNullOrWhiteSpace(request.UF))
                parametrosFiltro["uf"] = request.UF;

            var response = new PedidoSearchResponse
            {
                Links = _hateoasLinkService.GerarLinksPaginacao(
                    baseUrl,
                    request.Pagina,
                    request.Limite,
                    totalCount,
                    parametrosFiltro),
                Paginacao = _hateoasLinkService.GerarInfoPaginacao(
                    request.Pagina,
                    request.Limite,
                    totalCount),
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


    }
}
