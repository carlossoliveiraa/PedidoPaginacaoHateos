namespace PaginacaoEFiltros.Application.Common
{
    /// <summary>
    /// DTO para links de paginação HATEOAS
    /// </summary>
    public class PaginacaoLinksDto
    {
        /// <summary>
        /// URL da página atual
        /// </summary>
        public string? PaginaAtual { get; set; }

        /// <summary>
        /// URL da página anterior (null se for a primeira página)
        /// </summary>
        public string? PaginaAnterior { get; set; }

        /// <summary>
        /// URL da próxima página (null se for a última página)
        /// </summary>
        public string? ProximaPagina { get; set; }

        /// <summary>
        /// URL da primeira página
        /// </summary>
        public string? PrimeiraPagina { get; set; }

        /// <summary>
        /// URL da última página
        /// </summary>
        public string? UltimaPagina { get; set; }
    }
}
