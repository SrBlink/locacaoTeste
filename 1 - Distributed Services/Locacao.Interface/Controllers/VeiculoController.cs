using Locacao.Application.Dtos;
using Locacao.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Locacao.Interface.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoAppService _appService;

        public VeiculoController(IVeiculoAppService appService)
        {
            _appService = appService;
        }

       
        [HttpPost]
        public async Task<IActionResult> Cadastrar(VeiculoPostDto veiculo) {
            var result = await _appService.CadastrarAsync(veiculo);
            return Ok(result);
        }

        [HttpGet("lista")]
        public async Task<IActionResult> Consultar([FromQuery] string busca)
        {

            var result = await _appService.ConsultarPorPlacaAsync(busca);
            return Ok(result);
        }

        [HttpGet("modelo")]
        public async Task<IActionResult> ConsultarPorModeloFabricante([FromQuery] string busca)
        {

            var result = await _appService.ConsultarPorModeloFabricante(busca);
            return Ok(result);
        }

    }
}
