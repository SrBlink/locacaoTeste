using FluentValidation;
using Locacao.Application.Dtos;
using System;

namespace Locacao.Application.Validations
{
    public class ReservaFinalizarRequestPatchDtoValidator : BaseValidator<ReservaFinalizarRequestPatchDto>
    {
        public ReservaFinalizarRequestPatchDtoValidator()
        {
            RuleFor(x => x.DataDevolucao)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Data Devolução"))
                .Must(x => x <= DateTime.Now).WithMessage(MensagemDataMaiorQueAtual("Data Devolução"));


        }
    }
}