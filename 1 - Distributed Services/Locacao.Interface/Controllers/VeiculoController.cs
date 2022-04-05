using Locacao.Application.Dtos;
using Locacao.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Locacao.Interface.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoAppService _appService;

        public VeiculoController(IVeiculoAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// Cadastrar veiculo
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Cadastrar(VeiculoRequestPostDto veiculo)
        {
            var result = await _appService.CadastrarAsync(veiculo);
            return Ok(result);
        }

        /// <summary>
        /// Consultar veiculo
        /// </summary>
        /// <returns></returns>
        [HttpGet("lista")]
        public async Task<IActionResult> Consultar([FromQuery] string busca)
        {

            var result = await _appService.ConsultarPorPlacaAsync(busca);
            return Ok(result);
        }

        /// <summary>
        /// Consultar veiculo por modelo ou fabricante
        /// </summary>
        /// <returns></returns>
        [HttpGet("modelo")]
        public async Task<IActionResult> ConsultarPorModeloFabricante([FromQuery] string busca)
        {

            var result = await _appService.ConsultarPorModeloFabricanteAsync(busca);
            return Ok(result);
        }

    }
}
