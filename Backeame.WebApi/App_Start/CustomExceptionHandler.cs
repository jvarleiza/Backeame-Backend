using Backeame.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Backeame.WebApi
{
    public class CustomExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            DBLogger.LogException(context.Exception, context.Request.RequestUri.OriginalString);
            if (context.Exception is NotImplementedException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "NotImplementedException"
                };

                context.Result = new ArgumentNullResult(context.Request, result);
            }
            else if (context.Exception is AuthenticationException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "No tiene permisos para realizar la acción solicitada"
                };
                context.Result = new ArgumentNullResult(context.Request, result);
            }
            else
            {
                var result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Ups..."
                };

                context.Result = new ArgumentNullResult(context.Request, result);
            }
        }

        private class ArgumentNullResult : IHttpActionResult
        {
            private HttpRequestMessage request;
            private HttpResponseMessage result;

            public ArgumentNullResult(HttpRequestMessage request, HttpResponseMessage result)
            {
                this.request = request;
                this.result = result;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(result);
            }
        }
    }
}