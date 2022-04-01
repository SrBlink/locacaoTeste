using Locacao.Application.Addapters;
using Locacao.Application.Dtos;
using Locacao.Application.Interfaces;
using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Services;
using Locacao.Domain.Interfaces.UoW;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Application.Service
{
    public class VeiculoAppService : BaseAppService, IVeiculoAppService
    {
        private readonly IVeiculoService _service;
        private readonly IUnitOfWork _uow;

        public VeiculoAppService(IVeiculoService service, IUnitOfWork uow)
        {
            _service = service;
            _uow = uow;
        }

        public async Task<bool> CadastrarAsync(VeiculoPostDto veiculoDto)
        {
            var veiculo = FromVeiculoPostDtoToVeiculo.Adapt(veiculoDto);

            await _service.AddAsync(veiculo);

            return await _uow.CommitAsync();
        }

        public async Task<IEnumerable<VeiculoGetDto>> ConsultarPorModeloFabricante(string busca)
        {
            IEnumerable<Veiculo> veiculo = await _service.ConsultarPorModeloFabricante(busca);

            return FromVeiculoToVeiculoDto.Adapt(veiculo);
        }

        public async Task<IEnumerable<VeiculoGetDto>> ConsultarPorPlacaAsync(string busca)
        {
            IEnumerable<Veiculo> veiculo = await _service.ConsultarPorPlacaAsync(busca);

            return FromVeiculoToVeiculoDto.Adapt(veiculo);

        }
    }
}