using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BugAndFix_Car_Insurance.API.Filter.ExceptionFilter
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException exception)
            {
                context.Result = new ObjectResult(exception.Message)
                {
                    StatusCode = exception.Status,
                    Value = exception.Message
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
