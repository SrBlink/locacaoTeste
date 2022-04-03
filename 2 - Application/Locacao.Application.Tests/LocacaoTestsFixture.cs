using Locacao.Application.Dtos;
using System;
using Xunit;

namespace Locacao.Application.Tests
{
    [CollectionDefinition(nameof(LocacaoAppServiceCollection))]
    public class LocacaoAppServiceCollection : ICollectionFixture<LocacaoTestsFixture>
    { }

    public class LocacaoTestsFixture
    {
        public ClienteRequestPostDto CriarClienteRequestPostDto(
                string nome = "thyago",
                string cpf = "42909647021",
                DateTime dataNascimento = default,
                string cnh = "123456789",
                string logradouro = "Rua bla bla bla",
                string numeroResidencia = "1500",
                string bairro = "Bairro",
                string cidade = "Cidade"

            ) => new ClienteRequestPostDto
            {
                Nome = nome,
                Cpf = cpf,
                DataNascimento = dataNascimento,
                Cnh = cnh,
                Logradouro = logradouro,
                NumeroResidencia = numeroResidencia,
                Bairro = bairro,
                Cidade = cidade
            };
    }
}