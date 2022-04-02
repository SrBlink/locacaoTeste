using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Repositories;
using Locacao.Domain.Interfaces.Services;
using Locacao.Infrastructure.CrossCuting.Exceptions;
using Locacao.Infrastructure.CrossCuting.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Domain.Services
{
    public class VeiculoService : BaseService, IVeiculoService
    {
        private readonly IVeiculoRepository _repository;
        private readonly IModeloService _modeloService;

        public VeiculoService(IVeiculoRepository repository, IModeloService modeloService)
        {
            _repository = repository;
            _modeloService = modeloService;
        }

        public async Task AddAsync(Veiculo veiculo)
        {
            veiculo.Placa = veiculo.Placa.RemoveMaskPlaca();

            var placaValida = veiculo.Placa.ValidarPlaca();

            if (!placaValida) throw new DomainException("Informe uma placa válida.");

            var existeVeiculo = await _repository.ObterPorPlacaAsync(veiculo.Placa);

            if (existeVeiculo != null) throw new DomainException("Já existe um veiculo cadastrado com esta placa.");

            await _modeloService.GetByIdAsync(veiculo.ModeloId);

            await _repository.AddAsync(veiculo);
        }

        public async Task<Veiculo> GetById(Guid id)
        {
            var veiculo = await _repository.GetByIdAsync(id);

            if (veiculo == null) throw new DomainException("Este veiculo não existe.");

            return veiculo;
        }

        public async Task<IEnumerable<Veiculo>> ConsultarPorPlacaAsync(string busca)
        {
            IEnumerable<Veiculo> veiculos = await _repository.ConsultarPorPlacaAsync(busca);
            return veiculos;
        }

        public async Task<IEnumerable<Veiculo>> ConsultarPorModeloFabricanteAsync(string busca)
        {
            IEnumerable<Veiculo> veiculos = await _repository.ConsultarPorModeloFabricanteAsync(busca);
            return veiculos;
        }

        public async Task VerifyExistsAsync(Guid id)
        {
            var existVeiculo = await _repository.VerifyExistsAsync(id);

            if (!existVeiculo) throw new DomainException("Veiculo não encontrado.");
        }
    }
}