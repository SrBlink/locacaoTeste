using FluentValidation;
using Locacao.Application.Dtos;

namespace Locacao.Application.Validations
{
    public class ReservaRequestPatchDtoValidator : BaseValidator<ReservaRequestPatchDto>
    {
        public ReservaRequestPatchDtoValidator()
        {
            RuleFor(x => x.DataPrevistaDevolucao)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Data Prevista Devolução"));

            RuleFor(x => x.DataRetirada)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Data Retirada"));

        }
    }
}