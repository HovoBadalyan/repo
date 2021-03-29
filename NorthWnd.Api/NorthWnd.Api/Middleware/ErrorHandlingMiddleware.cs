using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NorthWnd.CORE.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace NorthWnd.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (LogicException logicException)
            {
                var message = logicException.InnerException?.Message ?? logicException.Message;
                _logger.LogError(logicException, "");
                await WriteToResponse(context, message, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException?.Message ?? ex.Message;
                _logger.LogError(ex, "");
                await WriteToResponse(context, message, HttpStatusCode.InternalServerError);
            }
        }

        private Task WriteToResponse(HttpContext context, string message, HttpStatusCode statusCode)
        {
            var response = context.Response;

            response.StatusCode = (int)statusCode;

            return response.WriteAsync(JsonConvert.SerializeObject(message, Formatting.Indented,
              new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }
    }
}
