using FluentValidation;
using Locacao.Application.Dtos;
using System.Text.RegularExpressions;

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

            RuleFor(x => x.ModeloId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Modelo"));

            
        }
    }
}