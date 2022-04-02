using Locacao.Application.Dtos;
using Locacao.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Locacao.Interface.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaAppService _appService;

        public ReservaController(IReservaAppService appService)
        {
            _appService = appService;
        }

       
        [HttpPost]
        public async Task<IActionResult> Cadastrar(ReservaRequestPostDto reserva) {
            var result = await _appService.CadastrarAsync(reserva);
            return Ok(result);
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> Obter([FromRoute] Guid clienteId)
        {
            var result = await _appService.ObterRerservasClienteAsync(clienteId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ObterReservas([FromQuery] DateTime dataInicial, DateTime dataFinal)
        {
            var result = await _appService.ObterReservasAsync(dataInicial,dataFinal);
            return Ok(result);
        }

    }
}
