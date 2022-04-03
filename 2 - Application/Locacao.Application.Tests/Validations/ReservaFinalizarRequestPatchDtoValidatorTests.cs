using AutoMoqCore;
using Locacao.Application.Dtos;
using Locacao.Application.Validations;
using System;
using Xunit;

namespace Locacao.Application.Tests.Validations
{
    [Collection(nameof(LocacaoAppServiceCollection))]
    public class ReservaFinalizarRequestPatchDtoValidatorTests : BaseTests<ReservaFinalizarRequestPatchDto, ReservaFinalizarRequestPatchDtoValidator>
    {
        private readonly LocacaoTestsFixture _fixture;
        private readonly ReservaFinalizarRequestPatchDtoValidator _reservaFinalizarRequestPatchDtoValidator;

        public ReservaFinalizarRequestPatchDtoValidatorTests(LocacaoTestsFixture fixture)
        {
            _fixture = fixture;

            var mocker = new AutoMoqer();
            _reservaFinalizarRequestPatchDtoValidator = mocker.Resolve<ReservaFinalizarRequestPatchDtoValidator>();
        }

        #region Sucesso

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarReservaFinalizarRequestPatchDtoValidator - Sucesso")]
        public void CriarReservaFinalizarRequestPatchDtoValidator() =>
            Validate_Sucesso(_fixture.CriarReservaFinalizarRequestPatchDto(dataDevolucao: DateTime.Now), _reservaFinalizarRequestPatchDtoValidator);

        #endregion Sucesso

        #region Data Devolucao

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarReservaFinalizarRequestPatchDtoValidator - Data Devolução não preenchido")]
        public void CriarReservaFinalizarRequestPatchDtoValidator_DataDevolucaoNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarReservaFinalizarRequestPatchDto(dataDevolucao: default),
                _reservaFinalizarRequestPatchDtoValidator,
                MensagemCampoObrigatorio("Data Devolução")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarReservaFinalizarRequestPatchDtoValidator - Data Devolução maior que data atual")]
        public void CriarReservaFinalizarRequestPatchDtoValidator_DataDevolucaoMaiorQueAtual() =>
            Validate_Falha(
                _fixture.CriarReservaFinalizarRequestPatchDto(dataDevolucao: DateTime.Now.AddDays(1)),
                _reservaFinalizarRequestPatchDtoValidator,
                MensagemDataMaiorQueAtual("Data Devolução")
            );

        #endregion Data Devolucao
    }
}