using PaginacaoEFiltros.Application.Common;

namespace PaginacaoEFiltros.Application.Services
{
    /// <summary>
    /// Interface para serviço de geração de links HATEOAS
    /// </summary>
    public interface IHateoasLinkService
    {
        /// <summary>
        /// Gera links de paginação HATEOAS
        /// </summary>
        /// <param name="baseUrl">URL base da API</param>
        /// <param name="paginaAtual">Página atual</param>
        /// <param name="registrosPorPagina">Registros por página</param>
        /// <param name="totalRegistros">Total de registros</param>
        /// <param name="parametrosFiltro">Parâmetros de filtro para manter na URL</param>
        /// <returns>Links de paginação</returns>
        PaginacaoLinksDto GerarLinksPaginacao(
            string baseUrl,
            int paginaAtual,
            int registrosPorPagina,
            int totalRegistros,
            Dictionary<string, string>? parametrosFiltro = null);

        /// <summary>
        /// Gera informações de paginação
        /// </summary>
        /// <param name="paginaAtual">Página atual</param>
        /// <param name="registrosPorPagina">Registros por página</param>
        /// <param name="totalRegistros">Total de registros</param>
        /// <returns>Informações de paginação</returns>
        PaginacaoInfoDto GerarInfoPaginacao(
            int paginaAtual,
            int registrosPorPagina,
            int totalRegistros);
    }
}
