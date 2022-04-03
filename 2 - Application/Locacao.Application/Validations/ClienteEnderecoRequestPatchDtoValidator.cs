using FluentValidation;
using Locacao.Application.Dtos;
using System.Text.RegularExpressions;

namespace Locacao.Application.Validations
{
    public class ClienteEnderecoRequestPatchDtoValidator : BaseValidator<ClienteEnderecoRequestPatchDto>
    {
        public ClienteEnderecoRequestPatchDtoValidator()
        {
            RuleFor(x => x.Logradouro)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Logradouro"))
                .MaximumLength(60).WithMessage(MensagemTamanhoMaximoCampo("Logradouro", 60));

            RuleFor(x => x.Bairro)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Bairro"))
                .MaximumLength(60).WithMessage(MensagemTamanhoMaximoCampo("Bairro", 60));

            RuleFor(x => x.NumeroResidencia)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Numero Residencia"))
                .MaximumLength(10).WithMessage(MensagemTamanhoMaximoCampo("Numero Residencia", 10))
                .Must(x => Regex.IsMatch(x, "^[0-9]*$")).WithMessage(MensagemCampoNumerico("Numero Residencia"));

            RuleFor(x => x.Cidade)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Cidade"))
                .MaximumLength(250).WithMessage(MensagemTamanhoMaximoCampo("Cidade", 250));
        }
    }
}