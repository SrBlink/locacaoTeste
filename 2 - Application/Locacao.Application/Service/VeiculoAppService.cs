using Locacao.Application.Addapters;
using Locacao.Application.Dtos;
using Locacao.Application.Interfaces;
using Locacao.Application.Validations;
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
        private readonly VeiculoRequestPostDtoValidator _veiculoRequestPostDtoValidator;

        public VeiculoAppService(
            IVeiculoService service,
            VeiculoRequestPostDtoValidator veiculoRequestPostDtoValidator,
            IUnitOfWork uow)
        {
            _service = service;
            _uow = uow;
            _veiculoRequestPostDtoValidator = veiculoRequestPostDtoValidator;
        }

        public async Task<bool> CadastrarAsync(VeiculoRequestPostDto veiculoDto)
        {
            ValidarRequisicao(veiculoDto, _veiculoRequestPostDtoValidator);

            var veiculo = FromVeiculoRequestPostDtoToVeiculo.Adapt(veiculoDto);

            await _service.AddAsync(veiculo);

            return await _uow.CommitAsync();
        }

        public async Task<IEnumerable<VeiculoResponseGetDto>> ConsultarPorModeloFabricanteAsync(string busca)
        {
            IEnumerable<Veiculo> veiculo = await _service.ConsultarPorModeloFabricanteAsync(busca);

            return FromVeiculoToVeiculoResponseGetDto.Adapt(veiculo);
        }

        public async Task<IEnumerable<VeiculoResponseGetDto>> ConsultarPorPlacaAsync(string busca)
        {
            IEnumerable<Veiculo> veiculo = await _service.ConsultarPorPlacaAsync(busca);

            return FromVeiculoToVeiculoResponseGetDto.Adapt(veiculo);

        }
    }
}