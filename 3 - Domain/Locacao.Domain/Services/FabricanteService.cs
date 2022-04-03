using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Repositories;
using Locacao.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Domain.Services
{
    public class FabricanteService : BaseService , IFabricanteService
    {
        private readonly IFabricanteRepository _repository;

        public FabricanteService(IFabricanteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Fabricante> GetByNomeAsync(string fabricanteNome)
        {
            var fabricante = await _repository.GetByNomeAsync(fabricanteNome);
            return fabricante;
        }
    }
}
