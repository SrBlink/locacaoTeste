﻿using Locacao.Application.Dtos;
using Locacao.Application.Validations;
using Locacao.Infrastructure.CrossCuting.Exceptions;
using System.Linq;

namespace Locacao.Application.Service
{
    public abstract class BaseAppService
    {
        public BaseAppService()
        {
        }

        protected void ValidarRequisicao<TRequest, TValidator>(TRequest request, TValidator validator)
            where TRequest : BaseRequestDto
            where TValidator : BaseValidator<TRequest>
        {
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }
        }
    }
}