using Locacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Services
{
    public interface IFabricanteService
    {
        Task<Fabricante> GetByNomeAsync(string nome);
    }
}
