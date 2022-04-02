using Locacao.Application.Dtos;
using Locacao.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Locacao.Interface.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaAppService _appService;

        public ReservaController(IReservaAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// Cadastrar reserva para um cliente
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Cadastrar(ReservaRequestPostDto reserva) {
            var result = await _appService.CadastrarAsync(reserva);
            return Ok(result);
        }

        /// <summary>
        /// Obter reservas de um cliente
        /// </summary>
        /// <returns></returns>
        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> Obter([FromRoute] Guid clienteId)
        {
            var result = await _appService.ObterRerservasClienteAsync(clienteId);
            return Ok(result);
        }

        /// <summary>
        /// Obter reservas dentro de um intervalo de datas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ObterReservas([FromQuery] DateTime dataInicial, DateTime dataFinal)
        {
            var result = await _appService.ObterReservasAsync(dataInicial,dataFinal);
            return Ok(result);
        }

        /// <summary>
        /// Obter reservas vencidas
        /// </summary>
        /// <returns></returns>
        [HttpGet("vencida")]
        public async Task<IActionResult> ObterReservasVencidas()
        {
            var result = await _appService.ObterReservasVencidasAsync();
            return Ok(result);
        }

        /// <summary>
        /// Atualizar reserva de um cliente
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{id}/cliente")]
        public async Task<IActionResult> AtualizarReservaCliente([FromRoute] Guid id,ReservaRequestPatchDto reservaData )
        {
            var result = await _appService.AtualizarReservaClienteAsync(id , reservaData);
            return Ok(result);
        }

        /// <summary>
        /// Finalizar reserva de um cliente
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{id}/finalizar")]
        public async Task<IActionResult> FinalizarReserva([FromRoute] Guid id, ReservaFinalizarRequestPatchDto reserva)
        {
            var result = await _appService.FinalizarReservaAsync(id,reserva);
            return Ok(result);
        }
    }
}
