using Microsoft.AspNetCore.Mvc;
using PaginacaoEFiltros.Application.DTOs;
using PaginacaoEFiltros.Application.Services;

namespace PaginacaoEFiltros.Api.Controllers
{
    /// <summary>
    /// Controller para operações com Pedidos
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        /// <summary>
        /// Pesquisa pedidos com filtros e paginação
        /// </summary>
        /// <param name="request">Requisição de pesquisa com filtros</param>
        /// <returns>Resultado da pesquisa com paginação</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PedidoSearchResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] PedidoSearchRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!request.IsValid())
                return BadRequest("Parâmetros de pesquisa inválidos.");

            var response = await _pedidoService.SearchSimplifiedAsync(request);
            return Ok(response);
        }
    }
}
