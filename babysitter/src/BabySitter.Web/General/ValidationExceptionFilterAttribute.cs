using System.IO;
using System.Net;
using System.Text;
using BabySitter.Core.General.Validation;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace BabySitter.Web.General
{
    public class ValidationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException exception)
                UpdateResponse(exception, context);
        }

        public static void UpdateResponse(ValidationException exception, ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            response.StatusCode = (int) HttpStatusCode.BadRequest;
            var json = JsonConvert.SerializeObject(exception.Result);
            var bytes = Encoding.UTF8.GetBytes(json);
            response.Body = new MemoryStream(bytes);
        }
    }
}