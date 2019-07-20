using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApiGuaxCore.customException;

namespace APIDOGUAX.infraestructure
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null) return;

            var code = HttpStatusCode.InternalServerError;

            if (exception is ArgumentException) code = HttpStatusCode.BadRequest;
            else if (exception is KeyNotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is UserConflictException) code = HttpStatusCode.Conflict;

            await WriteExceptionAsync(context, exception, code).ConfigureAwait(false);
        }

        private async Task WriteExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code)
        {
            if (code != HttpStatusCode.InternalServerError)
            { }
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;
            await response.WriteAsync(JsonConvert.SerializeObject(exception.Message)).ConfigureAwait(false);
        }
    }
}
