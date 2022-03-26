using Locacao.Infrastructure.CrossCuting.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
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
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = CONTENT_TYPE;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await ResponseError(context, "Houve um erro inesperado, tente novamente mais tarde.");

            _logger.LogError(exception, exception.Message);
        }

        private async Task ResponseError(HttpContext context, string mensagem, int codigo = default) =>
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ExceptionResponseDto(mensagem, codigo)));

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            string text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return text;
        }
    }
}