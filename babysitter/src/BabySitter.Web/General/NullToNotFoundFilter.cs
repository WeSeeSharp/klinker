using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BabySitter.Web.General
{
    public class NullToNotFoundFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            if (!IsGetRequest(context))
                return;

            if (context.Result is OkObjectResult result
                && result.Value == null)
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.NotFound;
        }

        private static bool IsGetRequest(ResultExecutedContext context)
        {
            return context.HttpContext.Request.Method == HttpMethod.Get.ToString();
        }
    }
}