using AutoMoqCore;
using Locacao.Application.Dtos;
using Locacao.Application.Validations;
using Xunit;

namespace Locacao.Application.Tests.Validations
{
    [Collection(nameof(LocacaoAppServiceCollection))]
    public class ClienteEnderecoRequestPatchDtoValidatorTests : BaseTests<ClienteEnderecoRequestPatchDto, ClienteEnderecoRequestPatchDtoValidator>
    {
        private readonly LocacaoTestsFixture _fixture;
        private readonly ClienteEnderecoRequestPatchDtoValidator _clienteEnderecoRequestPatchDtoValidator;

        public ClienteEnderecoRequestPatchDtoValidatorTests(LocacaoTestsFixture fixture)
        {
            _fixture = fixture;

            var mocker = new AutoMoqer();
            _clienteEnderecoRequestPatchDtoValidator = mocker.Resolve<ClienteEnderecoRequestPatchDtoValidator>();
        }

        #region Sucesso

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Sucesso")]
        public void ClienteRequestPostDtoValidator_Sucesso() =>
            Validate_Sucesso(_fixture.CriarClienteEnderecoRequestPatchDto(), _clienteEnderecoRequestPatchDtoValidator);

        #endregion Sucesso

        #region Logradouro

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Logradouro não preenchido")]
        public void ClienteRequestPostDtoValidator_LogradouroNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarClienteEnderecoRequestPatchDto(logradouro: ""),
                _clienteEnderecoRequestPatchDtoValidator,
                MensagemCampoObrigatorio("Logradouro")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Logradouro acima do tamanho máximo")]
        public void ClienteRequestPostDtoValidator_LogradouroMaximo() =>
            Validate_Falha(
                _fixture.CriarClienteEnderecoRequestPatchDto(logradouro: "".PadLeft(61, 'A')),
                _clienteEnderecoRequestPatchDtoValidator,
                MensagemTamanhoMaximoCampo("Logradouro", 60)
            );

        #endregion Logradouro

        #region Bairro

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Bairro não preenchido")]
        public void ClienteRequestPostDtoValidator_BairroNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarClienteEnderecoRequestPatchDto(bairro: ""),
                _clienteEnderecoRequestPatchDtoValidator,
                MensagemCampoObrigatorio("Bairro")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Bairro acima do tamanho máximo")]
        public void ClienteRequestPostDtoValidator_BairroMaximo() =>
            Validate_Falha(
                _fixture.CriarClienteEnderecoRequestPatchDto(bairro: "".PadLeft(61, 'A')),
                _clienteEnderecoRequestPatchDtoValidator,
                MensagemTamanhoMaximoCampo("Bairro", 60)
            );

        #endregion Bairro

        #region Numero Residencia

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Numero Residencia não preenchido")]
        public void ClienteRequestPostDtoValidator_NumeroResidenciaNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarClienteEnderecoRequestPatchDto(numeroResidencia: ""),
                _clienteEnderecoRequestPatchDtoValidator,
                MensagemCampoObrigatorio("Numero Residencia")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Numero Residencia acima do tamanho máximo")]
        public void ClienteRequestPostDtoValidator_NumeroResidenciaMaximo() =>
            Validate_Falha(
                _fixture.CriarClienteEnderecoRequestPatchDto(numeroResidencia: "".PadLeft(11, '4')),
                _clienteEnderecoRequestPatchDtoValidator,
                MensagemTamanhoMaximoCampo("Numero Residencia", 10)
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Numero Residencia não possui somente números")]
        public void ClienteRequestPostDtoValidator_NumeroResidenciaNumerico() =>
            Validate_Falha(
                _fixture.CriarClienteEnderecoRequestPatchDto(numeroResidencia: "AAA"),
                _clienteEnderecoRequestPatchDtoValidator,
                MensagemCampoNumerico("Numero Residencia")
            );

        #endregion Numero Residencia

        #region Cidade

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Cidade não preenchido")]
        public void ClienteRequestPostDtoValidator_CidadeNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarClienteEnderecoRequestPatchDto(cidade: ""),
                _clienteEnderecoRequestPatchDtoValidator,
                MensagemCampoObrigatorio("Cidade")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Cidade acima do tamanho máximo")]
        public void ClienteRequestPostDtoValidator_CidadeMaximo() =>
            Validate_Falha(
                _fixture.CriarClienteEnderecoRequestPatchDto(cidade: "".PadLeft(251, 'A')),
                _clienteEnderecoRequestPatchDtoValidator,
                MensagemTamanhoMaximoCampo("Cidade", 250)
            );

        #endregion Cidade
    }
}