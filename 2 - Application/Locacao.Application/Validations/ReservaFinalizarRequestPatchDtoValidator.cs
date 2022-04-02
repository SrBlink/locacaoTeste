using FluentValidation;
using Locacao.Application.Dtos;

namespace Locacao.Application.Validations
{
    public class ReservaFinalizarRequestPatchDtoValidator : BaseValidator<ReservaFinalizarRequestPatchDto>
    {
        public ReservaFinalizarRequestPatchDtoValidator()
        {
            RuleFor(x => x.DataDevolucao)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Data Devolução"));

        }
    }
}