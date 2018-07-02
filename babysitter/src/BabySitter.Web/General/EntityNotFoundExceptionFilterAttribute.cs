using System.Net;
using BabySitter.Core.General;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BabySitter.Web.General
{
    public class EntityNotFoundExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is EntityNotFoundException exception)
                UpdateResponse(context);
        }

        private void UpdateResponse(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            response.StatusCode = (int) HttpStatusCode.NotFound;
        }
    }
}