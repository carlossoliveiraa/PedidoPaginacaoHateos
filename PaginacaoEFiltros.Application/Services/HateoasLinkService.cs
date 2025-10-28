using PaginacaoEFiltros.Application.Common;
using System.Web;

namespace PaginacaoEFiltros.Application.Services
{
    /// <summary>
    /// Serviço para geração de links HATEOAS
    /// </summary>
    public class HateoasLinkService : IHateoasLinkService
    {
        /// <summary>
        /// Gera links de paginação HATEOAS
        /// </summary>
        public PaginacaoLinksDto GerarLinksPaginacao(
            string baseUrl,
            int paginaAtual,
            int registrosPorPagina,
            int totalRegistros,
            Dictionary<string, string>? parametrosFiltro = null)
        {
            var totalPaginas = CalcularTotalPaginas(totalRegistros, registrosPorPagina);
            var parametros = parametrosFiltro ?? new Dictionary<string, string>();

            return new PaginacaoLinksDto
            {
                PaginaAtual = ConstruirUrl(baseUrl, paginaAtual, registrosPorPagina, parametros),
                PaginaAnterior = paginaAtual > 1 
                    ? ConstruirUrl(baseUrl, paginaAtual - 1, registrosPorPagina, parametros) 
                    : null,
                ProximaPagina = paginaAtual < totalPaginas 
                    ? ConstruirUrl(baseUrl, paginaAtual + 1, registrosPorPagina, parametros) 
                    : null,
                PrimeiraPagina = ConstruirUrl(baseUrl, 1, registrosPorPagina, parametros),
                UltimaPagina = totalPaginas > 0 
                    ? ConstruirUrl(baseUrl, totalPaginas, registrosPorPagina, parametros) 
                    : ConstruirUrl(baseUrl, 1, registrosPorPagina, parametros)
            };
        }

        /// <summary>
        /// Gera informações de paginação
        /// </summary>
        public PaginacaoInfoDto GerarInfoPaginacao(
            int paginaAtual,
            int registrosPorPagina,
            int totalRegistros)
        {
            var totalPaginas = CalcularTotalPaginas(totalRegistros, registrosPorPagina);

            return new PaginacaoInfoDto
            {
                Pagina = paginaAtual,
                RegistrosPagina = registrosPorPagina,
                TotalPaginas = totalPaginas,
                TotalRegistrosEncontrados = totalRegistros
            };
        }

        /// <summary>
        /// Calcula o total de páginas
        /// </summary>
        private static int CalcularTotalPaginas(int totalRegistros, int registrosPorPagina)
        {
            if (totalRegistros <= 0 || registrosPorPagina <= 0)
                return 0;

            return (int)Math.Ceiling((double)totalRegistros / registrosPorPagina);
        }

        /// <summary>
        /// Constrói URL com parâmetros de paginação e filtros
        /// </summary>
        private static string ConstruirUrl(
            string baseUrl,
            int pagina,
            int registrosPorPagina,
            Dictionary<string, string> parametros)
        {
            var queryParams = new List<string>
            {
                $"limite={registrosPorPagina}",
                $"pagina={pagina}"
            };

            // Adiciona parâmetros de filtro
            foreach (var parametro in parametros.Where(p => !string.IsNullOrWhiteSpace(p.Value)))
            {
                var valorCodificado = HttpUtility.UrlEncode(parametro.Value);
                queryParams.Add($"{parametro.Key}={valorCodificado}");
            }

            return $"{baseUrl}?{string.Join("&", queryParams)}";
        }
    }
}
