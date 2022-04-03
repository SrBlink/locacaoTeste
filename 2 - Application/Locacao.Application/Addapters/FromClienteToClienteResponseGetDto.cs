﻿using Locacao.Application.Dtos;
using Locacao.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Locacao.Application.Addapters
{
    public static class FromClienteToClienteResponseGetDto
    {
        public static IEnumerable<ClienteResponseGetDto> Adapt(IEnumerable<Cliente> entity)
        {
            var clienteDto = entity.Select(x => new ClienteResponseGetDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Cpf = x.Cpf,
                Cnh = x.Cnh,
                DataNascimento = x.DataNascimento,
                Logradouro = x.Logradouro,
                NumeroResidencia = x.NumeroResidencia,
                Bairro = x.Bairro,
                Cidade = x.Cidade
            });

            return clienteDto;
        }
    }
}