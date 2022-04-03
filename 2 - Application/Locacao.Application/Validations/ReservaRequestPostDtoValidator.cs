using FluentValidation;
using Locacao.Application.Dtos;
using System;

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

            RuleFor(x => x.DataRetirada)
                .Cascade(CascadeMode.Stop)
                .Must(x => (x.HasValue && x <= DateTime.Now) ||
                           (x == null)).WithMessage(MensagemDataMaiorQueAtual("Data Retirada"));

            RuleFor(x => x)
                .Cascade(CascadeMode.Stop)
                .Must(x => (x.DataPrevistaDevolucao.HasValue && x.DataRetirada.HasValue && x.DataPrevistaDevolucao >= x.DataRetirada) ||
                            (x.DataRetirada.HasValue && x.DataPrevistaDevolucao == null) ||
                            (x.DataRetirada == null & x.DataPrevistaDevolucao == null)).WithMessage(MensagemCampoMenorQueOutro("Data Prevista Devolução", "Data Retirada"));

            RuleFor(x => x)
                .Cascade(CascadeMode.Stop)
                .Must(x => (x.DataPrevistaDevolucao.HasValue && x.DataRetirada.HasValue) ||
                            (x.DataPrevistaDevolucao == null && x.DataRetirada.HasValue) ||
                            (x.DataRetirada == null & x.DataPrevistaDevolucao == null)).WithMessage(MensagemCampoObrigatorio("Data Retirada"));
        }
    }
}