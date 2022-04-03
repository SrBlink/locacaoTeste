using AutoMoqCore;
using Locacao.Application.Dtos;
using Locacao.Application.Validations;
using System;
using Xunit;

namespace Locacao.Application.Tests.Validations
{
    [Collection(nameof(LocacaoAppServiceCollection))]
    public class ReservaRequestPatchDtoValidatorTests : BaseTests<ReservaRequestPatchDto, ReservaRequestPatchDtoValidator>
    {
        private readonly LocacaoTestsFixture _fixture;
        private readonly ReservaRequestPatchDtoValidator _reservaRequestPatchDtoValidator;

        public ReservaRequestPatchDtoValidatorTests(LocacaoTestsFixture fixture)
        {
            _fixture = fixture;

            var mocker = new AutoMoqer();
            _reservaRequestPatchDtoValidator = mocker.Resolve<ReservaRequestPatchDtoValidator>();
        }

        #region Sucesso

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarReservaRequestPatchDtoValidator - Sucesso")]
        public void CriarResertaRequestPostDtoValidator() =>
            Validate_Sucesso(_fixture.CriarReservaRequestPatchDto(dataRetirada: DateTime.Now, dataPrevistaDevolucao: DateTime.Now), _reservaRequestPatchDtoValidator);

        #endregion Sucesso

        #region Data Retirada

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarReservaRequestPatchDtoValidator - Data Retirada não preenchido")]
        public void CriarReservaRequestPatchDtoValidator_DataRetiradaNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarReservaRequestPatchDto(dataRetirada: default),
                _reservaRequestPatchDtoValidator,
                MensagemCampoObrigatorio("Data Retirada")
            );

        #endregion Data Retirada

        #region Data Prevista Devolucao

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarReservaRequestPatchDtoValidator - Data Prevista Devolução não preenchido")]
        public void CriarReservaRequestPatchDtoValidator_DataPrevistaDevolucaoNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarReservaRequestPatchDto(dataPrevistaDevolucao: default),
                _reservaRequestPatchDtoValidator,
                MensagemCampoObrigatorio("Data Prevista Devolução")
            );

        #endregion Data Prevista Devolucao
    }
}