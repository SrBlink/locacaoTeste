﻿using FluentValidation;

namespace Locacao.Application.Validations
{
    public class BaseValidator<T> : AbstractValidator<T>
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

    }
}