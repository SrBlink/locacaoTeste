using FluentValidation;
using Locacao.Application.Dtos;
using System;

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
                .NotEmpty().WithMessage(MensagemCampoObrigatorio("Data Retirada"))
                .Must(x => x <= DateTime.Now).WithMessage(MensagemDataMaiorQueAtual("Data Retirada"));

            RuleFor(x => x)
                .Cascade(CascadeMode.Stop)
                .Must(x => x.DataPrevistaDevolucao > x.DataRetirada).WithMessage(MensagemCampoMenorQueOutro("Data Previsa Devolucao", "Data Retirada"));
        }
    }
}