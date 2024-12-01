using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TesteCometrix.Server.Exceptions;

public class ValidateModelStateFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage);

            var erroExceptionResponse = new ErroExceptionResponseBase(HttpStatusCode.BadRequest, errors);

            context.Result = new JsonResult(erroExceptionResponse)
            {
                StatusCode = erroExceptionResponse.CodigoStatus
            };
        }
    }
}