using Locacao.Application.Dtos;
using Locacao.Application.Validations;
using System;
using System.Linq;
using Xunit;

namespace Locacao.Application.Tests.Validations
{
    public class BaseTests<TRequest,TValidator>
        where TRequest : BaseRequestDto
        where TValidator : BaseValidator<TRequest>
    {
        protected string MensagemCampoObrigatorio(string campo) => $"O campo {campo} é obrigatorio.";
        protected string MensagemCampoInvalido(string campo) => $"O valor para o campo {campo} é inválido.";
        protected string MensagemCampoNumerico(string campo) => $"O campo {campo} aceita apenas números.";
        protected string MensagemTamanhoMaximoCampo(string campo, int tamanho) => $"O campo {campo} deve conter no máximo {tamanho} caracteres.";
        protected string MensagemTamanhoMinimoCampo(string campo, int tamanho) => $"O campo {campo} deve conter no mínimo {tamanho} caracteres.";
        protected string MensagemTamanhoCampo(string campo, int tamanho) => $"O campo {campo} deve conter {tamanho} caractere(s).";
        protected string MensagemValorMinMax<N>(string campo, N min, N max) => $"O campo {campo} deve conter um valor entre {min} e {max}.";
        protected string MensagemDataMaiorQueAtual(string campo) => $"O campo {campo} não pode ser maior que a data atual.";
        protected string MensagemCampoMenorQueOutro(string campo, string campo2) => $"O campo {campo} não pode ser menor que {campo2}.";

        protected void Validate_Sucesso(TRequest request, TValidator validator)
        {
            // Act
            var validationResult = validator.Validate(request);

            // Assert
            Assert.True(validationResult.IsValid);
            Assert.False(validationResult.Errors.Any());
        }

        protected void Validate_Falha(TRequest request, TValidator validator, string mensagem)
        {
            // Act
            var validationResult = validator.Validate(request);

            // Assert
            Assert.False(validationResult.IsValid);
            Assert.Contains(validationResult.Errors, x => x.ErrorMessage == mensagem);
        }
    }
}
