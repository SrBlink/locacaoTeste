using FluentValidation;
using Locacao.Application.Dtos;

namespace Locacao.Application.Validations
{
    public class ReservaRequestPostDtoValidator : BaseValidator<ReservaRequestPostDto>
    {
        public ReservaRequestPostDtoValidator()
        {
            RuleFor(x => x.ClienteId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Cliente"));

            RuleFor(x => x.VeiculoId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Veiculo"));

        }
    }
}