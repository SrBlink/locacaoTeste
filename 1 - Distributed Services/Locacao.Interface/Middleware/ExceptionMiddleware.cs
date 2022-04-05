using Locacao.Domain.Exceptions;
using Locacao.Infrastructure.CrossCuting.DTOs;
using Locacao.Infrastructure.CrossCuting.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Locacao.Interface.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        private const string CONTENT_TYPE = "application/json; charset=utf-8";

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            MemoryStream responseBody = new MemoryStream();

            try
            {
                await _next.Invoke(context);
            }
            catch (DomainException ex)
            {
                await HandleDomainExceptionAsync(context, ex);
            }
            catch (ValidationException ex)
            {
                await HandleValidationExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleDomainExceptionAsync(HttpContext context, DomainException exception)
        {
            context.Response.ContentType = CONTENT_TYPE;
            context.Response.StatusCode = (int)exception.Status;

            _logger.LogError(exception, exception.Message);

            if (exception?.Erro != null && exception.Erro.Any())
                await ResponseError(context, exception.Erro);
        }

        private async Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
        {
            context.Response.ContentType = CONTENT_TYPE;
            context.Response.StatusCode = (int)exception.Status;

            _logger.LogError(exception, exception.Message);

            if (exception?.Erros != null && exception.Erros.Any())
                await ResponseError(context, exception.Erros);
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = CONTENT_TYPE;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await ResponseError(context, "Houve um erro inesperado, tente novamente mais tarde.");

            _logger.LogError(exception, exception.Message);
        }

        private async Task ResponseError(HttpContext context, string mensagem) =>
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ExceptionResponseDto(mensagem)));

        private async Task ResponseError(HttpContext context, IReadOnlyCollection<string> mensagens) =>
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ExceptionResponseDto(mensagens)));
    }
}