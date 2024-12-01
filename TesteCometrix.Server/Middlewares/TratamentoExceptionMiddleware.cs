using System.Net;
using TesteCometrix.Server.Exceptions;

namespace TesteCometrix.Server.Middlewares
{
    public class TratamentoExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public TratamentoExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            ErroExceptionResponseBase erroExceptionResponse;

            switch (exception)
            {

                case CustomException customException:
                    erroExceptionResponse = new ErroExceptionResponseBase(HttpStatusCode.InternalServerError, customException.Message);
                    break;

                default:
                    erroExceptionResponse = new ErroExceptionResponseBase(HttpStatusCode.InternalServerError, "Ocorreu um erro inesperado. Por favor, tente novamente.");
                    break;
            }

            context.Response.StatusCode = erroExceptionResponse.CodigoStatus;
            await context.Response.WriteAsJsonAsync(erroExceptionResponse);
        }

        
    }
}
