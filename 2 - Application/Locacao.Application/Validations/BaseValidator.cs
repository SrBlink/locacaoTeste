using System;
using System.Data.SqlTypes;

namespace Locacao.Application.Validations
{
    public class BaseValidator
    {
        protected string MensagemCampoObrigatorio(string campo) => $"O campo {campo} é obrigatorio.";

        protected string MensagemCampoInvalido(string campo) => $"O valor para o campo {campo} é inválido.";

        protected string MensagemCampoNumerico(string campo) => $"O campo {campo} aceita apenas números.";

        protected string MensagemTamanhoMaximoCampo(string campo, int tamanho) => $"O campo {campo} deve conter no máximo {tamanho} caracteres.";

        protected string MensagemTamanhoMinimoCampo(string campo, int tamanho) => $"O campo {campo} deve conter no mínimo {tamanho} caracteres.";

        protected string MensagemTamanhoCampo(string campo, int tamanho) => $"O campo {campo} deve conter {tamanho} caractere(s).";

        protected string MensagemPrecisaoDecimal(string campo, int casasDecimais) => $"O campo {campo} deve conter precisão de {casasDecimais} casas decimais.";

        protected string MensagemFormatoDecimal(string campo, string formato) => $"O campo {campo} deve possuir o formato máximo {formato}.";

        protected string MensagemValorMinMax<N>(string campo, N min, N max) => $"O campo {campo} deve conter um valor entre {min} e {max}.";

        protected bool ValidateDecimal(Decimal? valor, int precisao, int escala)
        {
            if (!valor.HasValue)
                return false;
            if (precisao > 16)
                precisao = 16;
            SqlDecimal sqlDecimal = new SqlDecimal(valor.Value);
            int precision = (int)sqlDecimal.Precision;
            int scale = (int)sqlDecimal.Scale;
            int num = scale;
            return precision - num <= precisao - escala && scale <= escala;
        }

        protected bool ValidateMoney(Decimal? valor) => this.ValidateDecimal(valor, 16, 4);
    }
}