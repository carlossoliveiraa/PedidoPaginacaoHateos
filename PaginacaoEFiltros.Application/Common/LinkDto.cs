namespace PaginacaoEFiltros.Application.Common
{
    /// <summary>
    /// DTO para links HATEOAS
    /// </summary>
    public class LinkDto
    {
        /// <summary>
        /// Relação do link
        /// </summary>
        public string Rel { get; set; } = string.Empty;

        /// <summary>
        /// URL do link
        /// </summary>
        public string Href { get; set; } = string.Empty;

        /// <summary>
        /// Método HTTP
        /// </summary>
        public string Method { get; set; } = string.Empty;
    }
}
