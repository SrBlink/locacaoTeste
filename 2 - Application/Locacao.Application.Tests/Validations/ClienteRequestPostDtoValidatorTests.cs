using AutoMoqCore;
using Locacao.Application.Dtos;
using Locacao.Application.Validations;
using Xunit;

namespace Locacao.Application.Tests.Validations
{
    [Collection(nameof(LocacaoAppServiceCollection))]
    public class ClienteRequestPostDtoValidatorTests : BaseTests<ClienteRequestPostDto, ClienteRequestPostDtoValidator>
    {
        private readonly LocacaoTestsFixture _fixture;
        private readonly ClienteRequestPostDtoValidator _clienteRequestPostDtoValidator;

        public ClienteRequestPostDtoValidatorTests(LocacaoTestsFixture fixture)
        {
            _fixture = fixture;

            var mocker = new AutoMoqer();
            _clienteRequestPostDtoValidator = mocker.Resolve<ClienteRequestPostDtoValidator>();
        }

        #region Sucesso

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Sucesso")]
        public void ClienteRequestPostDtoValidator_Sucesso() =>
            Validate_Sucesso(_fixture.CriarClienteRequestPostDto(), _clienteRequestPostDtoValidator);

        #endregion Sucesso

        #region Nome

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Nome não preenchido")]
        public void ClienteRequestPostDtoValidator_NomeNaoPreenchido() =>
            Validate_Falha(_fixture.CriarClienteRequestPostDto(nome: ""), _clienteRequestPostDtoValidator, MensagemCampoObrigatorio("Nome"));

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Nome acima do tamanho máximo")]
        public void ClienteRequestPostDtoValidator_NomeMaximo() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(nome: "".PadLeft(251, 'A')),
                _clienteRequestPostDtoValidator,
                MensagemTamanhoMaximoCampo("Nome", 250)
            );

        #endregion Nome

        #region DataNascimento

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Data Nascimento não preenchido")]
        public void ClienteRequestPostDtoValidator_DataNascimentoNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(dataNascimento: default),
                _clienteRequestPostDtoValidator,
                MensagemCampoObrigatorio("Data Nascimento")
            );

        #endregion DataNascimento

        #region Cpf

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Cpf não preenchido")]
        public void ClienteRequestPostDtoValidator_CpfNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(cpf: ""),
                _clienteRequestPostDtoValidator,
                MensagemCampoObrigatorio("Cpf")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Cpf acima do tamanho máximo")]
        public void ClienteRequestPostDtoValidator_CpfMaximo() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(cpf: "".PadLeft(10, '4')),
                _clienteRequestPostDtoValidator,
                MensagemTamanhoCampo("Cpf", 11)
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Cpf não possui somente números")]
        public void ClienteRequestPostDtoValidator_CpfNumerico() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(cpf: "AAAAAAAAAAA"),
                _clienteRequestPostDtoValidator,
                MensagemCampoNumerico("Cpf")
            );

        #endregion Cpf

        #region Cnh

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Cnh não preenchido")]
        public void ClienteRequestPostDtoValidator_CnhNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(cnh: ""),
                _clienteRequestPostDtoValidator,
                MensagemCampoObrigatorio("Cnh")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Cnh acima do tamanho máximo")]
        public void ClienteRequestPostDtoValidator_CnhMaximo() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(cnh: "".PadLeft(51, '4')),
                _clienteRequestPostDtoValidator,
                MensagemTamanhoMaximoCampo("Cnh", 50)
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Cnh não possui somente números")]
        public void ClienteRequestPostDtoValidator_CnhNumerico() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(cnh: "AAAAAAAAAAA"),
                _clienteRequestPostDtoValidator,
                MensagemCampoNumerico("Cnh")
            );

        #endregion Cnh

        #region Logradouro

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Logradouro não preenchido")]
        public void ClienteRequestPostDtoValidator_LogradouroNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(logradouro: ""),
                _clienteRequestPostDtoValidator,
                MensagemCampoObrigatorio("Logradouro")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Logradouro acima do tamanho máximo")]
        public void ClienteRequestPostDtoValidator_LogradouroMaximo() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(logradouro: "".PadLeft(61, 'A')),
                _clienteRequestPostDtoValidator,
                MensagemTamanhoMaximoCampo("Logradouro", 60)
            );

        #endregion Logradouro

        #region Bairro

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Bairro não preenchido")]
        public void ClienteRequestPostDtoValidator_BairroNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(bairro: ""),
                _clienteRequestPostDtoValidator,
                MensagemCampoObrigatorio("Bairro")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Bairro acima do tamanho máximo")]
        public void ClienteRequestPostDtoValidator_BairroMaximo() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(bairro: "".PadLeft(61, 'A')),
                _clienteRequestPostDtoValidator,
                MensagemTamanhoMaximoCampo("Bairro", 60)
            );

        #endregion Bairro

        #region Numero Residencia

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Numero Residencia não preenchido")]
        public void ClienteRequestPostDtoValidator_NumeroResidenciaNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(numeroResidencia: ""),
                _clienteRequestPostDtoValidator,
                MensagemCampoObrigatorio("Numero Residencia")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Numero Residencia acima do tamanho máximo")]
        public void ClienteRequestPostDtoValidator_NumeroResidenciaMaximo() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(numeroResidencia: "".PadLeft(11, '4')),
                _clienteRequestPostDtoValidator,
                MensagemTamanhoMaximoCampo("Numero Residencia", 10)
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Numero Residencia não possui somente números")]
        public void ClienteRequestPostDtoValidator_NumeroResidenciaNumerico() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(numeroResidencia: "AAA"),
                _clienteRequestPostDtoValidator,
                MensagemCampoNumerico("Numero Residencia")
            );

        #endregion Numero Residencia

        #region Cidade

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Cidade não preenchido")]
        public void ClienteRequestPostDtoValidator_CidadeNaoPreenchido() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(cidade: ""),
                _clienteRequestPostDtoValidator,
                MensagemCampoObrigatorio("Cidade")
            );

        [Trait("", "Application/Validations")]
        [Fact(DisplayName = "ClienteRequestPostDtoValidator - Cidade acima do tamanho máximo")]
        public void ClienteRequestPostDtoValidator_CidadeMaximo() =>
            Validate_Falha(
                _fixture.CriarClienteRequestPostDto(cidade: "".PadLeft(251, 'A')),
                _clienteRequestPostDtoValidator,
                MensagemTamanhoMaximoCampo("Cidade", 250)
            );

        #endregion Cidade
    }
}