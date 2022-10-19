using Core.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.Application.Pipelines.Filters
{
    public class GlobalActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult)
            {
                var objectResult = context.Result as ObjectResult;

                if (objectResult.Value != null && typeof(IApiResponse).IsAssignableFrom(objectResult.Value.GetType()))
                {
                    var result = objectResult.Value as IApiResponse;
                    context.HttpContext.Response.StatusCode = (int)result.ResponseCode;
                }
            }
        }
    }
}
