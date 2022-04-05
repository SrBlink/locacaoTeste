using Locacao.Domain.Entities;
using Locacao.Domain.Exceptions;
using Locacao.Domain.Interfaces.Repositories;
using Locacao.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Locacao.Domain.Services
{
    public class ModeloService : BaseService, IModeloService
    {
        private readonly IModeloRepository _repository;

        public ModeloService(IModeloRepository repository)
        {
            _repository = repository;
        }

        public async Task<Modelo> GetByIdAsync(Guid modeloId)
        {
            var modelo = await _repository.GetByIdAsync(modeloId);

            if (modelo == null) throw new DomainException("Este modelo de veiculo não existe.");

            return modelo;
        }

        public async Task<Modelo> GetByNomeAsync(string modeloNome)
        {
            var modelo = await _repository.GetByNomeAsync(modeloNome);
            return modelo;
        }
    }
}