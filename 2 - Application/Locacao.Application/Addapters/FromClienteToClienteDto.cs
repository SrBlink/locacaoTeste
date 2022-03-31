using Locacao.Application.Dtos;
using Locacao.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Locacao.Application.Addapters
{
    public static class FromClienteToClienteDto
    {
        public static ClienteDto Adapt(Cliente entity)
        {
            return new ClienteDto();
        }

        public static IEnumerable<ClienteDto> Adapt(IEnumerable<Cliente> entity)
        {
            var clienteDto = entity.Select(x => new ClienteDto
            {
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