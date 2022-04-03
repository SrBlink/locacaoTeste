using AutoMoqCore;
using Locacao.Application.Dtos;
using Locacao.Application.Validations;
using System;
using Xunit;

namespace Locacao.Application.Tests.Validations
{
    [Collection(nameof(LocacaoAppServiceCollection))]
    public class ReservaRequestPostDtoValidatorTests : BaseTests<ReservaRequestPostDto, ReservaRequestPostDtoValidator>
    {
        private readonly LocacaoTestsFixture _fixture;
        private readonly ReservaRequestPostDtoValidator _reservaRequestPostDtoValidator;

        public ReservaRequestPostDtoValidatorTests(LocacaoTestsFixture fixture)
        {
            _fixture = fixture;

            var mocker = new AutoMoqer();
            _reservaRequestPostDtoValidator = mocker.Resolve<ReservaRequestPostDtoValidator>();
        }

        #region Sucesso

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarReservaRequestPostDtoValidator - Sucesso")]
        public void CriarResertaRequestPostDtoValidator() =>
            Validate_Sucesso(_fixture.CriarReservaRequestPostDto(clienteId: Guid.NewGuid(), veiculoId: Guid.NewGuid()), _reservaRequestPostDtoValidator);

        #endregion Sucesso

        #region Cliente

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarReservaRequestPostDtoValidator - Cliente não preenchido")]
        public void CriarReservaRequestPostDtoValidator_ClienteNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarReservaRequestPostDto(clienteId: Guid.Empty),
                _reservaRequestPostDtoValidator,
                MensagemCampoObrigatorio("Cliente")
            );

        #endregion Cliente

        #region Veiculo

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarReservaRequestPostDtoValidator - Veiculo não preenchido")]
        public void CriarReservaRequestPostDtoValidator_VeiculoNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarReservaRequestPostDto(veiculoId: Guid.Empty),
                _reservaRequestPostDtoValidator,
                MensagemCampoObrigatorio("Veiculo")
            );

        #endregion Veiculo

        #region DataRetirada

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarReservaRequestPostDtoValidator - Data de Retirada não informada")]
        public void CriarReservaRequestPostDtoValidator_DataRetiradaNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarReservaRequestPostDto(dataRetirada: null, dataPrevisaDevolucao : DateTime.Now),
                _reservaRequestPostDtoValidator,
                MensagemCampoObrigatorio("Data Retirada")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarReservaRequestPostDtoValidator - Data de Retirada maior que data atual")]
        public void CriarReservaRequestPostDtoValidator_DataRetiradaMaiorQueAtual() =>
            Validate_Falha(
                _fixture.CriarReservaRequestPostDto(dataRetirada: DateTime.Now.AddDays(1)),
                _reservaRequestPostDtoValidator,
                MensagemDataMaiorQueAtual("Data Retirada")
            );

        #endregion

        #region Data Prevista Devolucao

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarReservaRequestPostDtoValidator - Data Prevista Devolução menor que data retirada")]
        public void CriarReservaRequestPostDtoValidator_DataPrevistaDevolucaoAnteriorData() =>
            Validate_Falha(
                _fixture.CriarReservaRequestPostDto(dataRetirada: DateTime.Now, dataPrevisaDevolucao: DateTime.Now.AddDays(-1)),
                _reservaRequestPostDtoValidator,
                MensagemCampoMenorQueOutro("Data Prevista Devolução",  "Data Retirada")
            );


        #endregion

    }
}