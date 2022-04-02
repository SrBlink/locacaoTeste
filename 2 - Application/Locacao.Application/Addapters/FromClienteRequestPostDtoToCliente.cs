using Locacao.Application.Dtos;
using Locacao.Domain.Entities;
using System;

namespace Locacao.Application.Addapters
{
    public static class FromClienteRequestPostDtoToCliente
    {
        public static Cliente Adapt(ClienteRequestPostDto request)
        {
            return new Cliente() {
                Nome = request.Nome,
                Cpf = request.Cpf,
                Cnh = request.Cnh,
                Bairro = request.Bairro,
                Cidade = request.Cidade,
                DataNascimento = request.DataNascimento,
                Logradouro = request.Logradouro,
                NumeroResidencia = request.NumeroResidencia
            };
        }
    }
}