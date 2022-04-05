using AutoMoqCore;
using Locacao.Application.Dtos;
using Locacao.Application.Validations;
using Xunit;

namespace Locacao.Application.Tests.Validations
{
    [Collection(nameof(LocacaoAppServiceCollection))]
    public class VeiculoRequestPostDtoValidatorTests : BaseTests<VeiculoRequestPostDto, VeiculoRequestPostDtoValidator>
    {
        private readonly LocacaoTestsFixture _fixture;
        private readonly VeiculoRequestPostDtoValidator _veiculoRequestPostDtoValidator;

        public VeiculoRequestPostDtoValidatorTests(LocacaoTestsFixture fixture)
        {
            _fixture = fixture;

            var mocker = new AutoMoqer();
            _veiculoRequestPostDtoValidator = mocker.Resolve<VeiculoRequestPostDtoValidator>();
        }

        #region Sucesso

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarVeiculoRequestPostDtoValidator - Sucesso")]
        public void CriarVeiculoRequestPostDtoValidator_Sucesso() =>
            Validate_Sucesso(_fixture.CriarVeiculoRequestPostDto(), _veiculoRequestPostDtoValidator);

        #endregion Sucesso

        #region Placa

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarVeiculoRequestPostDtoValidator - Placa não preenchido")]
        public void CriarVeiculoRequestPostDtoValidator_PlacaNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarVeiculoRequestPostDto(placa: ""),
                _veiculoRequestPostDtoValidator,
                MensagemCampoObrigatorio("Placa")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarVeiculoRequestPostDtoValidator - Placa tamanho inválido")]
        public void CriarVeiculoRequestPostDtoValidator_PlacaTamanho() =>
            Validate_Falha(
                _fixture.CriarVeiculoRequestPostDto(placa: "".PadLeft(6, 'A')),
                _veiculoRequestPostDtoValidator,
                MensagemTamanhoCampo("Placa", 7)
            );

        #endregion Placa

        #region Modelo

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarVeiculoRequestPostDtoValidator - Modelo não preenchido")]
        public void CriarVeiculoRequestPostDtoValidator_ModeloNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarVeiculoRequestPostDto(modeloNome: ""),
                _veiculoRequestPostDtoValidator,
                MensagemCampoObrigatorio("Modelo")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarVeiculoRequestPostDtoValidator - Modelo acima do tamanho máximo")]
        public void CriarVeiculoRequestPostDtoValidator_ModeloTamanho() =>
            Validate_Falha(
                _fixture.CriarVeiculoRequestPostDto(modeloNome: "".PadLeft(251, 'A')),
                _veiculoRequestPostDtoValidator,
                MensagemTamanhoMaximoCampo("Modelo", 250)
            );

        #endregion Modelo

        #region Fabricante

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarVeiculoRequestPostDtoValidator - Fabricante não preenchido")]
        public void CriarVeiculoRequestPostDtoValidator_FabricanteNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarVeiculoRequestPostDto(fabricanteNome: ""),
                _veiculoRequestPostDtoValidator,
                MensagemCampoObrigatorio("Fabricante")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "CriarVeiculoRequestPostDtoValidator - Fabricante acima do tamanho máximo")]
        public void CriarVeiculoRequestPostDtoValidator_FabricanteTamanho() =>
            Validate_Falha(
                _fixture.CriarVeiculoRequestPostDto(fabricanteNome: "".PadLeft(251, 'A')),
                _veiculoRequestPostDtoValidator,
                MensagemTamanhoMaximoCampo("Fabricante", 250)
            );

        #endregion Fabricante
    }
}