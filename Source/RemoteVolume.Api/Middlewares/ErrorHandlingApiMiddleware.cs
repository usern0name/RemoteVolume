using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using RemoteVolume.Common;

// ReSharper disable once IdentifierTypo
namespace RemoteVolume.Api.Middlewares
{
    public class ErrorHandlingApiMiddleware
    {
        #region Fields

        private readonly RequestDelegate _next;

        private readonly ExceptionManager _exceptionManager;

        #endregion Fields

        #region Constructor

        public ErrorHandlingApiMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        #endregion Constructor

        #region Methods

        [DebuggerStepThrough]
        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await this._next(context);
            }
            catch (Exception ex)
            {
                await this.HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";
            var result = exception.Serialize();

            return context.Response.WriteAsync(result);
        }

        #endregion Methods
    }
}
