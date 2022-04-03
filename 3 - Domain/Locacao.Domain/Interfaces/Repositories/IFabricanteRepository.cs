using Locacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Repositories
{
    public interface IFabricanteRepository
    {
        Task<Fabricante> GetByNomeAsync(string fabricanteNome);
    }
}
