using FluentValidation;
using Locacao.Application.Dtos;
using System.Text.RegularExpressions;

namespace Locacao.Application.Validations
{
    public class ClienteRequestPostDtoValidator : BaseValidator<ClienteRequestPostDto>
    {
        public ClienteRequestPostDtoValidator()
        {
            RuleFor(x => x.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Nome"))
                .MaximumLength(250).WithMessage(MensagemTamanhoMaximoCampo("Nome", 250));

            RuleFor(x => x.DataNascimento)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Data Nascimento"));

            RuleFor(x => x.Cpf)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Cpf"))
                .MaximumLength(11).WithMessage(MensagemTamanhoMaximoCampo("Cpf", 11))
                .Must(x => Regex.IsMatch(x, "^[0-9]*$")).WithMessage(MensagemCampoNumerico("Cpf"));

            RuleFor(x => x.Cnh)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Cnh"))
                .MaximumLength(50).WithMessage(MensagemTamanhoMaximoCampo("Cnh", 50))
                .Must(x => Regex.IsMatch(x, "^[0-9]*$")).WithMessage(MensagemCampoNumerico("Cnh"));

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