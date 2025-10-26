using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaginacaoEFiltros.Application.Common
{
    /// <summary>
    /// Requisição de paginação
    /// </summary>
    public class PaginacaoRequest
    {
        /// <summary>
        /// Indicador para exibir ou não os totais no retorno
        /// </summary>
        [DefaultValue(true)]
        public bool ExibirTotais { get; set; } = true;

        /// <summary>
        /// Pagina atual
        /// </summary>
        [Range(1, 150)]
        [DefaultValue(1)]
        public int PaginaAtual { get; set; } = 1;

        /// <summary>
        /// Itens por página
        /// </summary>
        [Range(5, 1000)]
        [DefaultValue(10)]
        public int ItensPorPagina { get; set; } = 10;

        /// <summary>
        /// Campo de ordenação
        /// </summary>
        [MaxLength(250)]
        public string? OrdemCampo { get; set; }

        /// <summary>
        /// Direção da ordenação
        /// </summary>
        [DefaultValue(false)]
        public bool OrdemDescendente { get; set; } = false;

        /// <summary>
        /// Cálculo interno de Skip
        /// </summary>
        [IgnoreDataMember, JsonIgnore]
        public int Skip => (PaginaAtual - 1) * ItensPorPagina;

        /// <summary>
        /// Cálculo interno de Take
        /// </summary>
        [IgnoreDataMember, JsonIgnore]
        public int Take => ItensPorPagina;
    }
}
