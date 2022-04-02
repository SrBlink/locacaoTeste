﻿using Locacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Services
{
    public interface IVeiculoService
    {
        Task AddAsync(Veiculo veiculo);
        Task<IEnumerable<Veiculo>> ConsultarPorPlacaAsync(string busca);
        Task<IEnumerable<Veiculo>> ConsultarPorModeloFabricanteAsync(string busca);
        Task VerifyExistsAsync(Guid veiculoId);
    }
}