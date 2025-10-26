using System;

namespace PaginacaoEFiltros.Application.Common
{
    /// <summary>
    /// Retorno de paginação
    /// </summary>
    public abstract class PaginacaoResponse<TRequest, TRow>
        where TRequest : PaginacaoRequest
    {
        /// <summary>
        /// Requisição de paginação
        /// </summary>
        public TRequest? Request { get; set; }

        /// <summary>
        /// Quantidade de itens encontrados
        /// </summary>
        public int? TotalItens { get; set; }

        /// <summary>
        /// Quantidade de páginas encontradas
        /// </summary>
        public int? TotalPaginas
        {
            get => TotalItens is null 
                ? null 
                : Request?.ItensPorPagina > 0
                && TotalItens > 0
                ? (int)Math.Ceiling(
                    TotalItens.Value
                    / (double)Request.ItensPorPagina)
                : 0;
        }

        /// <summary>
        /// Itens encontrados
        /// </summary>
        public IEnumerable<TRow> Itens { get; set; } = new List<TRow>();
    }

    /// <summary>
    /// Retorno de paginação
    /// </summary>
    public abstract class PaginacaoResponse<TRow>
        : PaginacaoResponse<PaginacaoRequest, TRow>
    { }
}
