namespace PaginacaoEFiltros.Application.Common
{
    /// <summary>
    /// DTO para informações de paginação
    /// </summary>
    public class PaginacaoInfoDto
    {
        /// <summary>
        /// Página atual
        /// </summary>
        public int Pagina { get; set; }

        /// <summary>
        /// Registros por página
        /// </summary>
        public int RegistrosPagina { get; set; }

        /// <summary>
        /// Total de páginas
        /// </summary>
        public int TotalPaginas { get; set; }

        /// <summary>
        /// Total de registros encontrados
        /// </summary>
        public int TotalRegistrosEncontrados { get; set; }
    }
}
