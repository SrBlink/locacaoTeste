using FluentValidation;
using Locacao.Application.Dtos;

namespace Locacao.Application.Validations
{
    public class VeiculoRequestPostDtoValidator : BaseValidator<VeiculoRequestPostDto>
    {
        public VeiculoRequestPostDtoValidator()
        {
            RuleFor(x => x.Placa)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Placa"))
                .Length(7).WithMessage(MensagemTamanhoCampo("Placa", 7));

            RuleFor(x => x.ModeloNome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Modelo"))
                .MaximumLength(250).WithMessage(MensagemTamanhoMaximoCampo("Modelo", 250));

            RuleFor(x => x.FabricanteNome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Fabricante"))
                .MaximumLength(250).WithMessage(MensagemTamanhoMaximoCampo("Fabricante", 250));
        }
    }
}